using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Yuanfeng.Unit.FaceFeatureCompare
{
    public class TesoLiveReconitionContoller : ILiveFaceCompare
    {
        private string args;
        private LiveRecongtionCompletedHandler handler;
        private bool isOpen = false;
        public bool IsOpen { get { return isOpen; } }
        private AxcriterionLib.Axstdfcectl control = new AxcriterionLib.Axstdfcectl();
        public int Close()
        {
            if (isOpen)
            {
                string result = control.closeDevice();
                bool right = IsRight(result);
                if (right) isOpen = false; return right ? 1 : 0;
            }
            return 0;
        }

        public int Init(Control container, LiveRecongtionCompletedHandler handler)
        {
            if (container == null) throw new Exception("container参数为空");
            if (container.Controls.Count > 0) container.Controls.RemoveAt(0);
            control.Size = new System.Drawing.Size(640, 480);
            control.Location = new System.Drawing.Point(0, 0);
            container.Controls.Add(control);
            control.GetImageEvent += GetImageEvent;
            this.handler = handler;
            this.args = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n<param>\n    <imgWidth>640</imgWidth>\n    <imgHeight>480</imgHeight>\n    <imgCompress>85</imgCompress>\n    <pupilDistMin>0</pupilDistMin>\n    <pupilDistMax>150</pupilDistMax>\n    <isActived>2</isActived>\n    <isAudio>1</isAudio>\n    <timeOut>300</timeOut>\n    <version>1.1.7.2</version>\n    <deviceIdx>0</deviceIdx>\n    <definitionAsk>15</definitionAsk>\n    <action>3</action>\n    <headLeft>16</headLeft>\n    <headRight>-16</headRight>\n    <headLow>-8</headLow>\n    <headHigh>8</headHigh>\n    <eyeDegree>27</eyeDegree>\n    <mouthDegree>27</mouthDegree>\n    <edage1>0.1</edage1>\n    <edage2>0.9</edage2>\n    <goodOne>0</goodOne>\n</param>\n";
            return 1;
        }

        public int Init(Control container,string args, LiveRecongtionCompletedHandler handler)
        {
            if (container == null) throw new Exception("container参数为空");
            if (container.Controls.Count > 0) container.Controls.RemoveAt(0);
            control.Size = new System.Drawing.Size(640, 480);
            control.Location = new System.Drawing.Point(0, 0);
            container.Controls.Add(control);
            control.GetImageEvent += GetImageEvent;
            this.handler = handler;
            this.args = args;
            return 1;
        }

        public int Start()
        {
            if (isOpen) { Close(); }
            string result = string.Empty;
            var IdCard = "000000000000000000";
            var Serise = "000000000000000000000000000000";
            //string Param = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n<param>\n    <imgWidth>640</imgWidth>\n    <imgHeight>480</imgHeight>\n    <imgCompress>85</imgCompress>\n    <pupilDistMin>0</pupilDistMin>\n    <pupilDistMax>150</pupilDistMax>\n    <isActived>2</isActived>\n    <isAudio>1</isAudio>\n    <timeOut>30</timeOut>\n    <version>1.1.7.2</version>\n    <deviceIdx>0</deviceIdx>\n    <definitionAsk>15</definitionAsk>\n    <action>3</action>\n    <headLeft>16</headLeft>\n    <headRight>-16</headRight>\n    <headLow>-8</headLow>\n    <headHigh>8</headHigh>\n    <eyeDegree>27</eyeDegree>\n    <mouthDegree>27</mouthDegree>\n    <edage1>0.1</edage1>\n    <edage2>0.9</edage2>\n    <goodOne>0</goodOne>\n</param>\n";
            result = control.openDevice(args);
            result = control.getFaceB64A(IdCard, Serise, args);
            if (IsRight(result))
            {
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
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                var xes = doc.DocumentElement.SelectNodes("resultCode");
                string value = xes[0].InnerText;
                return "0".Equals(value.Trim());
            }
            catch { return false; }
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
            catch
            {
                return string.Empty;
            }
        }
    }
}
