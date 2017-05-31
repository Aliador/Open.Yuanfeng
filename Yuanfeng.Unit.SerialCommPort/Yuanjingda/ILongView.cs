using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.SerialCommPort.Yuanjingda
{
    public interface ILongView
    {
        bool IsOpen { get; }
        /// <summary>
        /// init com port and if open with be close oper.
        /// </summary>
        /// <param name="serialPortReceivedDataDelegate">choose com port but the port is free because the process need open the port.</param>
        void Init(SerialPortReceivedDataDelegate serialPortReceivedDataDelegate);

        /// <summary>
        /// init com port and if open with be close oper.
        /// </summary>
        /// <param name="serialPortName">choose com port but the port is free because the process need open the port.</param>
        /// <param name="serialPortReceivedDataDelegate">on receied data action</param>
        void Init(string serialPortName, SerialPortReceivedDataDelegate serialPortReceivedDataDelegate);
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
        /// 保持扫描状态，在扫描到数据后重新打开。
        /// </summary>
        void LiveScan();


    }
}
