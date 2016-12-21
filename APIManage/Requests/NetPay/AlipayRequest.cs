using APIManage.Responses;

using System.Collections.Generic;
using Util;

namespace APIManage.Requests
{
    public class AlipayRequest : RequestBase<AlipayResponse>, IRequest<AlipayResponse>
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
            get { return "http://cloud.blibao.com/server/ajax/query/payByBaifubao.htm"; }
        }
        //http://cloud.blibao.com/server/ajax/query/payByBaifubao.htm

        public IDictionary<string, string> GetParameters()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("WIDout_trade_no", OrderNo);
            dic.Add("machineId", SysAPIGlobal.App.MachineId);
            dic.Add("WIDsubject", SysAPIGlobal.App.ShopName);
            dic.Add("WIDtotal_fee", Amount);
            dic.Add("WIDproduct_code", "BARCODE_PAY_OFFLINE");
            dic.Add("WIDdynamic_id_type", "barcode");
            dic.Add("WIDdynamic_id", PayCode);
            return dic;
        }

        public void Validate()
        {

        }

        public AlipayResponse ParseHtmlToResponse(string body)
        {
            AlipayResponse response = new AlipayResponse();
            response.Body = body;

            if (JsonTools.GetJosnValue(body, "resultCode") == "TRADE_SUCCESS")
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
