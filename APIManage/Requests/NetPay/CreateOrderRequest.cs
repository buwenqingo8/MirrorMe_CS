using APIManage.Responses;
using System.Collections.Generic;
using Util;

namespace APIManage.Requests
{
    public class CreateOrderRequest : RequestBase<CreateOrderResponse>, IRequest<CreateOrderResponse>
    {
        #region param_new
        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// 支付方式的编号
        /// </summary>
        public string PayTypeNo { get; set; }
        #endregion

        #region base
        public RequestType Type
        {
            get { return RequestType.Post; }
        }

        public string GetReqUrl
        {
            get { return "http://cloud.blibao.com/server/ajax/query/createOrder.htm"; }
        }

        public IDictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("shopperId", SysAPIGlobal.App.ParentShopId);
            dic.Add("machineId", SysAPIGlobal.App.MachineId);
            dic.Add("totalPrice", this.Amount);
            dic.Add("payModel", PayTypeNo);
            return dic;
        }

        public void Validate()
        {

        }

        public CreateOrderResponse ParseHtmlToResponse(string body)
        {
            CreateOrderResponse response = new CreateOrderResponse();
            response.Body = body;

            response.OrderNo = JsonTools.GetJosnValue(body, "orderNum");
            if (string.IsNullOrEmpty(response.OrderNo))
            {
                response.ErrInfo = new Domain.ErrInfo()
                {
                    ErrMsg = "创建订单失败",
                    ExMsg = JsonTools.GetJosnValue(body, "Exception")
                };
            }
            return response;
        }
        #endregion
    }
}
