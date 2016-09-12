using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Yuanfeng.Smarty;

namespace Yuanfeng.ImageUnit.QrCode
{
    public class TrafficPoliceQrCode
    {
        /// <summary>
        /// 专门为交警定制的二维码
        /// </summary>
        /// <param name="qrCode">二维码内容</param>
        /// <returns></returns>
        public static Image NewQrCode(string qrCode)
        {
            var QrCodeImage = new BaseQrCode(qrCode, 500).Generator().ToBitmap();

            Image tflogo = QrCode.Properties.Resources.TrafficPolice;

            return new ImageExternalClass().MergeQrImg((Bitmap)QrCodeImage, (Bitmap)tflogo);
        }
    }
}
