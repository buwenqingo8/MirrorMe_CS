using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace APIManage
{
  public   class SMS
    {
      public string sendMsg(string Mobile)
      {
          string yzm = new Random().Next(9999).ToString();
          if (yzm.Length<4)
          {
              yzm ="8888";  
          }
        wemediacn.SMSService sMSService = new wemediacn.SMSService();

    //    string Content = "欢迎光临悦芙媞，您验证码为：" + yzm; 
     //   DateTime ScheduleTime = DateTime.Now;

    //   DateTime ScheduleTime =  Convert.ToDateTime("2008-12-24 23:58:24");
      //  string Content = "";
        //     string sToken = "7100485130368794 ";//测试

            //  string sToken = "7101049130922148";

          //可用      string sToken = "7100104930373979";

        string sToken = "7100104830135797";


              //string Content = yzm + "(HAPSODE悦芙媞会员验证码，请完成验证)";


        string Content = yzm + "(MirrorMe秘镜思语会员验证码，请完成验证)";


              //   string Content = "验证码为" + yzm + ".很高兴注册为HAPSODE悦芙媞会员";
              //DateTime ScheduleTime = DateTime.Now;

              DateTime ScheduleTime = DateTime.Parse("0001/1/1 0:00:00");
       

        HttpSessionState Session = HttpContext.Current.Session;
        //HttpSessionState Session=new ;
        Session["MobileYzm"] = yzm;
        Session.Timeout = 1;
        string a = sMSService.SendSMS(Mobile, 8, Content, ScheduleTime, sToken);
        return a;
        }
        
    }
}
