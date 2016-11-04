using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Yuanfeng.Smarty;

namespace Yuanfeng.Unit.SerialCommPort.Yuanjingda
{
    public class LongView100TwOprCmdClass : ILongView
    {
        private string _openOperCmdStr = "$$$$#99900116;%%%%$$$$#99900035;%%%%";
        private string _closeOperCmdStr = "$$$$#99900116;%%%%$$$$#99900036;%%%%";

        private bool isOpen = false;

        private SerialPort serialPort;
        SerialPortReceivedData serialPortReceivedData;
        public SerialPortReceivedDataDelegate serialPortReceivedDataDelegate;
        private string serialPortName = "COM1";
        private StringBuilder tempStrBuilder = new StringBuilder();

        private bool live = false;
        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        public void Close()
        {
            if (isOpen)
            {
                if (this.serialPort == null || !this.serialPort.IsOpen) throw new Exception("This serial port is not open.");

                this.serialPort.Write(_closeOperCmdStr); this.live = false;

                Thread.Sleep(100);
            }

        }

        public void Init(SerialPortReceivedDataDelegate serialPortReceivedDataDelegate)
        {
            this.serialPortName = "COM1";
            this.serialPortReceivedDataDelegate = serialPortReceivedDataDelegate;
            Init(serialPortName, serialPortReceivedDataDelegate);
        }

        public void Init(string serialPortName, SerialPortReceivedDataDelegate serialPortReceivedDataDelegate)
        {
            this.serialPortName = serialPortName;
            this.serialPortReceivedDataDelegate = serialPortReceivedDataDelegate;
            if (!this.serialPortName.ToLower().Contains("com")) throw new Exception("This port name is invalid.");

            this.serialPortReceivedDataDelegate = serialPortReceivedDataDelegate;

            if (this.serialPort != null && this.serialPort.IsOpen) throw new Exception("This serial port was using.");

            this.serialPort = new SerialPort();
            this.serialPort.PortName = serialPortName;
            this.serialPort.BaudRate = 9600;
            this.serialPort.WriteTimeout = 200;
            this.serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
            this.serialPortReceivedData = new SerialPortReceivedData();
            this.serialPort.Open();
            this.isOpen = true;
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sender == null || !((SerialPort)sender).IsOpen) return;

            int bufferSize = ((SerialPort)sender).BytesToRead;
            //int indexOfZore = ((SerialPort)sender).ReadByte();
            if (bufferSize >= 1)// && indexOfZore != 21)
            {
                string data = string.Empty;
                do
                {
                    try
                    {
                        byte[] dataBuffer = new byte[bufferSize];
                        ((SerialPort)sender).Read(dataBuffer, 0, bufferSize);
                        //dataBuffer[0] = (byte)indexOfZore;
                        data += Encoding.Default.GetString(dataBuffer);
                        Thread.Sleep(100);
                        bufferSize = ((SerialPort)sender).BytesToRead;
                    }
                    catch { bufferSize = 0; }
                } while (bufferSize > 0 && sender != null && ((SerialPort)sender).IsOpen);

                tempStrBuilder.Append(data);

                if (data.Contains("\r\n"))
                {
                    string resultCode = tempStrBuilder.ToString().Replace("\r\n", "");

                    Regex regex = new Regex(@"\*(?<code>.*?)\*");

                    var match = regex.Match(resultCode);
                    if (match.Success) resultCode = match.Groups["code"].Value;

                    tempStrBuilder.Clear();

                    if (this.serialPortReceivedData != null)
                    {
                        this.serialPortReceivedData.Data = resultCode;
                        this.serialPortReceivedData.Size = resultCode.Length;
                    }
                    if (this.serialPortReceivedDataDelegate != null) this.serialPortReceivedDataDelegate.Invoke(serialPortReceivedData);

                    if (this.live) Open();
                }
            }
            else
            {
                //this is cmd response
                if (serialPortReceivedData != null) serialPortReceivedData.IsOper = true;
                ((SerialPort)sender).DiscardInBuffer();
            }
        }

        public void Open()
        {
            if (isOpen)
            {
                try
                {
                    if (this.serialPort == null || !this.serialPort.IsOpen) throw new Exception("This serial port is not open.");

                    this.serialPort.Write(_openOperCmdStr);

                    Thread.Sleep(100);
                    //throw new NotImplementedException();
                }
                catch (Exception exception) { SimpleConsole.WriteLine("This serial port write exception."); SimpleConsole.WriteLine(exception); }
            }
        }

        public void Realase()
        {
            if (isOpen)
            {
                if (this.serialPort == null || !this.serialPort.IsOpen) throw new Exception("This serial port is not open.");

                this.serialPortReceivedDataDelegate = null;

                this.serialPortReceivedData = null;

                this.serialPort.Write(_closeOperCmdStr);

                Thread.Sleep(100);

                this.serialPort.Close();

                this.isOpen = false; this.live = false;
                //throw new NotImplementedException();
            }
        }

        public void LiveScan()
        {
            this.live = true; Open();
        }
    }
}
