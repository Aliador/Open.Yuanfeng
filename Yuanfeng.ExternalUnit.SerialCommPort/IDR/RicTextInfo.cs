using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yuanfeng.ExternalUnit.SerialCommPort.IDR
{
    public class RicTextInfo
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Ethnicity { get; set; }

        /// <summary>
        /// 民族代码
        /// </summary>
        public string EthnicityCode { get; set; }

        /// <summary>
        /// 签发机关
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// 有效期限
        /// </summary>
        public string ValidThrough { get { return AuthortityDate + "至" + ExpireDate; } }

        /// <summary>
        /// 有效期开始
        /// </summary>
        public string AuthortityDate { get; set; }

        /// <summary>
        /// 有效期截止
        /// </summary>
        public string ExpireDate { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birth { get; set; }

        /// <summary>
        /// 公民身份证号码
        /// </summary>
        public string CitizenIDNumber { get; set; }

        /// <summary>
        /// 居住地址
        /// </summary>
        public string DwellingPlace { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 性别代码
        /// </summary>
        public string SexCode { get; set; }

        /// <summary>
        /// 是否含有指纹数据
        /// </summary>
        public bool IncludeFinger { get; set; }

        /// <summary>
        /// 指纹特征数据（0-指纹指位 后512字节为特征数据 513-指纹指位后512字节为指纹特征数据 ）
        /// </summary>
        public byte[] FingerBuffer { get; set; }

        /// <summary>
        /// 身份证照片
        /// </summary>
        public byte[] Photo { get; set; }

        public override string ToString()
        {
            StringBuilder line = new StringBuilder();
            line.AppendLine("姓名：" + Name);
            line.AppendLine("民族：" + Ethnicity);
            line.AppendLine("民族代码：" + EthnicityCode);
            line.AppendLine("性别：" + Sex);
            line.AppendLine("性别代码：" + SexCode);
            line.AppendLine("身份证号码：" + CitizenIDNumber);
            line.AppendLine("地址：" + DwellingPlace);
            line.AppendLine("签发机关：" + Authority);
            line.AppendLine("有效期限：" + ValidThrough);
            line.AppendLine("有效期始：" + AuthortityDate);
            line.AppendLine("有效期至：" + ExpireDate);
            line.AppendLine("证件照片：" + (Photo != null ? "有" : "无"));
            line.AppendLine("是否含指纹：" + IncludeFinger);
            if (IncludeFinger)
                line.AppendLine("指纹数据：" + Convert.ToBase64String(FingerBuffer));
            return line.ToString();
        }
    }
}
