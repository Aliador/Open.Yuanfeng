using System.Runtime.InteropServices;

namespace Yuanfeng.ExternalUnit.SerialCommPort.IDR
{
    public class ProtoController
    {
        /// <summary>
        /// 读取文件保存位置
        /// </summary>
        public const string Dir = @"lib\idr";
        
        [DllImport(@"lib\idr\termb.dll")]
        public static extern int InitComm(int Port);

        [DllImport(@"lib\idr\termb.dll")]
        public static extern int InitCommExt();

        [DllImport(@"lib\idr\termb.dll")]
        public static extern int CloseComm();

        [DllImport(@"lib\idr\termb.dll")]
        public static extern int Authenticate();

        [DllImport(@"lib\idr\termb.dll")]
        public static extern string GetSAMID();

        [DllImport(@"lib\idr\termb.dll")]
        public static extern int Read_Content(int Active);

        [DllImport(@"lib\idr\termb.dll")]
        public static extern int Read_Content_Path(string cPath, int Active);
    }
}
