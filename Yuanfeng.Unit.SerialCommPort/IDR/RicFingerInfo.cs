using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.SerialCommPort.IDR
{
    public class RicFingerInfo
    {
        /// <summary>
        /// 指纹指位
        /// </summary>
        public byte FingerPosCode { get; set; }

        /// <summary>
        /// 指纹质量
        /// </summary>
        public int FingerQuality { get; set; }

        /// <summary>
        /// 指纹特征点数据（512字节）
        /// </summary>
        public byte[] FingerBuffer { get; set; }
    }

    public class FingerprintBufferParser
    {
        private RicFingerInfo _leftFinger;
        /// <summary>
        /// 左手指纹信息
        /// </summary>
        public RicFingerInfo LeftFinger { get { return _leftFinger; } }

        private RicFingerInfo _rightFinger;

        /// <summary>
        /// 右手指纹信息
        /// </summary>
        public RicFingerInfo RightFinger { get { return _rightFinger; } }

        private FingerDetail fingerinfoFirst;

        private FingerDetail fingerinfoScend;

        private byte[] fingerbufFirst;

        private byte[] fingerbufScend;
        
        private string readResult(int i)
        {
            string msgString = "设备错误";
            switch (i)
            {
                case -11:
                    msgString = "无效参数";
                    break;
                case -5:
                    msgString = "软件未授权";
                    break;
                case -4:
                    msgString = "wlt文件格式错误";
                    break;
                case -3:
                    msgString = "wlt文件打开错误";
                    break;
                case -2:
                    msgString = "wlt文件后缀错误";
                    break;
                case -1:
                    msgString = "相片解码错误";
                    break;
                case 0:
                    msgString = "读卡错误";
                    break;
                case 1:
                    msgString = "正确";
                    break;
                case 2:
                    msgString = "没有最新住址信息";
                    break;
                case 3:
                    msgString = "正确，并且有指纹信息";
                    break;
            }
            return msgString;
        }

        private string encodingConvert(byte[] bytes, int index, int count)
        {
            byte[] utf8Byte = Encoding.Convert(Encoding.GetEncoding("UCS-2"), Encoding.UTF8, bytes, index, count);
            return Encoding.UTF8.GetString(utf8Byte);
        }

        public string analyticSex(int sexCode)
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

        public bool analyticFingerPrint(string filePath)
        {
            string idCardString = string.Empty;
            if (File.Exists(filePath))
            {
                try
                {
                    FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] bytes = new byte[fileStream.Length];
                    fileStream.Read(bytes, 0, (int)fileStream.Length);
                    fileStream.Close();
                    return ParserFingerBuffer(bytes);
                }
                catch { throw; }
            }
            return false;
        }

        public bool ParserFingerBuffer(byte[] bytes)
        {
            string jsonString = string.Empty;
            if (bytes != null && bytes.Length == 1024)
            {
                fingerbufFirst = new byte[bytes.Length / 2];
                fingerbufScend = new byte[bytes.Length / 2];
                Array.ConstrainedCopy(bytes, 0, fingerbufFirst, 0, fingerbufFirst.Length);
                Array.ConstrainedCopy(bytes, fingerbufScend.Length, fingerbufScend, 0, fingerbufScend.Length);
                fingerinfoFirst = analyticFingerData(fingerbufFirst);
                fingerinfoScend = analyticFingerData(fingerbufScend);
                if (fingerinfoFirst.FingerRegistResult != 1 || fingerinfoScend.FingerRegistResult != 1)
                {
                    return false;
                }
                else
                {
                    int code = fingerinfoFirst.FingerPosCode;
                    if (code >= 16 && code <= 20) _leftFinger = new RicFingerInfo() { FingerBuffer = fingerbufFirst, FingerPosCode = (byte)code, FingerQuality = fingerinfoFirst.FingerPrintQlty };
                    else if (code >= 11 && code <= 15) _rightFinger = new RicFingerInfo() { FingerBuffer = fingerbufFirst, FingerPosCode = (byte)code, FingerQuality = fingerinfoFirst.FingerPrintQlty };

                    code = fingerinfoScend.FingerPosCode;
                    if (code >= 11 && code <= 15) _leftFinger = new RicFingerInfo() { FingerBuffer = fingerbufFirst, FingerPosCode = (byte)code, FingerQuality = fingerinfoFirst.FingerPrintQlty };
                    else if (code >= 16 && code <= 20) _rightFinger = new RicFingerInfo() { FingerBuffer = fingerbufFirst, FingerPosCode = (byte)code, FingerQuality = fingerinfoFirst.FingerPrintQlty };
                }
            }
            return true;
        }

        public bool IsRightHand(int fingerCode)
        {
            return (fingerCode >= 11 && fingerCode <= 15) || fingerCode == 97;
        }

        public bool IsLeftHand(int fingerCode)
        {
            return (fingerCode >= 16 && fingerCode <= 20) || fingerCode == 98;
        }

        public string analyticFingerName(int fingerCode)
        {
            string FingerNameString = string.Empty;
            switch (fingerCode)
            {
                case 11:
                    FingerNameString = "右手拇指";
                    break;
                case 12:
                    FingerNameString = "右手食指";
                    break;
                case 13:
                    FingerNameString = "右手中指";
                    break;
                case 14:
                    FingerNameString = "右手环指";
                    break;
                case 15:
                    FingerNameString = "右手小指";
                    break;
                case 16:
                    FingerNameString = "左手拇指";
                    break;
                case 17:
                    FingerNameString = "左手食指";
                    break;
                case 18:
                    FingerNameString = "左手中指";
                    break;
                case 19:
                    FingerNameString = "左手环指";
                    break;
                case 20:
                    FingerNameString = "左手小指";
                    break;
                default:
                    switch (fingerCode)
                    {
                        case 97:
                            FingerNameString = "右手不确定指位";
                            break;
                        case 98:
                            FingerNameString = "左手不确定指位";
                            break;
                        case 99:
                            FingerNameString = "其他不确定指位";
                            break;
                    }
                    break;
            }
            return FingerNameString;
        }

        public FingerDetail analyticFingerData(byte[] bytes)
        {
            FingerDetail fingerinfo = new FingerDetail();
            string jsonString = string.Empty;
            if (bytes != null && bytes.Length == 512)
            {
                fingerinfo.FingerFileHeader = (int)bytes[0];
                fingerinfo.FingerAlgoVersion = (int)bytes[1];
                fingerinfo.FingerCollectorCode = (int)bytes[2];
                fingerinfo.FingerAlgoDevelopCode = (int)bytes[3];
                fingerinfo.FingerRegistResult = (int)bytes[4];
                fingerinfo.FingerPosCode = (int)bytes[5];
                fingerinfo.FingerPosName = analyticFingerName(fingerinfo.FingerPosCode);
                fingerinfo.FingerPrintQlty = bytes[6];
                fingerinfo.FingerCharacterCount = (int)bytes[19];
                fingerinfo.FingerCharacterDateLength = Convert.ToInt64((int)bytes[20] << 8 | (int)bytes[21]);
                fingerinfo.FingerCenterData = new byte[9];

                Array.ConstrainedCopy(bytes, 22, fingerinfo.FingerCenterData, 0, fingerinfo.FingerCenterData.Length);
                fingerinfo.FingerCharacterDetailData = new byte[fingerinfo.FingerCharacterDateLength];
                Array.ConstrainedCopy(bytes, 31, fingerinfo.FingerCharacterDetailData, 0, fingerinfo.FingerCharacterDetailData.Length);
            }
            return fingerinfo;
        }

        public string ErrorCodeAnalysis(int Ret)
        {
            string result;
            switch (Ret)
            {
                case -9:
                    result = "其它错误!";
                    return result;
                case -6:
                    result = "非法错误号!";
                    return result;
                case -5:
                    result = "设备未初始化!";
                    return result;
                case -4:
                    result = "设备不存在!";
                    return result;
                case -3:
                    result = "功能未实现!";
                    return result;
                case -2:
                    result = "内存分配失败，没有分配足够的内存!";
                    return result;
                case -1:
                    result = "参数错误!";
                    return result;
            }
            result = null;
            return result;
        }
    }

}
