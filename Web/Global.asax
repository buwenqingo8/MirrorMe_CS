<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        getSign();
        // 在应用程序启动时运行的代码
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Enabled = true;
          timer.Interval = 60000 * 60 * 12;//执行间隔时间,单位为毫秒

          //   timer.Interval = 60000;//执行间隔时间,单位为毫秒

        timer.Start();
        timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);
    }


    private void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {


        getSign();


    }


    public static void getSign()
    {
        string d = System.Web.Hosting.HostingEnvironment.MapPath("~");
        // string d = System.Web.HttpContext.Current.Server.MapPath("~");
    //    string subPath = d.Substring(0, d.Length - 4);

        string subPath = @"D:\WX_APIManage";
        string f = subPath + "APIManage\\Requests\\Xml_Requests\\XMLFile12_Request.xml";

        string a = "WorkKey";

        Random ran = new Random();
        int RandKey = ran.Next(100000000, 999999999);

        string b = (RandKey + 1000000000000000).ToString();

        //  string c = GetPublicKey.GetSysPath("XMLFile12_Request.xml");
        Util.XMLCore.SaveXmlConfig(a, b, f);

        APIManage.SignIn.GetSignIn();
    }

    /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="strTarget">节点名</param>
        /// <param name="strValue">新值</param>
        /// <param name="strSource">路径</param>
        public static void SaveXmlConfig()
        {

//          string xmlPath = HttpContext.Current.Server.MapPath("APIManage\\Requests\\Xml_Requests\

//\XMLFile12_Request.xml");
            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();
            xdoc.Load(APIManage.GetPublicKey.GetSysPath("XMLFile12_Request.xml"));

           
          //  xdoc.Load(xmlPath);
            System.Xml.XmlElement root = xdoc.DocumentElement;
            System.Xml.XmlNodeList elemList = root.GetElementsByTagName("WorkKey");
            Random ran = new Random();
            int  RandKey = ran.Next(100000000, 999999999);

            elemList[0].InnerXml = (RandKey+1000000000000000).ToString();
            xdoc.Save(APIManage.GetPublicKey.GetSysPath("XMLFile12_Request.xml"));
        }
    
    void Application_End(object sender, EventArgs e) 
    {
        getSign();
        //  在应用程序关闭时运行的代码
         System.Timers.Timer timer = new System.Timers.Timer();
        timer.Enabled = true;
          timer.Interval = 60000 * 60 * 12;//执行间隔时间,单位为毫秒

          //   timer.Interval = 60000;//执行间隔时间,单位为毫秒

        timer.Start();
        timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);
    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        getSign();
        // 在出现未处理的错误时运行的代码
        System.Timers.Timer timer = new System.Timers.Timer();
        timer.Enabled = true;
        timer.Interval = 60000 * 60 * 12;//执行间隔时间,单位为毫秒

        //   timer.Interval = 60000;//执行间隔时间,单位为毫秒

        timer.Start();
        timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
        // 或 SQLServer，则不引发该事件。

    }
       
</script>
