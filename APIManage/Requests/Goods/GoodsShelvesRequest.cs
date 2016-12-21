using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIManage.Responses;

namespace APIManage.Requests
{
    public class GoodsShelvesRequest : RequestBase<GoodsShelvesResponse>, IRequest<GoodsShelvesResponse>
    {        
        #region param_new
        /// <summary>
        /// 用户名
        /// </summary>
        public string LoginId { get; set; }
        #endregion

        #region base
        public RequestType Type
        {
            get { return RequestType.Post; }
        }

        public string GetReqUrl
        {
            get { return "http://cloud.blibao.com/server/ajax/query/shelvesGoods.htm"; }
        }

        public IDictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("shopperId", LoginId);
            return dic;
        }

        public void Validate()
        {

        }

        public GoodsShelvesResponse ParseHtmlToResponse(string body)
        {
            GoodsShelvesResponse response = new GoodsShelvesResponse();
            response.Body = body;

            return response;
        }

        #endregion



    }
}
