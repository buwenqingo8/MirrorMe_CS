using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace APIManage
{
    [DataContract]
   public  class CardJson
    {
//        Result  查询结果，1为正确
//CERTINO  赠券号
//CHECKCODE  校验码
//CERTIME   面额，折扣券时为折数，金额券时为面额
//CXBILLNO  促销单号
//USBGNDATE  有效期开始日
//USENDDATE  有效期截止日
//USETOTAL  已用金额
//CXREMARK  促销说明，可在促销单中设置
//CARDHYNO  会员卡号
//WEIXININFO   会员微信OPENID
//CERTINAME   赠券名称，可在促销单中设置
        //public CardJson(int id, string name, int age)
        //{
        //    Id = id;
        //    Name = name;
        //    Age = age;
        //}
        [DataMember]            //对方法2要设置成员属性
        public string Result
        {
            get;
            set;
        }
        [DataMember]
        public string CERTINO
        {
            get;
            set;
        }
        [DataMember]
        public string CHECKCODE
        {
            get;
            set;
        }
         [DataMember]            //对方法2要设置成员属性
        public string CERTIME
        {
            get;
            set;
        }
        [DataMember]
        public string CXBILLNO
        {
            get;
            set;
        }
        [DataMember]
        public string USBGNDATE
        {
            get;
            set;
        }
         [DataMember]            //对方法2要设置成员属性
        public string USENDDATE
        {
            get;
            set;
        }
        [DataMember]
        public string USETOTAL
        {
            get;
            set;
        }
        [DataMember]
        public string CXREMARK
        {
            get;
            set;
        }

          [DataMember]            //对方法2要设置成员属性
        public string CARDHYNO
        {
            get;
            set;
        }
        [DataMember]
        public string WEIXININFO
        {
            get;
            set;
        }
        [DataMember]
        public string CERTINAME
        {
            get;
            set;
        }
    }
}
