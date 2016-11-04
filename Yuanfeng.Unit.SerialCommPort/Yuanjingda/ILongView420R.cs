using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.SerialCommPort.Yuanjingda
{
    public interface ILongView420R : ILongView
    {
        /// <summary>
        /// keep scan if no received data.
        /// </summary>
        void OpenOnLine();
    }
}
