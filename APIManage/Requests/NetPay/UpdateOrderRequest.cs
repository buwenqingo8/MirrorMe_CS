using APIManage.Responses;
using System.Collections.Generic;
using Util;

namespace APIManage.Requests
{
    public class UpdateOrderRequest : RequestBase<UpdateOrderResponse>, IRequest<UpdateOrderResponse>
    {
        #region param_new
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 交易号
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 支付方式的编号
        /// </summary>
        public string PayTypeNo { get; set; }
        /// <summary>
        /// 消费者id
        /// </summary>
        public string BuyerUid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Partner { get; set; }
        #endregion

        #region base
        public RequestType Type
        {
            get { return RequestType.Post; }
        }

        public string GetReqUrl
        {
            get { return "http://cloud.blibao.com/server/ajax/query/updateOrder.htm"; }
        }

        public IDictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("orderNum", OrderNo);
            dic.Add("backPay", SysAPIGlobal.App.MachineId);
            dic.Add("tradeNo", TradeNo);
            dic.Add("userId", BuyerUid);
            dic.Add("payType", PayTypeNo);
            dic.Add("partnerId", Partner);
            dic.Add("backNoPay", "0.0");
            dic.Add("isPrint", "1");
            dic.Add("payTime", Tools.DateTimeStamp);
            return dic;
        }

        public void Validate()
        {

        }

        public UpdateOrderResponse ParseHtmlToResponse(string body)
        {
            UpdateOrderResponse response = new UpdateOrderResponse();
            response.Body = body;

            if (JsonTools.GetJosnValue(body, "result").ToLower() == "true")
            {
                response.OrderNo = JsonTools.GetJosnValue(body, "orderNum");
            }
            else
            {
                response.ErrInfo = new Domain.ErrInfo()
                {
                    ErrMsg = "订单更新失败",
                    ExMsg = JsonTools.GetJosnValue(body, "Exception")
                };
            }
            return response;
        }
        #endregion
    }
}
