using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using APIManage;
using Util;

namespace Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //Application["CurrentGuests"] = 0;

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 60000 * 60 * 20;//执行间隔时间,单位为毫秒

            // timer.Interval = 60000 ;//执行间隔时间,单位为毫秒

            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);


        }

        private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           // string g = Request.PhysicalApplicationPath;

            getSign();

            //// 得到 hour minute second  如果等于某个值就开始执行某个程序。
            //int intHour = e.SignalTime.Hour;
            //int intMinute = e.SignalTime.Minute;
            //int intSecond = e.SignalTime.Second;
            //// 定制时间； 比如 在10：30 ：00 的时候执行某个函数
            //int iHour = 10;
            //int iMinute = 30;
            //int iSecond = 00;
            //// 设置　 每秒钟的开始执行一次
            //if (intSecond == iSecond)
            //{
            //    Console.WriteLine("每秒钟的开始执行一次！");
            //}
            //// 设置　每个小时的３０分钟开始执行
            //if (intMinute == iMinute && intSecond == iSecond)
            //{
            //    Console.WriteLine("每个小时的３０分钟开始执行一次！");
            //}

            //// 设置　每天的１０：３０：００开始执行程序
            //if (intHour == iHour && intMinute == iMinute && intSecond == iSecond)
            //{
            //    Console.WriteLine("在每天１０点３０分开始执行！");
            //}


        }


        public static void getSign()
        { 
            string d=  System.Web.Hosting.HostingEnvironment.MapPath("~");

        //  string d = System.Web.HttpContext.Current.Server.MapPath("~");
          string subPath = d.Substring(0, d.Length - 4);
          string f = subPath + "APIManage\\Requests\\Xml_Requests\\XMLFile12_Request.xml";

            string a = "WorkKey";

            Random ran = new Random();
            int RandKey = ran.Next(100000000, 999999999);

            string b = (RandKey + 1000000000000000).ToString();

          //  string c = GetPublicKey.GetSysPath("XMLFile12_Request.xml");
           Util.XMLCore.SaveXmlConfig(a,b,f);

           SignIn.GetSignIn();
        }


        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="strTarget">节点名</param>
        /// <param name="strValue">新值</param>
        /// <param name="strSource">路径</param>
        public static void SaveXmlConfig()
        {

          //  string xmlPath = HttpContext.Current.Server.MapPath("APIManage\\Requests\\Xml_Requests\\XMLFile12_Request.xml");
            System.Xml.XmlDocument xdoc = new XmlDocument();
            xdoc.Load(GetPublicKey.GetSysPath("XMLFile12_Request.xml"));

           
          //  xdoc.Load(xmlPath);
            XmlElement root = xdoc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("WorkKey");
            Random ran = new Random();
            int  RandKey = ran.Next(100000000, 999999999);

            elemList[0].InnerXml = (RandKey+1000000000000000).ToString();
            xdoc.Save(GetPublicKey.GetSysPath("XMLFile12_Request.xml"));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}