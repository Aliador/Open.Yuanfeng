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
    public class MinDeOprCmdClass : ILongView
    {
        private byte[] _openOperCmdStr = new byte[] { 0x03, 0x53, 0x80, 0xFF, 0x2A };
        private byte[] _closeOperCmdStr = new byte[] { 0x03, 0x45, 0x80, 0xFF, 0x38 };

        private bool isOpen = false;

        private SerialPort serialPort;
        SerialPortReceivedData serialPortReceivedData;
        public SerialPortReceivedDataDelegate serialPortReceivedDataDelegate;
        private string serialPortName = "COM1";
        private StringBuilder tempStrBuilder = new StringBuilder();
        private List<string> receivedResults = new List<string>();


        private bool live = false;
        private bool tryErrorType = false;
        private int tryCount = 5;
        private int totalTryCount = 20;

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
                if (this.serialPort == null || !this.serialPort.IsOpen)
                    throw new Exception("This serial port is not open.");

                this.serialPort.Write(_closeOperCmdStr, 0, 5);
                this.live = false;

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
            this.serialPortReceivedDataDelegate = serialPortReceivedDataDelegate;
            this.serialPortName = serialPortName;
            if (!this.serialPortName.ToLower().Contains("com"))
                throw new Exception("This port name is invalid.");

            if (this.serialPort != null && this.serialPort.IsOpen)
                throw new Exception("This serial port was using.");

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

                    if (tryErrorType)
                    {
                        if (tryCount == receivedResults.Count)
                        {
                            if (this.serialPortReceivedDataDelegate != null)this.serialPortReceivedDataDelegate.Invoke(serialPortReceivedData);
                        }
                        else
                        {
                            if (receivedResults.Count == 0)
                            {
                                receivedResults.Add(serialPortReceivedData.Data);
                            }
                            else if (!receivedResults.Contains(serialPortReceivedData.Data))
                            {
                                if (totalTryCount == 0)
                                {
                                    receivedResults.Clear(); totalTryCount = 20;
                                }
                            }
                            else
                            {
                                receivedResults.Add(serialPortReceivedData.Data);
                            }

                            totalTryCount -= 1;
                        }
                    }
                    else
                    {
                        if (this.serialPortReceivedDataDelegate != null) this.serialPortReceivedDataDelegate.Invoke(serialPortReceivedData);
                    }
                    if (this.live) { Open(); }
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
                    if (this.serialPort == null || !this.serialPort.IsOpen)
                        throw new Exception("This serial port is not open.");

                    this.serialPort.Write(_openOperCmdStr, 0, 5);

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
                if (this.serialPort == null || !this.serialPort.IsOpen)
                    throw new Exception("This serial port is not open.");

                this.serialPort.DataReceived -= new SerialDataReceivedEventHandler(SerialPortDataReceived);

                this.serialPortReceivedDataDelegate = null;

                this.serialPortReceivedData = null;

                this.serialPort.Write(_closeOperCmdStr, 0, 5);

                Thread.Sleep(100);

                this.serialPort.Close();

                this.isOpen = false; this.live = false;
                //throw new NotImplementedException();
            }
        }

        public void LiveScan()
        {
            this.live = true;
            Open();
        }

        public void TryErrorScan(int tryCount = 5)
        {
            this.tryErrorType = true;
            this.live = true;
            this.totalTryCount = 20;
            this.tryCount = tryCount;
            this.receivedResults.Clear();
            Open();
        }
    }
}
