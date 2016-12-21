using APIManage.Domain;
using APIManage.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace APIManage.Requests
{
    public class LoginRequest : RequestBase<LoginResponse>, IRequest<LoginResponse>
    {
        #region param_new
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        #endregion

        #region base
        public RequestType Type
        {
            get { return RequestType.Post; }
        }

        public string GetReqUrl
        {
            get { return "http://cloud.blibao.com/server/ajax/query/plugLogin.htm"; }
        }

        public IDictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", UserName);
            dic.Add("password", Password);

            StringBuilder sparam = new StringBuilder();
            sparam.Append(string.Format("username={0}", UserName));
            sparam.Append(string.Format("&password={0}", Password));
            sparam.Append(string.Format(GetApiVer("v1.0")));
            string sparamSort = SortPostData(sparam.ToString());
            string timeStamp = Tools.DateTimeStamp;

            dic.Add("timestamp", timeStamp);
            dic.Add("sb", ConvertToSHA1(sparamSort + timeStamp));
            return dic;
        }

        public void Validate()
        {

        }

        public LoginResponse ParseHtmlToResponse(string body)
        {
            LoginResponse response = new LoginResponse();
            response.Body = body;

            if (JsonTools.GetJosnValue(body, "result_state") == "true")
            {
                response.AppInfo = new AppInfo();
                response.AppInfo.ParentShopId = JsonTools.GetJosnValue(body, "shopper_pid");
                response.AppInfo.ShopId = JsonTools.GetJosnValue(body, "shopper_id");
                response.AppInfo.MachineId = JsonTools.GetJosnValue(body, "machine_id");
                response.AppInfo.ShopName = JsonTools.GetJosnValue(body, "shop_name");
            }
            else
            {
                response.ErrInfo = new Domain.ErrInfo()
                {
                    ExMsg = JsonTools.GetJosnValue(body, "Exception")
                };
            }
            return response;
        }

        #region 扩展方法
        /// <summary>
        /// 获取接口版本号
        /// </summary>
        /// <param name="ver"></param>
        /// <returns></returns>
        public string GetApiVer(string ver)
        {
            if (string.IsNullOrEmpty(ver))
                return "";
            else
                return string.Format("&iv={0}&v={1}&osv={2}&otv={3}", ver, "1.0.0.0", "winxp", "32");
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="postStr"></param>
        /// <returns></returns>
        public string SortPostData(string param)
        {
            List<string> list = new List<string>();
            string[] array = param.Split('&');
            for (int i = 0; i < array.Length; i++)
            {
                string item = array[i];
                list.Add(item);
            }
            list.Sort((string x, string y) => string.Compare(x, y));
            string result = string.Empty;
            foreach (string current in list)
            {
                result = result + current + "&";
            }
            return result;
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public string CodeForParam(string param)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] array = param.Split('&');
            for (int i = 0; i < array.Length; i++)
            {
                string[] arr = array[i].Split('=');
                if (arr.Length == 2)
                {
                    dictionary.Add(arr[0], arr[1]);
                }
            }
            string result = string.Empty;
            foreach (KeyValuePair<string, string> current in dictionary)
            {
                result = result + current.Key + "=" + UrlEncode(current.Value) + "&";
            }
            return result.Trim('&');
        }

        /// <summary>
        /// 哈希码加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public string ConvertToSHA1(string txt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(txt);
            byte[] value = System.Security.Cryptography.SHA1.Create().ComputeHash(bytes);
            return BitConverter.ToString(value).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 地址编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string UrlEncode(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            for (int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append("%" + Convert.ToString(bytes[i], 16));
            }
            return stringBuilder.ToString();
        }
        #endregion
        #endregion
    }
}
