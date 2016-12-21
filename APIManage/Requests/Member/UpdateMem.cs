using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Security.Cryptography;
using Util;

namespace APIManage
{
  public static  class UpdateMem
    {
      public static string updateM(string phone)
        {
            string VipCardNo = "";

            PosExistMemberInfo posExi = new PosExistMemberInfo();
            MemberVO memberVO = new MemberVO();
            memberVO.phone = phone;
            string mebxml = posExi.getPosExistMemberInfo(memberVO);
            if (!string.IsNullOrEmpty(mebxml))
            {
                XmlDocument xmldocx= new XmlDocument();

                xmldocx.LoadXml(mebxml);
                VipCardNo = xmldocx.SelectSingleNode("//VipCardNo[last()]").InnerText.ToString();
            }


          //  VipCardNo = "1825822403504";
            Random ran = new Random();
            int RandKey = ran.Next(1, 35);
            //  System.Guid guid = new Guid();
            string guid = Guid.NewGuid().ToString().Remove(20);

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


            
//            <InputParameter>
//<RandomNo>随机数</RandomNo>
//<ClientCode>交易客户端编码</ClientCode>
//<UserCode>CRM系统用户编码</UserCode>
//<WorkGuid>工作Guid</WorkGuid>
//<VipCardNo>会员卡号</ VipCardNo>
//<UDP1>店铺类型标识</UDP1>
//<UDP2>秘镜思语门店名称</UDP2>
//<UDP3>秘镜思语注册时间</UDP3>
//</InputParameter>


            String body = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><InputParameter><RandomNo>" + RandKey + "</RandomNo><ClientCode>" + ClientCode + "</ClientCode><UserCode>" + UserCode + "</UserCode><WorkGuid>" + workGuid + "</WorkGuid><OrgCode>86</OrgCode><VipCardNo>" + VipCardNo + "</VipCardNo><UDP1>店铺类型标识</UDP1><UDP2>店铺门店</UDP2><UDP3>" + DateTime.Now.ToShortTimeString() + "</UDP3></InputParameter>";



            String enBody = RSA_3DES.EncryStr3DES(workKey, body);

            String tag = enBody + VerifyInfo;
            tag = encryptMD5(tag).ToUpper();

            string psInputPara = "";

            psInputPara = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                    + "<InputParameter>"
                    + "<Head>"
                     + "<ClientCode>" + ClientCode + "</ClientCode>"
                    + "<Tag>" + tag + "</Tag>"
                    + "</Head>"
                    + "<Body>"
                    + enBody
                    + "</Body>"
                    + "</InputParameter>";



            WebReferenceCC.TReturnInfo TReturnInfo = GetPublicKey.WebService(243, psInputPara);

            return TReturnInfo.ReturnCode.ToString();





        }


        private static string encryptMD5(string value)
        {
            byte[] result = Encoding.Default.GetBytes(value);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string outstr = BitConverter.ToString(output).Replace("-", "");
            return outstr;
        }
    }
}

