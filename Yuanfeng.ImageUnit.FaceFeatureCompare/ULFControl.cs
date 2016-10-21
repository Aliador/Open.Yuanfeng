using System;
using System.Windows.Forms;
using System.Xml;

namespace Yuanfeng.ImageUnit.FaceFeatureCompare
{
    public partial class ULFControl : UserControl
    {
        private LFCompletedHandler handler;
        public ULFControl()
        {
            InitializeComponent();
        }

        public void Start(LFCompletedHandler handler)
        {
            string result;
            var IdCard = "000000000000000000";
            var Serise = "000000000000000000000000000000";
            string Param = "<? xml version =\"1.0\" encoding=\"utf-8\" ?><param><imgWidth>640</imgWidth><imgHeight>480</imgHeight><imgCompress>85</imgCompress><pupilDistMin>0</pupilDistMin><pupilDistMax>150</pupilDistMax><isActived>2</isActived><isAudio>1</isAudio><timeOut>30</timeOut><version>1.1.7.2</version><deviceIdx>0</deviceIdx><definitionAsk>15</definitionAsk><action>3</action><headLeft>16</headLeft><headRight>-16</headRight><headLow>-8</headLow><headHigh>8</headHigh><eyeDegree>27</eyeDegree><mouthDegree>27</mouthDegree><edage1>0.1</edage1><edage2>0.9</edage2><goodOne>0</goodOne></param>";
            result = axstdfcectl1.openDevice(Param);
            bool right = IsRight(result);
            if (right)
            {
                axstdfcectl1.getFaceB64A(IdCard, Serise, Param);
                axstdfcectl1.GetImageEvent += GetImageEvent;
            }
            this.handler = handler;
        }

        public void Close()
        {
            axstdfcectl1.closeDevice();
        }

        bool IsRight(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            var xes = doc.DocumentElement.SelectNodes("resultCode");
            string value = xes[0].InnerText;
            return "0".Equals(value.Trim());
        }
        private string GetImg64(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                var xes = doc.DocumentElement.SelectNodes("imgBase");
                return xes[0].InnerText;
            }
            catch
            {
                return string.Empty;
            }
        }
        private void GetImageEvent(object sender, AxcriterionLib._IstdfcectlEvents_GetImageEventEvent e)
        {
            string bmp = string.Empty;
            string result = axstdfcectl1.GetImageData(0);
            bmp = GetImg64(result);
            string gray = string.Empty;
            result = axstdfcectl1.GetImageData(1);
            gray = GetImg64(result);
            if (this.handler != null)
            {
                handler.Invoke(bmp, gray);
            }
        }
    }
}
