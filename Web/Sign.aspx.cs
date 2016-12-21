using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APIManage;
using Web;

public partial class Sign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSign_Click(object sender, EventArgs e)
    {
       // Global.getSign();
        string d = System.Web.Hosting.HostingEnvironment.MapPath("~");
        //  string d = System.Web.HttpContext.Current.Server.MapPath("~");
    //    string subPath = d.Substring(0, d.Length - 4);

        string subPath = @"D:\WX_APIManage";
        string f = subPath + "APIManage\\Requests\\Xml_Requests\\XMLFile12_Request.xml";
        string a = "WorkKey";
        Random ran = new Random();
        int RandKey = ran.Next(100000000, 999999999);

        string b = (RandKey + 1000000000000000).ToString();
        //  string c = GetPublicKey.GetSysPath("XMLFile12_Request.xml");
        Util.XMLCore.SaveXmlConfig(a, b, f);
        SignIn.GetSignIn();
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Enabled = true;
        timer.Interval = 60000 * 60 * 12;//执行间隔时间,单位为毫秒

          //  timer.Interval = 60000 ;//执行间隔时间,单位为毫秒

        timer.Start();
        timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);

    } 

    private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        getSign();
    }


   private  static void getSign()
    {
        string d = System.Web.Hosting.HostingEnvironment.MapPath("~");

         // string d = System.Web.HttpContext.Current.Server.MapPath("~");
     //   string subPath = d.Substring(0, d.Length - 4);

        string subPath = @"D:\WX_APIManage";
        string f = subPath + "APIManage\\Requests\\Xml_Requests\\XMLFile12_Request.xml";

        string a = "WorkKey";

        Random ran = new Random();
        int RandKey = ran.Next(100000000, 999999999);

        string b = (RandKey + 1000000000000000).ToString();

        //  string c = GetPublicKey.GetSysPath("XMLFile12_Request.xml");
        Util.XMLCore.SaveXmlConfig(a, b, f);

        SignIn.GetSignIn();
    }

}