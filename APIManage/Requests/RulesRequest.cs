using APIManage.Responses;
using System.Collections.Generic;

namespace APIManage.Requests
{
    public class RulesRequest : RequestBase<RulesResponse>, IRequest<RulesResponse>
    {
        #region base
        public RequestType Type
        {
            get { return RequestType.Post; }
        }

        public string GetReqUrl
        {
            get { return "http://cloud.blibao.com/server/ajax/query/promotionRule.htm?"; }
        }

        public IDictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("shopperId", SysAPIGlobal.App.ParentShopId);
            dic.Add("machineId", SysAPIGlobal.App.MachineId);
            return dic;
        }

        public void Validate()
        {

        }


        public RulesResponse ParseHtmlToResponse(string body)
        {
            RulesResponse response = new RulesResponse();
            response.Body = body;
            return response;
        }
        #endregion
    }
}
