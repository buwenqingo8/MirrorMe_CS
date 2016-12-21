using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Util;
using System.Runtime.InteropServices;

namespace APIManage
{
  public static   class SignIn
    {

      public static string WorkGuid = "";

        private const string _fileDll = @"RSADLL.dll";
        [DllImport(_fileDll, EntryPoint = "_RSAEncryptString@16", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern void RSAEncryptString(char[] sInput, char[] mn, char[] me, StringBuilder cipher);



      public static string GetSysPublicKey()
        {
            GetPublicKey.GetSysPublicKey();

          //  XmlElement theBook = null, theElem = null, root = null;
            XmlDocument xmldoc = new XmlDocument();
         //   xmldoc.Load("XMLFile8_Response");

            xmldoc.Load(GetPublicKey.GetSysPathRespose("XMLFile8_Response.xml"));
          //  xmldoc.Load(GetPublicKey.GetSysPath(XMLFile12_Request));
         //   root = xmldoc.DocumentElement;
         
            try
            {
                XmlNode root = xmldoc.SelectSingleNode("//KEYE[last()]");
                String temp = Convert.ToString(root);
                if (!string.IsNullOrEmpty(temp))
                    return xmldoc.SelectSingleNode("//KEYE[last()]").InnerText;
                else
                    return "";
            }
            catch (Exception ef)
            {
                return "";
            }
        }



      public static string GetSysPublicKeyN()
      {
         
          XmlDocument xmldoc = new XmlDocument();
        //  xmldoc.Load("XMLFile8_Response");
          xmldoc.Load(GetPublicKey.GetSysPathRespose("XMLFile8_Response.xml"));
        
          try
          {
              XmlNode root = xmldoc.SelectSingleNode("//KEYN[last()]");
              String temp = Convert.ToString(root);
              if (!string.IsNullOrEmpty(temp))
                  return xmldoc.SelectSingleNode("//KEYN[last()]").InnerText;
              else
                  return "";
          }
          catch (Exception ef)
          {
              return "";
          }
      }


      public static string GetSignIn()
      {
          XmlDocument xmldoc = new XmlDocument();
        //  xmldoc.Load("XMLFile12_Request");

     //   xmldoc.Load(GetPublicKey.GetSysPath("XMLFile12_Request.xml"));


          string d = System.Web.Hosting.HostingEnvironment.MapPath("~");

          //  string d = System.Web.HttpContext.Current.Server.MapPath("~");
       //   string subPath = d.Substring(0, d.Length - 4);

          string subPath = @"D:\WX_APIManage";

          string ff = subPath + "APIManage\\Requests\\Xml_Requests\\XMLFile12_Request.xml";

          xmldoc.Load(ff);

          string keyE = GetSysPublicKey();
          string keyN = GetSysPublicKeyN();
       //   string keyD = GetSysPublicKeyN();


          string rsaxmldoc = RSA(xmldoc.InnerXml, keyE, keyN);

       // string rsaxmldoc= EncryptUtils.RSAEncrypt(key, xmldoc.InnerXml);



         WebReferenceCC.TReturnInfo TReturnInfo = GetPublicKey.WebService(12, rsaxmldoc);


          XmlDocument xdocSave = new XmlDocument();

        //  xdocSave.InnerXml = EncryptUtils.DES3Decrypt(TReturnInfo.OutputPara, "1871890980664250");




          xdocSave.InnerXml = RSA_3DES.DecryStr3DES(xmldoc.SelectSingleNode("//WorkKey[last()]").InnerText, TReturnInfo.OutputPara);

         
          string f = subPath + "APIManage\\Responses\\Xml_Responses\\XMLFile12_Response.xml";
          xdocSave.Save(f);
          WorkGuid = xdocSave.InnerXml;

          //Session("name") = "MyName";
          //Application["CurrentGuests"] = 0;

          try
          {
              XmlNode root = xmldoc.SelectSingleNode("//KEYE[last()]");
              String temp = Convert.ToString(root);
              if (!string.IsNullOrEmpty(temp))
                  return xmldoc.SelectSingleNode("//KEYE[last()]").InnerText;
              else
                  return "";
          }
          catch (Exception ef)
          {
              return "";
          }
       


      //    EncryptUtils.DES3Decrypt(TReturnInfo.OutputPara, GetSysPublicKey());

      }


      private static  string  RSA(string sInputPara, string KeyE, string KeyN)
      {

          Encoding encode = Encoding.Default;
          byte[] bInputPara = encode.GetBytes(sInputPara);
          byte[] bKeyE = encode.GetBytes(KeyE);
          byte[] bKeyN = encode.GetBytes(KeyN);

          StringBuilder sInputTmp = new StringBuilder(5000);

          RSAEncryptString(encode.GetChars(bInputPara), encode.GetChars(bKeyN), encode.GetChars(bKeyE), sInputTmp);

         return  sInputTmp.ToString();
      }

    }
}
