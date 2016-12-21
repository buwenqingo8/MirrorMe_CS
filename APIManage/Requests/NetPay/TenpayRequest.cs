using APIManage.Responses;
using System.Collections.Generic;
using Util;

namespace APIManage.Requests
{
    public class TenpayRequest : RequestBase<TenpayResponse>, IRequest<TenpayResponse>
    {
        #region param_new
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// 支付码
        /// </summary>
        public string PayCode { get; set; }
        #endregion

        #region base
        public RequestType Type
        {
            get { return RequestType.Post; }
        }

        public string GetReqUrl
        {
            get { return "http://pay.blibao.com/tenpay_service/ajax/payByTenpay.htm"; }
        }

        public IDictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("goodsDesc", SysAPIGlobal.App.ShopName + " 消费");
            dic.Add("totalPrice", Amount);
            dic.Add("orderNum", OrderNo);
            dic.Add("authCode", PayCode);
            dic.Add("shopperId", SysAPIGlobal.App.ShopId);
            dic.Add("machineId", SysAPIGlobal.App.MachineId);
            return dic;
        }

        public void Validate()
        {

        }

        /* json字符串
        {"result": {"buyerUserId": "910047214386761536","tradeNo": "1900000109201510226051880604","partner": "1900000109"},"resultCode": "TRADE_SUCCESS","micropayAccount": "1900000109"}
        */
        public TenpayResponse ParseHtmlToResponse(string body)
        {
            TenpayResponse response = new TenpayResponse();
            response.Body = body;

            if (JsonTools.GetJosnValue(body, "success").ToLower() == "true")
            {
                response.BuyerUid = JsonTools.GetJosnValue(body, "buyerUserId");
                response.TradeNo = JsonTools.GetJosnValue(body, "tradeNo");
                response.Partner = JsonTools.GetJosnValue(body, "partner");
            }
            else
            {
                response.ErrInfo = new Domain.ErrInfo()
                {
                    ErrMsg = JsonTools.GetJosnValue(body, "error"),
                    ErrCode = JsonTools.GetJosnValue(body, "resultCode"),
                    ExMsg = JsonTools.GetJosnValue(body, "Exception")
                };
            }
            return response;
        }
        #endregion
    }
}
