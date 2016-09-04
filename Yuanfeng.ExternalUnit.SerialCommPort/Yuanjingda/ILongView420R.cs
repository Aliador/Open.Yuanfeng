using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.ExternalUnit.SerialCommPort.Yuanjingda
{
    public interface ILongView420R
    {
        /// <summary>
        /// init com port and if open with be close oper.
        /// </summary>
        /// <param name="serialPort">choose com port but the port is free because the process need open the port.</param>
        void Init(SerialPortReceivedDataDelegate serialPortReceivedData);

        /// <summary>
        /// init com port and if open with be close oper.
        /// </summary>
        /// <param name="serialPort">choose com port but the port is free because the process need open the port.</param>
        /// <param name="serialPortReceiedData">on receied data action</param>
        void Init(string serialPort, SerialPortReceivedDataDelegate serialPortReceiedData);
        /// <summary>
        /// realase com port and stop receive data.
        /// </summary>
        void Realase();

        /// <summary>
        /// open light scan br or qr code.
        /// </summary>
        void Open();

        /// <summary>
        /// close light and stop scan.
        /// </summary>
        void Close();

        /// <summary>
        /// keep scan if no received data.
        /// </summary>
        void OpenOnLine();
    }
}
