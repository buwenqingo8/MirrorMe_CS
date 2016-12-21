using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIManage
{
    public class MemberVOXML
    {
        public String idx { get; set; }

        /** MEM_NAME */
        public String VIPName { get; set; }

        /** MEM_ID */
        public String memId { get; set; }

        /** PASSWD */
        public String passwd { get; set; }

        public String newPasswd { get; set; }



        /** PHONE */
        public String phone { get; set; }

        /** SNS_TYPE */
        public String snsType { get; set; }

        /** SNS_ID */
        public String snsId { get; set; }

        /** EMAIL */
        public String email { get; set; }

        /** LOGIN_DT */
        public String loginDt { get; set; }

        /** GRADE */
        public String grade { get; set; }

        /** DEL_YN */
        public String delYn { get; set; }

        /** TOTAL_POINT */
        public String totalPoint { get; set; }

        /** REG_DT */
        public String regDt { get; set; }

        /** REG_ID */
        public String regId { get; set; }

        /** UDT_DT */
        public String udtDt { get; set; }

        /** UDT_ID */
        public String udtId { get; set; }

        public String cetiKey { get; set; }

        public String dt { get; set; }

        public String referer { get; set; }
        public String r { get; set; }
        public String imgUrl { get; set; }
        public String contents { get; set; }

        public String Gender { get; set; }
        public String Birthday { get; set; }

        public String posCardNo { get; set; }

        public String CardTypeCode { get; set; }
        public String CardTypeName { get; set; }
        public String posVipCardNo { get; set; }
        public String posBillNo { get; set; }
        public String posBalance { get; set; }

        public String CardFaceNo { get; set; }

        public String device { get; set; }

        public String result { get; set; }

        public String SumJfTotal { get; set; }

    }
}
