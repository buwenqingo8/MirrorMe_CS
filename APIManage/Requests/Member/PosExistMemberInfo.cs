using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Util;

namespace APIManage
{
   public  class PosExistMemberInfo
    {
      public  string  getPosExistMemberInfo(MemberVO memberVO)
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

          

           String body = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<InputParameter>"
                + "<CardNo>" + memberVO.phone + "</CardNo>"
                + "<CardNoType>2</CardNoType>"
                + "<Password></Password>"
                + "<CardFaceChk></CardFaceChk>"
                + "<CardFaceNoVerifyValue></CardFaceNoVerifyValue>"
                + "<OrgCode>7001</OrgCode>"
                + "<AccType></AccType>"
                + "<YwType>101COMM</YwType>"
                + "<QryKind>0</QryKind>"
                + "<WorkGuid>" + workGuid + "</WorkGuid>"
                + "<CardFaceNo></CardFaceNo>"
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



           WebReferenceCC.TReturnInfo TReturnInfo = GetPublicKey.WebService(3, psInputPara);

           string decodedMsg = Base64.DecodeBase64(TReturnInfo.RtnMsg);



           if (TReturnInfo.ReturnCode == 0)
           {
               //String resultXml = DES3.decrypt(result.getOutputPara(), workKey).trim();

              return  RSA_3DES.DecryStr3DES(workKey, TReturnInfo.OutputPara);


           }

          else
           {
               return "";
           }
		
       }

      public void getPosMemberInfo(MemberVO memberVO)
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


          String body = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<InputParameter>"
                + "<CardNo>" + memberVO.posCardNo + "</CardNo>"
                + "<CardNoType>1</CardNoType>"
                + "<Password></Password>"
                + "<CardFaceChk></CardFaceChk>"
                + "<CardFaceNoVerifyValue></CardFaceNoVerifyValue>"
                + "<OrgCode>7001</OrgCode>"
                + "<AccType></AccType>"
                + "<YwType>101COMM</YwType>"
                + "<QryKind>0</QryKind>"
                + "<WorkGuid>" + workGuid + "</WorkGuid>"
                + "<CardFaceNo>" + memberVO.posCardNo+ "</CardFaceNo>"
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



          WebReferenceCC.TReturnInfo TReturnInfo = GetPublicKey.WebService(3, psInputPara);

          string decodedMsg = Base64.DecodeBase64(TReturnInfo.RtnMsg);



          if (TReturnInfo.ReturnCode == 0)
          {
             
              String resultXml = RSA_3DES.DecryStr3DES(workKey, TReturnInfo.OutputPara);




          }

      }
    }
}
