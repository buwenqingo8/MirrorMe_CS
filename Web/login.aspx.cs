using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using APIManage;


public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //每天要执行程序的时间
        //DateTime d = Convert.ToDateTime("14:20");
        ////当前时间
        //DateTime now = DateTime.Now;

        //if (d.Hour == now.Hour && d.Minute == now.Minute)
        //{
        //    Response.Write("我要执行了");
        //}

    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        PosExistMemberInfo posExistMemberInfo = new PosExistMemberInfo();
        MemberVO memberVO = new MemberVO();
        memberVO.phone = account.Value;
        string smg = posExistMemberInfo.getPosExistMemberInfo(memberVO);


        if (string.IsNullOrEmpty(txtChkCode.Value))
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('请填写验证码！');</script>");
            return;
        }
        else
        {


            HttpSessionState Session = HttpContext.Current.Session;

            if (Session["MobileYzm"] == null)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('请重新获取验证码！');</script>");
                return;
            }

            if (Session["MobileYzm"].ToString() != txtChkCode.Value)
            {
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('验证码不正确，请重试！');</script>");
                return;
            }
        }


        if (string.IsNullOrEmpty(smg.Trim()))
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('该手机还没注册，请注册！');</script>");

            return;
        }
        else
        {

            HttpCookie cookie = new HttpCookie("cookiePhone");
            cookie.Value = account.Value;
            cookie.Expires = DateTime.MaxValue;

          
            HttpContext.Current.Response.Cookies.Add(cookie);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>sky('成功！');</script>");

        }

    }



    [WebMethod]
    public static void BB(string phone)
    {

        string strphone = phone;

        //如果是手机号登录
        string strReg = @"^((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)";

        SMS sms = new SMS();
        sms.sendMsg(phone);

    }

}