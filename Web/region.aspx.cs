using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using APIManage;
using System.Web.SessionState;


public partial class region : System.Web.UI.Page
{
    void GetRegister()
    {
       

        if (string.IsNullOrEmpty(this.phone.Value.ToString()))
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('手机还没填呢！');</script>");

            return;
        }


        if (string.IsNullOrEmpty(this.USER_AGE.Value))
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('生日还没填呢！');</script>");

            return;
        }

        if (string.IsNullOrEmpty(this.name.Value))
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('姓名(会员名)还没填呢！');</script>");

            return;
        }

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

        if (!chkYes.Checked)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('请接受服务协议！');</script>");
            return;
        }

        if (ddlMD.SelectedValue=="0")
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('请选择所属门店！');</script>");
            return;
        }

        MemberVO memberVO = new MemberVO();
        memberVO.phone = Request.Form["phone"];
      //  memberVO.gender = Request.Form["sex1"] == null ? Request.Form["sex2"] : Request.Form["sex1"];
     //   memberVO.gender = Request.Form["sex1"];
        memberVO.memName = Request.Form["name"];
     //   memberVO.OrgCode = ddlMD.SelectedValue;
        
        //  memberVO.idx = "2016071800001";
        memberVO.idx = DateTime.Now.ToString("yyyyMMdd hhmmssfff");
        memberVO.birthday = Request.Form["USER_AGE"];

        int data = APIManage.Register.GetRegister(memberVO);



        if (data == 1223)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('卡面号重复！');</script>");

            return;
        }
        else if (data == 1221)
        {
            APIManage.UpdateMem.updateM(memberVO.phone);

            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('手机号已存在，请登陆！');</script>");

            return;
        }
        else if (data == 1222)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('证件号重复！');</script>");

            return;
        }

           

        else if (data == 0)
        {
            APIManage.UpdateMem.updateM(memberVO.phone);
            
            HttpCookie cookie = new HttpCookie("cookiePhone");
            cookie.Value = phone.Value;
            cookie.Expires = DateTime.MaxValue;
            //cookie.Expires = DateTime.Now.Add(TimeSpan.MaxValue);
            HttpContext.Current.Response.Cookies.Add(cookie);
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>sky('成功！');</script>");

          //   Response.Redirect("index.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('输入有误！');</script>");
            return;
        }
    }


    [WebMethod]
    public static void BB(string phone)
    {

        //string yzm = new Random().Next(999999).ToString();

        string strphone = phone;
        //   string yzm = new Random().Next(999999).ToString();
        // Session["MobileYzm"] = yzm;

        //如果是手机号登录
        string strReg = @"^((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)";

        SMS sms = new SMS();
        sms.sendMsg(phone);

    }
   

    [WebMethod]
    public static int GetRegister(string phone, string memName, string birthday, string gender)
    {
        MemberVO memberVO = new MemberVO();
        memberVO.phone = phone;
        memberVO.gender = gender;

        memberVO.memName = memName;
        //  memberVO.idx = "2016071800001";
        memberVO.idx = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");
        memberVO.birthday = birthday;

        return APIManage.Register.GetRegister(memberVO);
    }



    protected void btnsumbit_Click(object sender, EventArgs e)
    {
        GetRegister();
    }
}
