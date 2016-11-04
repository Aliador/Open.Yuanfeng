using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.FaceFeatureCompare
{
    public interface IFaceFeatureContoller
    {
        bool IsInited { get; }

        /// <summary>
        /// 初始化（本函数只能初始化一次）
        /// </summary>
        /// <returns></returns>
        int Init();

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <returns></returns>
        int Release();

        /// <summary>
        /// 比对
        /// </summary>
        /// <param name="buffer1">图片1byte数组</param>
        /// <param name="buffer2">图片2byte数组</param>
        /// <returns></returns>
        float Compare(byte[] buffer1, byte[] buffer2);

        /// <summary>
        /// 比对
        /// </summary>
        /// <param name="img1">图片1路径</param>
        /// <param name="img2">图片2路径</param>
        /// <returns></returns>
        float Compare(string img1, string img2);
    }
}
