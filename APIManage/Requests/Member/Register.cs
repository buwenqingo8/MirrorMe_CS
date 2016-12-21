using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Util;

namespace APIManage
{
  public   class Register
    {
      public static int GetRegister(MemberVO memberVO)
      {
    
          Random ran = new Random();
          int RandKey = ran.Next(1000, 9999);

          XmlDocument xmldoc = new XmlDocument();
          xmldoc.Load(GetPublicKey.GetSysPath("XMLFile8.xml"));
        string ClientCode=  xmldoc.SelectSingleNode("//ClientCode[last()]").InnerText.ToString();

        XmlDocument xmldoc2 = new XmlDocument();
        xmldoc2.Load(GetPublicKey.GetSysPath("XMLFile12_Request.xml"));
        string UserCode = xmldoc2.SelectSingleNode("//UserCode[last()]").InnerText.ToString();
        string workKey = xmldoc2.SelectSingleNode("//WorkKey[last()]").InnerText.ToString();
        string VerifyInfo = xmldoc2.SelectSingleNode("//VerifyInfo[last()]").InnerText.ToString();


        XmlDocument xmldoc1 = new XmlDocument();
        xmldoc1.Load(GetPublicKey.GetSysPathRespose("XMLFile12_Response.xml"));
        string workGuid = xmldoc1.SelectSingleNode("//WorkGuid[last()]").InnerText.ToString();


          String body = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
                + "<InputParameter>"
                + "<Random>" + RandKey + "</Random>"
                + "<ClientCode>" + ClientCode + "</ClientCode>"
                + "<WorkGuid>" + workGuid + "</WorkGuid>"
                + "<AppID></AppID>"
                + "<CardTypeCode>501</CardTypeCode>"
                + "<ExtCardNo></ExtCardNo>"
                + "<YwType>4</YwType>"
                + "<Mobile>" + memberVO.phone + "</Mobile>"
                + "<Mailaddr></Mailaddr>"
                + "<OrgCode>"+ memberVO.OrgCode +"</OrgCode>"
                + "<CertNo></CertNo>"
                + "<Gender>1</Gender>"
                + "<VipName>" + memberVO.memName + "</VipName>"
                + "<OcUserCode>" + UserCode + "</OcUserCode>"
                + "<OldBillNo>" + memberVO.idx + "</OldBillNo>"
                + "<UserCode>" + UserCode + "</UserCode>"
                + "<Birthday>" + memberVO.birthday + "</Birthday>"
                + "</InputParameter>";

       
          String enBody = RSA_3DES.EncryStr3DES(workKey, body); 

		String tag = enBody + VerifyInfo;
		tag = encryptMD5(tag).ToUpper();

        string psInputPara = "";
		
		psInputPara = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"
				+"<InputParameter>"
				+"<Head>"
				+"<Tag>"+tag+"</Tag>"
				+"<ClientCode>"+ClientCode+"</ClientCode>"
				+"</Head>"
				+"<Body>"
				+ enBody 
				+"</Body>"
				+"</InputParameter>";



        WebReferenceCC.TReturnInfo TReturnInfo = GetPublicKey.WebService(122, psInputPara);

        return TReturnInfo.ReturnCode;

          //会员已存在 手机号重复
        //if (TReturnInfo.ReturnCode == 1221)
        //{
        //    PosExistMemberInfo posExistM = new PosExistMemberInfo();
        //     posExistM.getPosExistMemberInfo(memberVO);
        //}
      }

      private static string encryptMD5(string value)  {
          byte[] result = Encoding.Default.GetBytes(value);  
          MD5 md5 = new MD5CryptoServiceProvider();
          byte[] output = md5.ComputeHash(result);
          string outstr = BitConverter.ToString(output).Replace("-", "");  
          return outstr;
	}

     

    }
}
