using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Diagnostics;


namespace APIManage
{
  public  static  class GetPublicKey
    {

      public static string GetSysPath(string fileName)
      {
          string d = System.Web.Hosting.HostingEnvironment.MapPath("~");
         // string d = System.Web.HttpContext.Current.Server.MapPath("~");
        //  string subPath = d.Substring(0, d.Length - 4);

          string subPath = @"D:\WX_APIManage";
          string f = subPath + "APIManage\\Requests\\Xml_Requests\\"+fileName;
          return f;
      }

      public static string GetSysPathRespose(string fileName)
      {
          string d = System.Web.Hosting.HostingEnvironment.MapPath("~");


      //    string d = System.Web.HttpContext.Current.Server.MapPath("~");
     //     string subPath = d.Substring(0, d.Length - 4);

          string subPath = @"D:\WX_APIManage";
          string f = subPath + "APIManage\\Responses\\Xml_Responses\\" + fileName;
          return f;
      }

      public static void GetSysPublicKey()
      {
       
        XmlDocument xdoc = new XmlDocument();

        string d = System.Web.Hosting.HostingEnvironment.MapPath("~");


      //  string d = System.Web.HttpContext.Current.Server.MapPath("~");
     //   string subPath = d.Substring(0,d.Length-4);

        string subPath = @"D:\WX_APIManage";
        string f = subPath + "APIManage\\Requests\\Xml_Requests\\XMLFile8.xml";
      
        xdoc.Load(f);
   
        WebReferenceCC.IHsCRMWebSrvservice HsWebSvr = new WebReferenceCC.IHsCRMWebSrvservice();

        WebReferenceCC.TReturnInfo RtnInfo = new WebReferenceCC.TReturnInfo();

       StringBuilder sInputTmp = new StringBuilder(5000);

       RtnInfo = HsWebSvr.IWsPosCommOperate(8, xdoc.InnerXml);


       //编码：
       byte[] bytes = Encoding.Default.GetBytes("要转换的字符");
       string str = Convert.ToBase64String(bytes);

       //解码：
       byte[] outputb = Convert.FromBase64String(RtnInfo.OutputPara);
       string orgStr = Encoding.Default.GetString(outputb);

           XmlDocument xdocSave = new XmlDocument();

           xdocSave.InnerXml = orgStr;
        //   xdocSave.Save("XMLFile8_Response");

           xdocSave.Save(GetSysPathRespose("XMLFile8_Response.xml"));

        }



      public static WebReferenceCC.TReturnInfo WebService(int i, string xdoc)         
      {
          WebReferenceCC.IHsCRMWebSrvservice HsWebSvr = new WebReferenceCC.IHsCRMWebSrvservice();
          WebReferenceCC.TReturnInfo RtnInfo = new WebReferenceCC.TReturnInfo();
          RtnInfo = HsWebSvr.IWsPosCommOperate(i, xdoc);
          return RtnInfo;
      }
        
    }
}
