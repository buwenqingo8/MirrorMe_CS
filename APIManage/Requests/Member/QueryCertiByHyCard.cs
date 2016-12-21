using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace APIManage
{
    public class QueryCertiByHyCard
    {
        public List<CardJson> getQueryCertiByHyCard(string aa)
        {
            string CardFaceNo = "";
            WebReference1.QueryCertiByHyCard qcbc = new WebReference1.QueryCertiByHyCard();
         //   string aa = "18258224035";
            PosExistMemberInfo posExi = new PosExistMemberInfo();
            MemberVO memberVO = new MemberVO();
            memberVO.phone = aa;
            string mebxml = posExi.getPosExistMemberInfo(memberVO);
            if (!string.IsNullOrEmpty(mebxml))
            {
                XmlDocument xmldoc1 = new XmlDocument();

                xmldoc1.LoadXml(mebxml);
                CardFaceNo = xmldoc1.SelectSingleNode("//CardFaceNo[last()]").InnerText.ToString();
            }
            string cc = qcbc.QueryCertiByHyCardFunc(CardFaceNo);

           return JsonToList(cc);

        }

        List<CardJson> JsonToList(string jsonString)
        {

            string inputJsonString = jsonString;
            JArray jsonObj = JArray.Parse(inputJsonString);
            JObject obj;

            List<CardJson> list = new List<CardJson>();
           

            for (int i = 0; i < jsonObj.Count; i++)
            {

               
                CardJson cardJson = new CardJson();
             
                cardJson.CARDHYNO = jsonObj[i]["CARDHYNO"] == null ? string.Empty : jsonObj[i]["CARDHYNO"].ToString();
                cardJson.CERTIME = jsonObj[i]["CERTIME"] == null ? string.Empty : jsonObj[i]["CERTIME"].ToString();
                cardJson.CERTINAME = jsonObj[i]["CERTINAME"] == null ? string.Empty : jsonObj[i]["CERTINAME"].ToString();
                cardJson.CERTINO = jsonObj[i]["CERTINO"] == null ? string.Empty : jsonObj[i]["CERTINO"].ToString();
                cardJson.CHECKCODE = jsonObj[i]["CHECKCODE"] == null ? string.Empty : jsonObj[i]["CHECKCODE"].ToString();
                cardJson.CXBILLNO = jsonObj[i]["CXBILLNO"] == null ? string.Empty : jsonObj[i]["CXBILLNO"].ToString();
                cardJson.CXREMARK = jsonObj[i]["CXREMARK"] == null ? string.Empty : jsonObj[i]["CXREMARK"].ToString();
                cardJson.Result = jsonObj[i]["Result"] == null ? string.Empty : jsonObj[i]["Result"].ToString();
                cardJson.USBGNDATE = jsonObj[i]["USBGNDATE"] == null ? string.Empty : jsonObj[i]["USBGNDATE"].ToString();
                cardJson.USENDDATE = jsonObj[i]["USENDDATE"] == null ? string.Empty : jsonObj[i]["USENDDATE"].ToString();
                cardJson.USETOTAL = jsonObj[i]["USETOTAL"] == null ? string.Empty : jsonObj[i]["USETOTAL"].ToString();
                cardJson.WEIXININFO = jsonObj[i]["WEIXININFO"] == null ? string.Empty : jsonObj[i]["WEIXININFO"].ToString();
                list.Add(cardJson);
            }

            return list;
        }


    
    }


}
