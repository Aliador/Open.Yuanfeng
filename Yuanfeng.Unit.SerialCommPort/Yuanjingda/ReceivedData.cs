using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.SerialCommPort.Yuanjingda
{
    public delegate void SerialPortReceivedDataDelegate(SerialPortReceivedData serialPortReceivedData);
    public class SerialPortReceivedData
    {
        /// <summary>
        /// this cur oper cmd.
        /// </summary>
        public int Cmd { get; set; }

        /// <summary>
        /// this is received data string.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// this data is cmd response.
        /// </summary>
        public bool IsOper { get; set; }

        /// <summary>
        /// this received data length.
        /// </summary>
        public int Size { get; set; }
    }
}
