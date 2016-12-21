using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace APIManage
{
    partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer1;  //计时器
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO:  在此处添加代码以启动服务。

            timer1 = new System.Timers.Timer();
            timer1.Interval = 1000 * 120;  //设置计时器事件间隔执行时间
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Elapsed);
            timer1.Enabled = true;
        }

        protected override void OnStop()
        {
            // TODO:  在此处添加代码以执行停止服务所需的关闭操作。
        }

        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            getSign();


        }


        public static void getSign()
        {
            string d = System.Web.Hosting.HostingEnvironment.MapPath("~");
            // string d = System.Web.HttpContext.Current.Server.MapPath("~");
            string subPath = d.Substring(0, d.Length - 4);
            string f = subPath + "APIManage\\Requests\\Xml_Requests\\XMLFile12_Request.xml";

            string a = "WorkKey";

            Random ran = new Random();
            int RandKey = ran.Next(100000000, 999999999);

            string b = (RandKey + 1000000000000000).ToString();

            //  string c = GetPublicKey.GetSysPath("XMLFile12_Request.xml");
            Util.XMLCore.SaveXmlConfig(a, b, f);

            APIManage.SignIn.GetSignIn();
        }

    }
}
