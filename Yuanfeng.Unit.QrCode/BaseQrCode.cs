using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gma.QrCodeNet.Encoding.Windows.Render;
using Gma.QrCodeNet.Encoding;
using System.IO;
using Yuanfeng.Smarty;
using System.Drawing.Imaging;
using System.Drawing;

namespace Yuanfeng.Unit.QrCode
{
    public class BaseQrCode
    {
        private string qrCodeString = string.Empty;
        private int qrCodeSize = 400;

        public BaseQrCode()
        {

        }

        /// <summary>
        /// new instance and set default value.
        /// </summary>
        /// <param name="qrCodeString"></param>
        /// <param name="qrCodeSize"></param>
        public BaseQrCode(string qrCodeString, int qrCodeSize)
        {
            this.qrCodeString = qrCodeString;
            this.qrCodeSize = qrCodeSize;
        }

        /// <summary>
        /// set ot get this qrcode size default size is 400
        /// </summary>
        public int QrCodeSize
        {
            get
            {
                return qrCodeSize;
            }

            set
            {
                qrCodeSize = value;
            }
        }

        /// <summary>
        /// set or get this qrcode content.
        /// </summary>
        public string QrCodeString
        {
            get
            {
                return qrCodeString;
            }

            set
            {
                qrCodeString = value;
            }
        }

        public byte[] Generator()
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            Gma.QrCodeNet.Encoding.QrCode qrCode = new Gma.QrCodeNet.Encoding.QrCode();
            qrEncoder.TryEncode(QrCodeString, out qrCode);
            var renderer = new GraphicsRenderer(new FixedCodeSize(QrCodeSize, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream stream = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);

            byte[] qrCodeBuffer = null;

            try
            {
                qrCodeBuffer = stream.ToBuffer();
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine("Generator qr code fail. exception message:" + exception.Message);
            }
            return qrCodeBuffer;
        }

        public byte[] Generator(string codeString,int size)
        {
            this.qrCodeSize = size;
            this.qrCodeString = codeString;

            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            Gma.QrCodeNet.Encoding.QrCode qrCode = new Gma.QrCodeNet.Encoding.QrCode();
            qrEncoder.TryEncode(QrCodeString, out qrCode);
            var renderer = new GraphicsRenderer(new FixedCodeSize(QrCodeSize, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream stream = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, stream);

            byte[] qrCodeBuffer = null;

            try
            {
                qrCodeBuffer = stream.ToBuffer();
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine("Generator qr code fail. exception message:" + exception.Message);
            }
            return qrCodeBuffer;
        }
    }
}
