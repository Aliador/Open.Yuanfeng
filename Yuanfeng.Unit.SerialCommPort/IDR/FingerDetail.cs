using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.Unit.SerialCommPort.IDR
{
    public class FingerDetail
    {
        public FingerDetail()
        {
            FingerPosCode = 0;
            FingerPosName = "空";
        }
        public int FingerFileHeader { get; set; }

        public int FingerAlgoVersion { get; set; }

        public int FingerCollectorCode { get; set; }

        public int FingerAlgoDevelopCode { get; set; }

        public int FingerRegistResult { get; set; }

        /// <summary>
        /// 指位代码
        /// </summary>
        public int FingerPosCode { get; set; }

        /// <summary>
        /// 指位名称
        /// </summary>
        public string FingerPosName { get; set; }

        /// <summary>
        /// 指纹图像质量
        /// </summary>
        public int FingerPrintQlty { get; set; }

        public float FingerCharacterCount { get; set; }

        public long FingerCharacterDateLength { get; set; }

        /// <summary>
        /// 指纹中心数据
        /// </summary>
        public byte[] FingerCenterData { get; set; }

        public byte[] FingerCharacterDetailData { get; set; }

    }
}
