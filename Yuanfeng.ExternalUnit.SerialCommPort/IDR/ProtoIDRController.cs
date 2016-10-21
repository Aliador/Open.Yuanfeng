using System;
using System.IO;
using System.Text;
using System.Threading;
using Yuanfeng.Smarty;

namespace Yuanfeng.ExternalUnit.SerialCommPort.IDR
{
    public class ProtoIDRController : IProtoIDRController
    {
        private const string ContentFilePath = "wz.txt";
        private const string PhotoFilePath3 = "xp.wlt";
        private const string FingerprintFilePath = "fp.dat";
        private const string PhotoFilePath2 = "zp.wlt";
        private const string PhotoFilePath = "zp.bmp";
        private bool isOpen = false;

        private Thread idrReadThrad;

        private int Init(int serialPort = 1001)
        {
            int result = 0;
            try
            {
                result = ProtoController.InitComm(serialPort);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }

        private int InitCommExt()
        {
            int result;
            try
            {
                result = ProtoController.InitCommExt();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }

        private int Realase()
        {
            int result;
            try
            {
                result = ProtoController.CloseComm();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }

        private bool Authenticate()
        {
            bool result = false;
            try
            {
                int tryTimes = 3;
                while (tryTimes > 0 && !result)
                {
                    result = (ProtoController.Authenticate() == 1);
                    SimpleConsole.Write(string.Format(" try time {0},result {1}", 3 - tryTimes, result));
                    Thread.Sleep(200);
                    tryTimes--;
                }
            }
            catch (Exception exception)
            {
                SimpleConsole.Write(exception);
            }
            return result;
        }

        private string GetSamId()
        {
            string result;
            try
            {
                result = ProtoController.GetSAMID();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }

        private int GetContentItem()
        {
            int result = -999;
            try
            {
                result = ProtoController.Read_Content_Path(ProtoController.Dir, 1);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return result;
        }

        private RicTextInfo DecodeObject()
        {
            int itemCount = GetContentItem();
            RicTextInfo ricTextInfo = null;
            string filePath = Path.Combine(ProtoController.Dir, ContentFilePath);
            if (File.Exists(filePath))
            {
                ricTextInfo = new RicTextInfo();
                try
                {
                    FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] bytes = new byte[fileStream.Length];
                    fileStream.Read(bytes, 0, (int)fileStream.Length);
                    fileStream.Close();
                    ricTextInfo = StringConvertObject(bytes);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            filePath = Path.Combine(ProtoController.Dir, PhotoFilePath);
            if (File.Exists(filePath) && ricTextInfo != null)
            {
                try
                {
                    byte[] tmpPhotoBytes = null;
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        tmpPhotoBytes = new byte[fileStream.Length];
                        fileStream.Read(tmpPhotoBytes, 0, (int)fileStream.Length);
                    }
                    ricTextInfo.Photo = tmpPhotoBytes;
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }

            byte[] fingerBuffer = DecodeFingerPrint();
            ricTextInfo.FingerBuffer = fingerBuffer;
            ricTextInfo.IncludeFinger = (fingerBuffer != null && fingerBuffer.Length > 0);

            DeleteCardFile();
            return ricTextInfo;
        }

        private byte[] DecodeFingerPrint()
        {
            string filePath = Path.Combine(ProtoController.Dir, FingerprintFilePath);
            if (File.Exists(filePath))
            {
                return filePath.Reader();
            }

            return null;
        }
        private bool DeleteCardFile()
        {
            try
            {
                File.Delete(Path.Combine(ProtoController.Dir, ContentFilePath));
                File.Delete(Path.Combine(ProtoController.Dir, PhotoFilePath));
                File.Delete(Path.Combine(ProtoController.Dir, PhotoFilePath2));
                File.Delete(Path.Combine(ProtoController.Dir, PhotoFilePath3));
                File.Delete(Path.Combine(ProtoController.Dir, FingerprintFilePath));
            }
            catch { }

            return !File.Exists(ContentFilePath) && !File.Exists(PhotoFilePath) && !File.Exists(FingerprintFilePath);
        }

        private RicTextInfo StringConvertObject(byte[] bytes)
        {
            var idCardInfo = new RicTextInfo();
            if (bytes != null && bytes.Length == 256)
            {
                int i = 30;
                string name = EncodingConvert(bytes, 0, 30).Trim();
                int sexCode = TypeHelper.ParseInt(EncodingConvert(bytes, i, 2));
                i += 2;
                int nationCode = TypeHelper.ParseInt(EncodingConvert(bytes, i, 4));
                string nation = new VolkCollection()[nationCode];
                i += 4;
                int birthDate = TypeHelper.ParseInt(EncodingConvert(bytes, i, 16));
                i += 16;
                string address = EncodingConvert(bytes, i, 70).Trim();
                i += 70;
                string idNumber = EncodingConvert(bytes, i, 36).Trim();
                i += 36;
                string issuingAuthority = EncodingConvert(bytes, i, 30).Trim();
                i += 30;
                string issuingDate = EncodingConvert(bytes, i, 16).Trim();
                i += 16;
                string expiratinDate = EncodingConvert(bytes, i, 16).Trim();


                idCardInfo.DwellingPlace = address;
                idCardInfo.Birth = TypeHelper.ParseString(birthDate);
                idCardInfo.ExpireDate = expiratinDate;
                idCardInfo.CitizenIDNumber = idNumber;
                idCardInfo.Authority = issuingAuthority;
                idCardInfo.AuthortityDate = issuingDate;
                idCardInfo.Name = name;
                idCardInfo.Volk = nation;
                idCardInfo.VolkCode = TypeHelper.ParseString(nationCode);
                idCardInfo.Sex = DecodeSex(sexCode);
                idCardInfo.SexCode = TypeHelper.ParseString(sexCode);
            }
            return idCardInfo;
        }

        private static string EncodingConvert(byte[] bytes, int index, int count)
        {
            byte[] utf8Byte = Encoding.Convert(Encoding.GetEncoding("UCS-2"), Encoding.UTF8, bytes, index, count);
            return Encoding.UTF8.GetString(utf8Byte);
        }

        private string DecodeSex(int sexCode)
        {
            string sexString = string.Empty;
            switch (sexCode)
            {
                case 0:
                    sexString = "未知";
                    break;
                case 1:
                    sexString = "男";
                    break;
                case 2:
                    sexString = "女";
                    break;
                default:
                    if (sexCode == 9)
                    {
                        sexString = "未说明";
                    }
                    break;
            }
            return sexString;
        }

        public int Scan(IDReadCompletedHandler completedHandler, int channel = 1001, int timeout = 30)
        {
            if (isOpen) return 1;
            idrReadThrad = new Thread((object arg) =>
            {
                int tmpRemainTime = (int)arg;
                try
                {
                    RicTextInfo temp = null;
                    while (tmpRemainTime > 0)
                    {
                        Init(channel);
                        if (Authenticate())
                        {
                            temp = DecodeObject();
                            break;
                        }
                        Realase();
                        Thread.Sleep(100);
                        tmpRemainTime -= 100;
                    }
                    isOpen = false; completedHandler.Invoke(temp);
                }
                catch (Exception exception) { throw exception; }
            });
            idrReadThrad.Start(timeout); isOpen = true;

            return 1;
        }

        public int Stop()
        {
            if (isOpen) { idrReadThrad.Abort(); isOpen = false; }
            return 1;
        }

        public bool IsOpen { get { return isOpen; } }
    }
}
