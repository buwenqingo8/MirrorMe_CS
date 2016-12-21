using APIManage.Domain;
using APIManage.Responses;
using System.Collections.Generic;
using Util;

namespace APIManage.Requests
{
    public class WeixinRequest : RequestBase<WeixinResponse>, IRequest<WeixinResponse>
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
            get { return "http://pay.blibao.com/wechat_service/ajax/payByWeixin.htm"; }
        }

        public IDictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("body", SysAPIGlobal.App.ShopName + "消费");
            dic.Add("totalPrice", Amount);
            dic.Add("orderNum", OrderNo);
            dic.Add("authCode", PayCode);
            dic.Add("shopperId", SysAPIGlobal.App.ParentShopId);
            dic.Add("machineId", SysAPIGlobal.App.MachineId);
            return dic;
        }

        public void Validate()
        {

        }

        public WeixinResponse ParseHtmlToResponse(string body)
        {
            WeixinResponse response = new WeixinResponse();
            response.Body = body;

            if (JsonTools.GetJosnValue(body, "resultCode") == "TRADE_SUCCESS")
            {
                response.BuyerUid = JsonTools.GetJosnValue(body, "buyerUserId");
                response.TradeNo = JsonTools.GetJosnValue(body, "tradeNo");
                response.Partner = JsonTools.GetJosnValue(body, "partner");
            }
            else
            {
                response.ErrInfo = new ErrInfo()
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
