using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.SerialCommPort.IDR
{
    public enum FingerPositionItem
    {
        /// <summary>
        /// 拇指
        /// </summary>
        Thumb = 1,
        /// <summary>
        /// 食指
        /// </summary>
        ForeFinger = 2,
        /// <summary>
        /// 中指
        /// </summary>
        MiddleFinger = 3,
        /// <summary>
        /// 环指
        /// </summary>
        RingFinger = 4,
        /// <summary>
        /// 小指
        /// </summary>
        LittleFinger = 5
    }

    public enum HandTypeItem
    {
        /// <summary>
        /// 左手
        /// </summary>
        Left = 15,
        /// <summary>
        /// 右手
        /// </summary>
        Right = 10
    }
}
