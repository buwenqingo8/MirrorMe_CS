using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Util;

namespace APIManage
{
    public static class PosPoint
    {
        static string jsonString = "";
        public static string getPosPoint(MemberVO memberVO, PointVO pointVO)
        {

            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(GetPublicKey.GetSysPath("XMLFile8.xml"));
            string ClientCode = xmldoc.SelectSingleNode("//ClientCode[last()]").InnerText.ToString();

            XmlDocument xmldoc2 = new XmlDocument();
            xmldoc2.Load(GetPublicKey.GetSysPath("XMLFile12_Request.xml"));
            string UserCode = xmldoc2.SelectSingleNode("//UserCode[last()]").InnerText.ToString();
            string workKey = xmldoc2.SelectSingleNode("//WorkKey[last()]").InnerText.ToString();
            string VerifyInfo = xmldoc2.SelectSingleNode("//VerifyInfo[last()]").InnerText.ToString();


            XmlDocument xmldoc1 = new XmlDocument();
            xmldoc1.Load(GetPublicKey.GetSysPathRespose("XMLFile12_Response.xml"));
            string workGuid = xmldoc1.SelectSingleNode("//WorkGuid[last()]").InnerText.ToString();

            String psInputPara = "";

            // 
            String body = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
            + "<InputParameter>"
            + "<CardNoType>1</CardNoType>"
            + "<CardNo>" + memberVO.posCardNo + "</CardNo>"
            + "<Year>" + pointVO.yyyy + "</Year>"
            + "<Month>" + pointVO.mm + "</Month>"
            + "<WorkGuid>" + workGuid + "</WorkGuid>"
            + "<BgnRowNum>" + pointVO.bgnRowNum + "</BgnRowNum>"
            + "<EndRowNum>" + pointVO.endRowNum + "</EndRowNum>"
            + "</InputParameter>";



            String enBody = RSA_3DES.EncryStr3DES(workKey, body);

            String tag = enBody + VerifyInfo;
            tag = RSA_3DES.encryptMD5(tag).ToUpper();



            psInputPara = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                    + "<InputParameter>"
                    + "<Head>"
                    + "<Tag>" + tag + "</Tag>"
                    + "<ClientCode>" + ClientCode + "</ClientCode>"
                    + "</Head>"
                    + "<Body>"
                    + enBody
                    + "</Body>"
                    + "</InputParameter>";



            WebReferenceCC.TReturnInfo TReturnInfo = GetPublicKey.WebService(903, psInputPara);

            string decodedMsg = Base64.DecodeBase64(TReturnInfo.RtnMsg);



            if (TReturnInfo.ReturnCode == 0)
            {
                //String resultXml = DES3.decrypt(result.getOutputPara(), workKey).trim();
                jsonString = RSA_3DES.DecryStr3DES(workKey, TReturnInfo.OutputPara);
                return jsonString;

            }


            else { return jsonString; }
           




        }




        public static List<T> xmlToList<T>(string xml)
        {
            Type tp = typeof(T);
            List<T> list = new List<T>();
            if (xml == null || string.IsNullOrEmpty(xml))
            {
                return list;
            }
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.LoadXml(xml);
                if (tp == typeof(string) | tp == typeof(int) | tp == typeof(long) | tp == typeof(DateTime) | tp == typeof(double) | tp == typeof(decimal))
                {
                   // System.Xml.XmlNodeList nl = doc.SelectNodes("/root/item");

                    System.Xml.XmlNodeList nl = doc.SelectNodes("//ROW");
                    if (nl.Count == 0)
                    {
                        return list;
                    }
                    else
                    {
                        foreach (System.Xml.XmlNode node in nl)
                        {
                            if (tp == typeof(string)) { list.Add((T)(object)Convert.ToString(node.InnerText)); }
                            else if (tp == typeof(int)) { list.Add((T)(object)Convert.ToInt32(node.InnerText)); }
                            else if (tp == typeof(long)) { list.Add((T)(object)Convert.ToInt64(node.InnerText)); }
                            else if (tp == typeof(DateTime)) { list.Add((T)(object)Convert.ToDateTime(node.InnerText)); }
                            else if (tp == typeof(double)) { list.Add((T)(object)Convert.ToDouble(node.InnerText)); }
                            else if (tp == typeof(decimal)) { list.Add((T)(object)Convert.ToDecimal(node.InnerText)); }
                            else { list.Add((T)(object)node.InnerText); }
                        }
                        return list;
                    }
                }
                else
                {
                    //如果是自定义类型就需要反序列化了
                   // System.Xml.XmlNodeList nl = doc.SelectNodes("/root/items/" + typeof(T).Name);

                    System.Xml.XmlNodeList nl = doc.SelectNodes("//ROW");
                    if (nl.Count == 0)
                    {
                        return list;
                    }
                    else
                    {
                        foreach (System.Xml.XmlNode node in nl)
                        {
                           // list.Add(XMLToObject<T>(node.OuterXml));
                            PointVOXML pointVOXML = new PointVOXML();
                            list.Add((T)XMLToModel.XMLToModelTo(node.OuterXml, pointVOXML));

                        }
                        return list;
                    }
                }

            }
            catch (XmlException ex)
            {
                throw new ArgumentException("不是有效的XML字符串", "xml");
            }
            catch (InvalidCastException e)
            {
                throw new ArgumentException("指定的数据类型不匹配", "T");
            }
            catch (Exception exx)
            {
                throw exx;
            }
        }


        public static T XMLToObject<T>(string source, Encoding encoding)
        {
            System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (MemoryStream Stream = new MemoryStream(encoding.GetBytes(source)))
            {
                return (T)mySerializer.Deserialize(Stream);
            }
        }
        public static T XMLToObject<T>(string source)
        {
            return XMLToObject<T>(source, Encoding.UTF8);
        }

        public static void JsonToList()
        {

            string inputJsonString = jsonString;
            JArray jsonObj = JArray.Parse(inputJsonString);

            List<CardJson> list = new List<CardJson>();

            for (int i = 0; i < jsonObj.Count; i++)
            {

                list[i].CARDHYNO = jsonObj[i]["CARDHYNO"] == null ? string.Empty : jsonObj[i]["CARDHYNO"].ToString();
                list[i].CERTIME = jsonObj[i]["CERTIME"] == null ? string.Empty : jsonObj[i]["CERTIME"].ToString();
                list[i].CERTINAME = jsonObj[i]["CERTINAME"] == null ? string.Empty : jsonObj[i]["CERTINAME"].ToString();
                list[i].CERTINO = jsonObj[i]["CERTINO"] == null ? string.Empty : jsonObj[i]["CERTINO"].ToString();
                list[i].CHECKCODE = jsonObj[i]["CHECKCODE"] == null ? string.Empty : jsonObj[i]["CHECKCODE"].ToString();
                list[i].CXBILLNO = jsonObj[i]["CXBILLNO"] == null ? string.Empty : jsonObj[i]["CXBILLNO"].ToString();
                list[i].CXREMARK = jsonObj[i]["CXREMARK"] == null ? string.Empty : jsonObj[i]["CXREMARK"].ToString();
                list[i].Result = jsonObj[i]["Result"] == null ? string.Empty : jsonObj[i]["Result"].ToString();
                list[i].USBGNDATE = jsonObj[i]["USBGNDATE"] == null ? string.Empty : jsonObj[i]["USBGNDATE"].ToString();
                list[i].USENDDATE = jsonObj[i]["USENDDATE"] == null ? string.Empty : jsonObj[i]["USENDDATE"].ToString();
                list[i].USETOTAL = jsonObj[i]["USETOTAL"] == null ? string.Empty : jsonObj[i]["USETOTAL"].ToString();
                list[i].WEIXININFO = jsonObj[i]["WEIXININFO"] == null ? string.Empty : jsonObj[i]["WEIXININFO"].ToString();
                list.Add(list[i]);
            }


        }


        public static Object JsonToObj(String json, Type t)
        {
            try
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(t);
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                {
                    return serializer.ReadObject(ms);
                }
            }
            catch
            {
                return null;
            }
        }

      

        public static CardJson JsonConvertCardJson(string str)
        {
            JObject obj = (JObject)JsonConvert.DeserializeObject(str);
            CardJson cardJson = new CardJson();
            cardJson.CARDHYNO = obj["CARDHYNO"] == null ? string.Empty : obj["CARDHYNO"].ToString();
            cardJson.CERTIME = obj["CERTIME"] == null ? string.Empty : obj["CERTIME"].ToString();
            cardJson.CERTINAME = obj["CERTINAME"] == null ? string.Empty : obj["CERTINAME"].ToString();
            cardJson.CERTINO = obj["CERTINO"] == null ? string.Empty : obj["CERTINO"].ToString();
            cardJson.CHECKCODE = obj["CHECKCODE"] == null ? string.Empty : obj["CHECKCODE"].ToString();
            cardJson.CXBILLNO = obj["CXBILLNO"] == null ? string.Empty : obj["CXBILLNO"].ToString();
            cardJson.CXREMARK = obj["CXREMARK"] == null ? string.Empty : obj["CXREMARK"].ToString();
            cardJson.Result = obj["Result"] == null ? string.Empty : obj["Result"].ToString();
            cardJson.USBGNDATE = obj["USBGNDATE"] == null ? string.Empty : obj["USBGNDATE"].ToString();
            cardJson.USENDDATE = obj["USENDDATE"] == null ? string.Empty : obj["USENDDATE"].ToString();
            cardJson.USETOTAL = obj["USETOTAL"] == null ? string.Empty : obj["USETOTAL"].ToString();
            cardJson.WEIXININFO = obj["WEIXININFO"] == null ? string.Empty : obj["WEIXININFO"].ToString();

            return cardJson;
        }




        /// <summary>
        /// ajax请求公共方法
        /// </summary>
        /// <param name="ajax"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string WebClientFunction(string ajax, string param)
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                byte[] postdata = Encoding.UTF8.GetBytes(param);
                Byte[] pageData = client.UploadData(ajax, "POST", postdata);
                return Encoding.UTF8.GetString(pageData);
            }
            catch { return ""; }
        }
    }
}
