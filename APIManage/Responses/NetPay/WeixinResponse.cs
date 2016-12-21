using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIManage.Responses
{
    public class WeixinResponse : Response
    {
        public string BuyerUid { get; set; }
        public string TradeNo { get; set; }
        public string Partner { get; set; }
    }
}
