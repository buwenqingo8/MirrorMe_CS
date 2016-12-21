using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIManage.Responses;
using Util;

namespace APIManage.Requests
{
    /// <summary>
    /// 公告接口信息
    /// </summary>
    public class NoticesRequest : RequestBase<NoticesResponse>, IRequest<NoticesResponse>
    {
        #region param_new
        /// <summary>
        /// 公告类型（1：大屏   2：滚动）
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 消息推送( 1前端 2简易付 3会员app  4 会员pc 5供应商平台 6服务商平台 7普通商家平台 8广告平台 9系统管理)
        /// </summary>
        public string noticePush { get; set; }
        /// <summary>
        /// 所属城市（用城市简码 如：hangzhou）默认表示查询杭州
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 查询公告数量 默认查询一条
        /// </summary>
        public string size { get; set; }

        #endregion

        #region base
        public RequestType Type
        {
            get { return RequestType.Post; }
        }

        //public string GetReqUrl
        //{
        //    get { return  "http://192.168.1.10/server/ajax/noticesByParam.htm"; }

        //}
        public string GetReqUrl { get; set; }

        public IDictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("type", type);
            dic.Add("noticePush", noticePush);
            dic.Add("city", city);
            dic.Add("size", size);
            return dic;
        }

        public void Validate()
        {

        }

        public NoticesResponse ParseHtmlToResponse(string body)
        {
            NoticesResponse response = new NoticesResponse();
            response.Body = body;
            if (JsonTools.GetJosnValue(body, "success") == "true")
            {
                response.NoticeInfoP = Newtonsoft.Json.JsonConvert.DeserializeObject<APIManage.Responses.NoticesResponse.NoticeInfo>(response.Body);
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

        #endregion

    }
}
