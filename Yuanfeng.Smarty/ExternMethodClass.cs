﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Yuanfeng.Smarty
{
    public static class ExternMethodClass
    {
        #region image access

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

        #region binary file access
        /// <summary>
        /// writer data to file use binarywriter.
        /// </summary>
        /// <param name="buffer">target data</param>
        /// <param name="filename">target filename</param>
        /// <returns>if file created return true</returns>
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
        #endregion

        #region datetime access
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

            if (len != 8 || len != 14) return DateTime.Now;

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
        #endregion
    }
}