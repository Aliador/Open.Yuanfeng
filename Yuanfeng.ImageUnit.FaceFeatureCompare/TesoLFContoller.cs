using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TesoSeeuLib;

namespace Yuanfeng.ImageUnit.FaceFeatureCompare
{
    public class TesoLFContoller : ILiveFaceCompare
    {
        private LFCompletedHandler handler;
        private bool isOpen = false;
        public bool IsOpen { get { return isOpen; } }
        private AxcriterionLib.Axstdfcectl control = new AxcriterionLib.Axstdfcectl();
        public int Close()
        {
            if (isOpen)
            {
                string result = control.closeDevice();
                bool right = IsRight(result);
                if (right) isOpen = false;
            }
            return 1;
        }

        public int Init(Control container, LFCompletedHandler handler)
        {
            if (container == null) throw new Exception("container参数为空");
            if (container.Controls.Count > 0) container.Controls.RemoveAt(0);
            control.Size = new System.Drawing.Size(640, 480);
            control.Location = new System.Drawing.Point(0, 0);
            container.Controls.Add(control);
            this.handler = handler;
            return 1;
        }

        public int Start()
        {
            if (isOpen) { Close(); }
            string result = string.Empty;
            var IdCard = "000000000000000000";
            var Serise = "000000000000000000000000000000";
            string Param = "<? xml version =\"1.0\" encoding=\"utf-8\" ?><param><imgWidth>640</imgWidth><imgHeight>480</imgHeight><imgCompress>85</imgCompress><pupilDistMin>0</pupilDistMin><pupilDistMax>150</pupilDistMax><isActived>2</isActived><isAudio>1</isAudio><timeOut>30</timeOut><version>1.1.7.2</version><deviceIdx>0</deviceIdx><definitionAsk>15</definitionAsk><action>3</action><headLeft>16</headLeft><headRight>-16</headRight><headLow>-8</headLow><headHigh>8</headHigh><eyeDegree>27</eyeDegree><mouthDegree>27</mouthDegree><edage1>0.1</edage1><edage2>0.9</edage2><goodOne>0</goodOne></param>";
            result = control.openDevice(Param);
            bool right = IsRight(result);
            if (right)
            {
                control.getFaceB64A(IdCard, Serise, Param);
                control.GetImageEvent += GetImageEvent;
                isOpen = true;
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void GetImageEvent(object sender, AxcriterionLib._IstdfcectlEvents_GetImageEventEvent e)
        {
            string bmp = string.Empty;
            string result = control.GetImageData(0);
            bmp = GetImg64(result);
            string gray = string.Empty;
            result = control.GetImageData(1);
            gray = GetImg64(result);
            if (this.handler != null)
            {
                handler.Invoke(bmp, gray);
            }
        }

        bool IsRight(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var xes = doc.DocumentElement.SelectNodes("resultCode");
            string value = xes[0].InnerText;
            return "0".Equals(value.Trim());
        }

        string GetImg64(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                var xes = doc.DocumentElement.SelectNodes("imgBase");
                return xes[0].InnerText;
            }
            catch (Exception exception)
            {
                return string.Empty;
            }
        }
    }
}
