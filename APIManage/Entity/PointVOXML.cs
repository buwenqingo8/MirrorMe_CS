using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIManage
{
//    <?xml version="1.0" encoding="UTF-8"?>
//<OutputParameter>    
//<Data>
//<QueryNum>符合条件的总记录数</QueryNum>   
//<ROW>
//<OrgCode >组织编码</ OrgCode >
//<OrgName >组织名称</ OrgName >
//< PrjCode >会员活动编码</ PrjCode >
//< PrjName >会员活动名称</ PrjName >
//< CardNo >会员卡面号</ CardNo >
//< SaleNo >销售流水号</ SaleNo >
//< SsTotal >积分销售金额</ SsTotal >
//< JfTotal >本笔积分</ JfTotal >
//< BillType >单据类型</ BillType >
//< JzDate>记账日期</ JzDate>
//< JzTime>记账时间</ JzTime>
//</ROW>
//</Data>
//</OutputParameter>

    [Serializable]
  public   class PointVOXML
    {
    public   string QueryNum { get; set; }
    public string OrgCdoe { get; set; }
    public string OrgName { get; set; }
    public string PrjCode { get; set; }
    public string PrjName { get; set; }
    public string CardNo { get; set; }
    public string SaleNo { get; set; }
    public string SsTotal { get; set; }
    public string JfTotal { get; set; }
    public string BillType { get; set; }
    public string JzDate { get; set; }
    public string JzTime { get; set; }

    }
}
