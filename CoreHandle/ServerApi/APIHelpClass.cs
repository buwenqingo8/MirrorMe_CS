using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace CoreHandle
{
  public  class APIHelpClass
    {
        /// <summary>
        /// ajax请求公共方法
        /// </summary>
        /// <param name="ajax"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string WebClientFunction(string ajax, string param)
        {
            try
            {
                //WebClient client = new WebClient();
                WebDownload client = new WebDownload();
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] postdata = Encoding.UTF8.GetBytes(param);
                Byte[] pageData = client.UploadData(ajax, "POST", postdata);
                String resultHtm = Encoding.UTF8.GetString(pageData);
                return Encoding.UTF8.GetString(pageData);
            }
            catch { return ""; }
        }

        public class WebDownload : WebClient
        {
            private int _timeout;
            /// <summary>
            /// 超时时间(毫秒)
            /// </summary>
            public int Timeout
            {
                get
                {
                    return _timeout;
                }
                set
                {
                    _timeout = value;
                }
            }

            public WebDownload()
            {
                this._timeout = 60000;
            }

            public WebDownload(int timeout)
            {
                this._timeout = timeout;
            }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var result = base.GetWebRequest(address);
                result.Timeout = this._timeout;
                return result;
            }
        }
    }
}
