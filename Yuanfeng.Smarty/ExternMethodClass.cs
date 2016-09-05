using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Yuanfeng.Smarty
{
    public static class ExternMethodClass
    {
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
    }
}
