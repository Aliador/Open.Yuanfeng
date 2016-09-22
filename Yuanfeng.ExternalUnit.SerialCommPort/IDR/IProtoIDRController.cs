using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.ExternalUnit.SerialCommPort.IDR
{
    public interface IProtoIDRController
    {
        /// <summary>
        /// 设备是否在使用
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// 异步读取身份证
        /// </summary>
        /// <param name="onReaded">读取成功之后掉用回调</param>
        /// <param name="channel">频道（设备索引）</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        int Scan(IDReadCompletedHandler completedHandler, int channel = 1001, int timeout = 30);

        /// <summary>
        /// 停止扫描
        /// </summary>
        /// <returns></returns>
        int Stop();
    }
}
