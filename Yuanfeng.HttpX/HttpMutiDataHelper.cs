using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;

namespace Yuanfeng.HttpX
{
    public class HttpMutiDataHelper
    {
        public string Request(Dictionary<string,object> param)
        {
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            using (HttpClient client = new HttpClient(handler))
            {

            }

            return "";
        }
    }
}
