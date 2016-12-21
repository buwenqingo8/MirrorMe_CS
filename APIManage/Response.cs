using APIManage.Domain;
using System;
using Util;

namespace APIManage
{
    [Serializable]
    public class Response
    {
        private ErrInfo _errInfo = null;
        /// <summary>
        /// 错误信息
        /// </summary>
        public ErrInfo ErrInfo
        {
            get
            {
                string s = JsonTools.GetJosnValue(Body, "Exception");
                if (!string.IsNullOrEmpty(s))
                    if (_errInfo == null)
                        _errInfo = new ErrInfo();
                    else
                        _errInfo.ExMsg = s;
                return _errInfo;
            }
            set { _errInfo = value; }
        }

        /// <summary>
        /// 响应原始内容
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 请求Url
        /// </summary>
        public string ReqUrl { get; set; }

        /// <summary>
        /// 响应结果是否错误
        /// </summary>
        public bool IsError
        {
            get { return ErrInfo == null ? false : true; }
        }
    }
}
