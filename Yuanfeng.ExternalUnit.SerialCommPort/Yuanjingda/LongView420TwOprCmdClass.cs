using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using Yuanfeng.Smarty;

namespace Yuanfeng.ExternalUnit.SerialCommPort.Yuanjingda
{
    /// <summary>
    /// the implements width two cmd 1b30 & 1b31
    /// </summary>
    public class LongView420TwOprCmdClass : ILongView420R
    {
        string openOperCmdStr = "1b 31";
        string closeOperCmdStr = "1b 30";
        string openedPortName = string.Empty;
        SerialPortReceivedData serialPortReceivedData;
        public SerialPortReceivedDataDelegate serialPortReceivedDataDelegate;
        SerialPort serialPort;
        Timer threeSecondsOnce;
        bool received = false;
        bool scanHand = false;
        private bool isOpen = false;
        public bool IsOpen { get { return this.isOpen; } }
        private StringBuilder tempStrBuilder = new StringBuilder();
        public void Init(SerialPortReceivedDataDelegate serialPortReceivedDataDelegate)
        {
            this.openedPortName = "COM1";//set to default com port name.
            Init("COM1", serialPortReceivedDataDelegate);
        }

        public void Init(string serialPort, SerialPortReceivedDataDelegate serialPortReceivedDataDelegate)
        {
            try
            {
                this.openedPortName = serialPort;
                if (!this.openedPortName.ToLower().Contains("com")) throw new Exception("This port name is invalid.");
                this.serialPortReceivedDataDelegate = serialPortReceivedDataDelegate;

                if (this.serialPort != null && this.serialPort.IsOpen) throw new Exception("This serial port was using.");

                this.serialPort = new SerialPort();
                this.serialPort.BaudRate = 9600;
                this.serialPort.Encoding = Encoding.Unicode;
                this.serialPort.PortName = serialPort;
                this.serialPort.Open();
                this.serialPort.DataReceived += new SerialDataReceivedEventHandler(OnSerialPortDataReceived);
                this.serialPort.WriteTimeout = 200;
                this.serialPortReceivedData = new SerialPortReceivedData();

                threeSecondsOnce = new Timer(new TimerCallback((object obj) =>
                {
                    if (!received && scanHand) { Open(); }
                }), null, 0, 3000);

                this.isOpen = true;

            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception.Message);this.isOpen = false;
            }

            //throw new NotImplementedException();
        }

        private void OnSerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sender == null || !((SerialPort)sender).IsOpen) return;

            int bufferSize = ((SerialPort)sender).BytesToRead;
            //int indexOfZore = ((SerialPort)sender).ReadByte();
            if (bufferSize > 1)// && indexOfZore != 21)
            {
                string data = string.Empty;
                do
                {
                    byte[] dataBuffer = new byte[bufferSize];
                    ((SerialPort)sender).Read(dataBuffer, 0, bufferSize);
                    //dataBuffer[0] = (byte)indexOfZore;
                    data += Encoding.Default.GetString(dataBuffer);
                    this.received = true;
                    Thread.Sleep(100);
                    bufferSize = ((SerialPort)sender).BytesToRead;
                } while (bufferSize > 0);

                tempStrBuilder.Append(data);

                if (data.Contains("\r\n"))
                {
                    string resultCode = tempStrBuilder.ToString().Replace("\r\n", "");

                    tempStrBuilder.Clear();

                    if (this.serialPortReceivedData != null)
                    {
                        this.serialPortReceivedData.Data = resultCode;
                        this.serialPortReceivedData.Size = resultCode.Length;
                    }
                    if (this.serialPortReceivedDataDelegate != null) this.serialPortReceivedDataDelegate.Invoke(serialPortReceivedData);
                }
            }
            else
            {
                //this is cmd response
                if (serialPortReceivedData != null) serialPortReceivedData.IsOper = true;
                ((SerialPort)sender).DiscardInBuffer();
            }
            //throw new NotImplementedException();
        }

        public void Open()
        {
            if(isOpen)
            {
                try
                {
                    if (this.serialPort == null || !this.serialPort.IsOpen) throw new Exception("This serial port is not open.");

                    byte[] operBytes = HexStringToBytes(openOperCmdStr);
                    this.serialPort.Write(operBytes, 0, operBytes.Length);

                    Thread.Sleep(100);
                    //throw new NotImplementedException();
                }
                catch (Exception exception) { SimpleConsole.WriteLine("This serial port write exception."); SimpleConsole.WriteLine(exception); }
            }

        }

        public void Realase()
        {
            if(isOpen)
            {
                if (this.serialPort == null || !this.serialPort.IsOpen) throw new Exception("This serial port is not open.");

                this.serialPortReceivedDataDelegate = null;

                this.serialPortReceivedData = null;

                byte[] operBytes = HexStringToBytes(closeOperCmdStr);

                this.serialPort.Write(operBytes, 0, operBytes.Length);

                Thread.Sleep(100);

                this.serialPort.Close();

                this.isOpen = false;
                //throw new NotImplementedException();
            }

        }

        public void Close()
        {
            if(isOpen)
            {
                scanHand = false;

                if (this.serialPort == null || !this.serialPort.IsOpen) throw new Exception("This serial port is not open.");

                byte[] operBytes = HexStringToBytes(closeOperCmdStr);

                this.serialPort.Write(operBytes, 0, operBytes.Length);

                Thread.Sleep(100);
            }
           
        }

        public string ConvertHexArrToString(string strHex)
        {
            StringBuilder sb = new StringBuilder();
            string[] strArrHex = strHex.Split(' ');
            foreach (string item in strArrHex)
            {
                //将十六进制转换成10进制
                int ten = Convert.ToInt32(item, 16);
                char cc = (char)ten;
                sb.Append(cc);
            }
            string s = sb.ToString();
            return s;
        }

        public byte[] HexStringToBytes(string hs)
        {
            string[] strArr = hs.Trim().Split(' ');
            byte[] b = new byte[strArr.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < strArr.Length; i++)
            {
                b[i] = Convert.ToByte(strArr[i], 16);
            }
            //按照指定编码将字节数组变为字符串
            return b;
        }


        public void OpenOnLine()
        {
            if (isOpen)
            {
                if (threeSecondsOnce == null) throw new Exception("串口未初始化");
                scanHand = true; received = false;
                threeSecondsOnce.Change(0, 3000);
            }
        }

        public void LiveScan()
        {
            //throw new NotImplementedException();
        }
    }
}