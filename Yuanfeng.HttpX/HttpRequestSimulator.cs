using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Yuanfeng.Smarty;

namespace Yuanfeng.HttpX
{
    public class HttpHeader
    {
        public string ContentType { get; set; }

        public string Accept { get; set; }

        public string UserAgent { get; set; }

        public string Method { get; set; }

        public int MaxTry { get; set; }
    }

    /// <summary>
    /// HTTP
    /// </summary>
    public class HttpRequestSimulator
    {
        private string CookiesString;
        private CookieContainer CookieContainer;


        public string RequestUrl(string requestUri, HttpHeader header)
        {
            HttpWebRequest httpWebRequest = null;
            HttpWebResponse httpWebResponse = null;
            try
            {
                if (this.CookieContainer == null) this.CookieContainer = new CookieContainer();

                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(requestUri);
                httpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                httpWebRequest.CookieContainer = this.CookieContainer;
                httpWebRequest.ContentType = header.ContentType;
                httpWebRequest.ServicePoint.ConnectionLimit = header.MaxTry;
                httpWebRequest.AllowAutoRedirect = false;
                httpWebRequest.Accept = header.Accept;
                httpWebRequest.UserAgent = header.UserAgent;
                httpWebRequest.Method = header.Method;
                httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
                string html = streamReader.ReadToEnd();
                streamReader.Close();
                responseStream.Close();
                httpWebRequest.Abort();
                httpWebResponse.Close();
                return html;
            }
            catch (Exception exception)
            {
                SimpleConsole.WriteLine(exception);
                if (httpWebRequest != null) httpWebRequest.Abort();
                if (httpWebResponse != null) httpWebResponse.Close();
                return string.Empty;
            }
        }

    }
}
