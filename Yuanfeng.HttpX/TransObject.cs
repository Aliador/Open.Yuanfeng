namespace Yuanfeng.HttpX
{
    public class TransObject
    {
        public TransObject()
        {

        }
        public TransObject(bool right, string msg, int code)
        {
            this.Right = right; this.Msg = msg; this.ErrorCode = code;
        }

        public TransObject(bool right, string msg, string value, int code)
        {
            this.Right = right; this.Msg = msg; this.Value = value; this.ErrorCode = code;
        }
        /// <summary>
        /// 结果成功
        /// </summary>
        public bool Right { get; set; }

        /// <summary>
        /// 消息（如果失败，则是错误消息）
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 请求结果，结果可能加密过。须调用默认密钥进行解密。
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 错误代码（仅在Right=false时可用）
        /// </summary>
        public int ErrorCode { get; set; }
    }
}
