using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Yuanfeng.Smarty
{
    public static class ExternMethodClass
    {
        #region 图片处理静态扩展方法

        /// <summary>
        /// 根据RGB，计算灰度值
        /// </summary>
        /// <param name="posClr">Color值</param>
        /// <returns>灰度值，整型</returns>
        public static int GetGrayNumColor(this System.Drawing.Color posClr)
        {
            return (posClr.R * 19595 + posClr.G * 38469 + posClr.B * 7472) >> 16;
        }

        /// <summary>
        /// 灰度转换,逐点方式
        /// </summary>
        public static Bitmap GrayByPixels(this Bitmap bmpobj)
        {
            for (int i = 0; i < bmpobj.Height; i++)
            {
                for (int j = 0; j < bmpobj.Width; j++)
                {
                    int tmpValue = bmpobj.GetPixel(j, i).GetGrayNumColor();
                    bmpobj.SetPixel(j, i, Color.FromArgb(tmpValue, tmpValue, tmpValue));
                }
            }
            return bmpobj;
        }

        /// <summary>
        /// 去图形边框
        /// </summary>
        /// <param name="borderWidth"></param>
        public static Bitmap ClearPicBorder(this Bitmap bmpobj, int borderWidth)
        {
            for (int i = 0; i < bmpobj.Height; i++)
            {
                for (int j = 0; j < bmpobj.Width; j++)
                {
                    if (i < borderWidth || j < borderWidth || j > bmpobj.Width - 1 - borderWidth || i > bmpobj.Height - 1 - borderWidth)
                        bmpobj.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                }
            }
            return bmpobj;
        }

        /// <summary>
        /// 灰度转换,逐行方式
        /// </summary>
        public static Bitmap GrayByLine(this Bitmap bmpobj)
        {
            Rectangle rec = new Rectangle(0, 0, bmpobj.Width, bmpobj.Height);
            BitmapData bmpData = bmpobj.LockBits(rec, ImageLockMode.ReadWrite, bmpobj.PixelFormat);// PixelFormat.Format32bppPArgb);
            //    bmpData.PixelFormat = PixelFormat.Format24bppRgb;
            IntPtr scan0 = bmpData.Scan0;
            int len = bmpobj.Width * bmpobj.Height;
            int[] pixels = new int[len];
            Marshal.Copy(scan0, pixels, 0, len);

            //对图片进行处理
            int GrayValue = 0;
            for (int i = 0; i < len; i++)
            {
                GrayValue = GetGrayNumColor(Color.FromArgb(pixels[i]));
                pixels[i] = (byte)(Color.FromArgb(GrayValue, GrayValue, GrayValue)).ToArgb();      //Color转byte
            }

            bmpobj.UnlockBits(bmpData);
            return bmpobj;
        }

        /// <summary>
        /// 得到有效图形并调整为可平均分割的大小
        /// </summary>
        /// <param name="dgGrayValue">灰度背景分界值</param>
        /// <param name="CharsCount">有效字符数</param>
        /// <returns></returns>
        public static void GetPicValidByValue(this Bitmap bmpobj, int dgGrayValue, int CharsCount)
        {
            int posx1 = bmpobj.Width; int posy1 = bmpobj.Height;
            int posx2 = 0; int posy2 = 0;
            for (int i = 0; i < bmpobj.Height; i++)      //找有效区
            {
                for (int j = 0; j < bmpobj.Width; j++)
                {
                    int pixelValue = bmpobj.GetPixel(j, i).R;
                    if (pixelValue < dgGrayValue)     //根据灰度值
                    {
                        if (posx1 > j) posx1 = j;
                        if (posy1 > i) posy1 = i;

                        if (posx2 < j) posx2 = j;
                        if (posy2 < i) posy2 = i;
                    };
                };
            };
            // 确保能整除
            int Span = CharsCount - (posx2 - posx1 + 1) % CharsCount;   //可整除的差额数
            if (Span < CharsCount)
            {
                int leftSpan = Span / 2;    //分配到左边的空列 ，如span为单数,则右边比左边大1
                if (posx1 > leftSpan)
                    posx1 = posx1 - leftSpan;
                if (posx2 + Span - leftSpan < bmpobj.Width)
                    posx2 = posx2 + Span - leftSpan;
            }
            //复制新图
            Rectangle cloneRect = new Rectangle(posx1, posy1, posx2 - posx1 + 1, posy2 - posy1 + 1);
            bmpobj = bmpobj.Clone(cloneRect, bmpobj.PixelFormat);
        }

        /// <summary>
        /// 得到有效图形,图形为类变量
        /// </summary>
        /// <param name="dgGrayValue">灰度背景分界值</param>
        /// <param name="CharsCount">有效字符数</param>
        /// <returns></returns>
        public static Bitmap GetPicValidByValue(this Bitmap bmpobj, int dgGrayValue)
        {
            int posx1 = bmpobj.Width; int posy1 = bmpobj.Height;
            int posx2 = 0; int posy2 = 0;
            for (int i = 0; i < bmpobj.Height; i++)      //找有效区
            {
                for (int j = 0; j < bmpobj.Width; j++)
                {
                    int pixelValue = bmpobj.GetPixel(j, i).R;
                    if (pixelValue < dgGrayValue)     //根据灰度值
                    {
                        if (posx1 > j) posx1 = j;
                        if (posy1 > i) posy1 = i;

                        if (posx2 < j) posx2 = j;
                        if (posy2 < i) posy2 = i;
                    };
                };
            };
            //复制新图
            Rectangle cloneRect = new Rectangle(posx1, posy1, posx2 - posx1 + 1, posy2 - posy1 + 1);
            bmpobj = bmpobj.Clone(cloneRect, bmpobj.PixelFormat);

            return bmpobj;
        }


        /// <summary>
        /// 平均分割图片
        /// </summary>
        /// <param name="RowNum">水平上分割数</param>
        /// <param name="ColNum">垂直上分割数</param>
        /// <returns>分割好的图片数组</returns>
        public static Bitmap[] GetSplitPics(this Bitmap bmpobj, int RowNum, int ColNum)
        {
            if (RowNum == 0 || ColNum == 0)
                return null;
            int singW = bmpobj.Width / RowNum;
            int singH = bmpobj.Height / ColNum;
            Bitmap[] PicArray = new Bitmap[RowNum * ColNum];

            Rectangle cloneRect;
            for (int i = 0; i < ColNum; i++)      //找有效区
            {
                for (int j = 0; j < RowNum; j++)
                {
                    cloneRect = new Rectangle(j * singW, i * singH, singW, singH);
                    PicArray[i * RowNum + j] = bmpobj.Clone(cloneRect, bmpobj.PixelFormat);//复制小块图
                }
            }
            return PicArray;
        }

        /// <summary>
        /// 返回灰度图片的点阵描述字串，1表示灰点，0表示背景
        /// </summary>
        /// <param name="singlepic">灰度图</param>
        /// <param name="dgGrayValue">背前景灰色界限</param>
        /// <returns></returns>
        public static string GetSingleBmpCode(this Bitmap singlepic, int dgGrayValue)
        {
            Color piexl;
            string code = "";
            for (int posy = 0; posy < singlepic.Height; posy++)
                for (int posx = 0; posx < singlepic.Width; posx++)
                {
                    piexl = singlepic.GetPixel(posx, posy);
                    if (piexl.R < dgGrayValue)    // Color.Black )
                        code = code + "1";
                    else
                        code = code + "0";
                }
            return code;
        }

        /// <summary>
        /// 去掉噪点
        /// </summary>
        /// <param name="dgGrayValue"></param>
        /// <param name="MaxNearPoints"></param>
        public static Bitmap ClearNoise(this Bitmap bmpobj, int dgGrayValue, int MaxNearPoints)
        {

            Color piexl;
            int nearDots = 0;
            int XSpan, YSpan, tmpX, tmpY;
            //逐点判断
            for (int i = 0; i < bmpobj.Width; i++)
                for (int j = 0; j < bmpobj.Height; j++)
                {
                    piexl = bmpobj.GetPixel(i, j);
                    if (piexl.R < dgGrayValue)
                    {
                        nearDots = 0;
                        //判断周围8个点是否全为空
                        if (i == 0 || i == bmpobj.Width - 1 || j == 0 || j == bmpobj.Height - 1)  //边框全去掉
                        {
                            bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            if (bmpobj.GetPixel(i - 1, j - 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i, j - 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i + 1, j - 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i - 1, j).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i + 1, j).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i - 1, j + 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i, j + 1).R < dgGrayValue) nearDots++;
                            if (bmpobj.GetPixel(i + 1, j + 1).R < dgGrayValue) nearDots++;
                        }

                        if (nearDots < MaxNearPoints)
                            bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));   //去掉单点 && 粗细小3邻边点
                    }
                    else  //背景
                        bmpobj.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            return bmpobj;

        }
        /// <summary>
        /// 扭曲图片校正
        /// </summary>
        public static Bitmap ReSetBitMap(this Bitmap bmpobj)
        {
            Graphics g = Graphics.FromImage(bmpobj);
            Matrix X = new Matrix();
            //  X.Rotate(30);
            X.Shear((float)0.16666666667, 0);   //  2/12
            g.Transform = X;
            // Draw image
            //Rectangle cloneRect = GetPicValidByValue(128);  //Get Valid Pic Rectangle
            Rectangle cloneRect = new Rectangle(0, 0, bmpobj.Width, bmpobj.Height);
            Bitmap tmpBmp = bmpobj.Clone(cloneRect, bmpobj.PixelFormat);
            g.DrawImage(tmpBmp,
                new Rectangle(0, 0, bmpobj.Width, bmpobj.Height),
                 0, 0, tmpBmp.Width,
                 tmpBmp.Height,
                 GraphicsUnit.Pixel);

            return tmpBmp;
        }

        /// <summary>
        /// get image thumbnail
        /// </summary>
        /// <param name="bmp">source bitmap</param>
        /// <param name="destHeight">dest image height</param>
        /// <param name="destWidth">dest image width</param>
        /// <returns></returns>
        public static Bitmap GetThumbnail(this Bitmap bmp, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = bmp;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // 按比例缩放 
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量 
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量 
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            imgSource.Dispose();
            return outBmp;
        }

        /// <summary>
        /// get image thumbnail
        /// </summary>
        /// <param name="buffer">source image buffer</param>
        /// <param name="destHeight">dest image height</param>
        /// <param name="destWidth">dest image width</param>
        /// <returns></returns>
        public static byte[] GetThumbnail(this byte[] buffer, int destHeight, int destWidth)
        {
            Bitmap bmp = buffer.ToBitmap() as Bitmap;

            System.Drawing.Image imgSource = bmp;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            // 按比例缩放 
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            // 设置画布的描绘质量 
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            // 以下代码为保存图片时，设置压缩质量 
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            imgSource.Dispose();
            return outBmp.ToBuffer();
        }

        public static byte[] ToBuffer(this Stream stream)
        {
            if (stream == null || !stream.CanRead) throw new Exception("The stream is null or can not read.");
            try
            {
                byte[] buffer = new byte[stream.Length];
                stream.Position = 0;
                stream.Read(buffer, 0, buffer.Length);
                stream.Close();

                return buffer;
            }
            catch (Exception exception)
            {
                throw new Exception("Convert stream to buffer is fail.", exception);
            }

        }
        public static Image ToBitmap(this byte[] buffer)
        {
            if (buffer == null || buffer.Length == 0) throw new Exception("The iamge buffer is null or empty.");

            Image bmp = null;
            try
            {
                bmp = Bitmap.FromStream(new MemoryStream(buffer));
            }
            catch (Exception exception)
            {
                throw new Exception("Convert buffer to image is fail.", exception);
            }

            return bmp;
        }
        /// <summary>
        /// The default image format is bmp.
        /// </summary>
        /// <param name="image">please use bmp image.</param>
        /// <returns>The image buffer array.</returns>
        public static byte[] ToBuffer(this Image image)
        {
            if (image == null) throw new Exception("This args is null.");

            byte[] buffer = null;

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                buffer = new byte[ms.Length];

                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
            }

            return buffer;
        }

        /// <summary>
        /// The default image format is bmp.
        /// </summary>
        /// <param name="image">please use bmp image.</param>
        /// <returns>The image buffer array.</returns>
        public static byte[] ToBuffer(this Bitmap bmp)
        {
            if (bmp == null) throw new Exception("This args is null.");

            byte[] buffer = null;

            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                buffer = new byte[ms.Length];

                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
            }

            return buffer;
        }
        #endregion

        #region 二进制文件操作的静态扩展方法
        /// <summary>
        /// 将二进制数据写入文件
        /// </summary>
        /// <param name="buffer">缓冲区数据</param>
        /// <param name="filename">目标文件地址（全路径）</param>
        /// <returns>如果成功写入则返回True，否则返回False</returns>
        public static bool Writer(this byte[] buffer, string filename)
        {
            if (buffer == null || buffer.Length == 0) return false;

            if (string.IsNullOrEmpty(filename)) return false;

            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(buffer);
                }
            }
            return File.Exists(filename);
        }
        /// <summary>
        /// writer data to file use binarywriter.
        /// </summary>
        /// <param name="buffer">target data</param>
        /// <param name="filename">target filename</param>
        /// <returns>if file created return true</returns>
        public static bool Writer(this string value, string filename)
        {
            if (string.IsNullOrEmpty(value)) return false;

            if (string.IsNullOrEmpty(filename)) return false;

            byte[] buffer = Encoding.Default.GetBytes(value);
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(buffer);
                }
            }

            return File.Exists(filename);
        }
        /// <summary>
        /// read buffer from binary file.
        /// </summary>
        /// <param name="filename">target filename</param>
        /// <returns>if file exists and read data return true</returns>
        public static byte[] Reader(this string filename)
        {
            if (!File.Exists(filename)) return null;

            byte[] buffer = null;
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                buffer = new byte[fs.Length];
                BinaryReader reader = new BinaryReader(fs);
                buffer = reader.ReadBytes(buffer.Length);
            }
            return buffer;
        }
        /// <summary>
        /// read buffer from binary file.
        /// </summary>
        /// <param name="filename">target filename</param>
        /// <returns>if file exists and read data return true</returns>
        public static bool Writer(this Stream stream, string filename)
        {
            if (stream == null) return false;

            if (string.IsNullOrEmpty(filename)) return false;

            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                byte[] buffer = null;
                buffer = new byte[stream.Length]; fs.Read(buffer, 0, buffer.Length);
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(buffer);
                }
            }
            return true;
        }
        ///<summary> 
        /// 序列化 
        /// </summary> 
        /// <param name="obj">要序列化的对象</param> 
        /// <returns>返回存放序列化后的数据缓冲区</returns> 
        public static byte[] Serialize(this object obj)
        {
            if (obj == null) return null;
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                return stream.GetBuffer();
            }
        }
        /// <summary> 
        /// 反序列化 
        /// </summary> 
        /// <param name="obj">数据缓冲区</param> 
        /// <returns>对象</returns> 
        public static object Deserialize(this byte[] obj)
        {
            if (obj == null) return null;
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Binder = new UBinder();
            using (MemoryStream stream = new MemoryStream(obj))
            {
                obj = null;
                return formatter.Deserialize(stream);
            }
        }

        public static byte[] ToBuffer(this string obj)
        {
            return Encoding.Unicode.GetBytes(obj);
        }

        public static string ToString(this byte[] obj)
        {
            return Encoding.Unicode.GetString(obj);
        }

        public static bool Exists(this object[] objs, object obj)
        {
            foreach (var item in objs)
            {
                if (item.Equals(obj)) return true;
            }

            return false;
        }

        #endregion

        #region 时间处理
        public static DateTime TryDate(this string s)
        {
            if (string.IsNullOrEmpty(s)) return DateTime.Now;

            s = s.Trim();

            if (string.IsNullOrEmpty(s)) return DateTime.Now;

            s = UtilClass.RemoveNotNum(s);

            if (s.Length < 8) s = s.PadRight(8, '0');

            if (s.Length > 8 && s.Length < 14) s = s.Substring(0, 8);

            if (s.Length > 14) s = s.Substring(0, 14);

            int len = s.Length;

            DateTime outDateTime = DateTime.Now;
            bool result = false;
            switch (len)
            {
                case 8:
                    result = DateTime.TryParseExact(s, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out outDateTime);
                    break;
                case 14:
                    result = DateTime.TryParseExact(s, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out outDateTime);
                    break;
                default:
                    break;
            }

            if (result) return outDateTime;

            return DateTime.Now;
        }

        public static DateTime TryDate(this string s, int len)
        {
            if (string.IsNullOrEmpty(s)) return DateTime.Now;

            s = s.Trim();

            if (string.IsNullOrEmpty(s)) return DateTime.Now;

            s = UtilClass.RemoveNotNum(s);

            if (s.Length <= 8) s = s.PadRight(8, '0');

            if (s.Length > 8 && s.Length < 14) s = s.Substring(0, 8);

            if (s.Length > 14) s = s.Substring(0, 14);

            if (len != 8 && len != 14) return DateTime.Now;

            DateTime outDateTime = DateTime.Now;
            bool result = false;
            switch (len)
            {
                case 8:
                    result = DateTime.TryParseExact(s, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out outDateTime);
                    break;
                case 14:
                    result = DateTime.TryParseExact(s, "yyyyMMddHHmmss", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out outDateTime);
                    break;
                default:
                    break;
            }

            if (result) return outDateTime;

            return DateTime.Now;
        }

        public static int TryAge(this string s)
        {
            DateTime birth = TryDate(s);

            return DateTime.Now.Year - birth.Year;
        }

        public static int TryAge(this string s, int len)
        {
            DateTime birth = TryDate(s, len);

            return DateTime.Now.Year - birth.Year;
        }

        public static int TryTotalDays(this string s)
        {
            DateTime begin = s.TryDate().AddDays(1);

            double totals = Math.Abs((begin - DateTime.Now.Date).TotalDays);

            return (int)totals;
        }

        public static DateTime TryAuthdDay(this string s, int days)
        {
            return s.TryDate().AddDays(1).AddDays(days);
        }

        public static bool NearExpired(this string s, int days)
        {
            return !IsExpired(s) && s.TryTotalDays() <= days;
        }

        public static bool IsExpired(this string s)
        {
            return s.TryDate().CompareTo(DateTime.Now.Date) < 0;
        }

        #endregion

        #region 字符串加解密
        /// <summary>
        /// 使用默认密钥对数据进行加密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Encrypt(this string source)
        {
            return Smarty.Encrypt.AES.AESEncrypt(source, "Yuanfeng2016");
        }
        /// <summary>
        /// 使用默认密钥对数据解密
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string Decrypt(this string source)
        {
            return Smarty.Encrypt.AES.AESDecrypt(source, "Yuanfeng2016");
        }
        #endregion
    }
}