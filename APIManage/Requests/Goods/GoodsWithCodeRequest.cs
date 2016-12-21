using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIManage.Responses;

namespace APIManage.Requests
{
    /// <summary>
    /// 获取店铺商品
    /// </summary>
    class GoodsWithCodeRequest : RequestBase<GoodsWithCodeResponse>, IRequest<GoodsWithCodeResponse>
    {
        #region param_new
        public string LoginId { get; set; }

        #endregion

        #region base
        public RequestType Type
        {
            get { return RequestType.Post; }
        }

        public string GetReqUrl
        {
            get { return "http://cloud.blibao.com/server/ajax/query/myGoodsWithCode.htm"; }
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

        public GoodsWithCodeResponse ParseHtmlToResponse(string body)
        {
            GoodsWithCodeResponse response = new GoodsWithCodeResponse();
            response.Body = body;

            return response;
        }

        #endregion

    }
}
