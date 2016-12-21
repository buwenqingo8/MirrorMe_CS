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


public partial class region : System.Web.UI.Page
{
    void GetRegister()
    {

        if (string.IsNullOrEmpty(this.phone.Value.ToString()))
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('手机还没填呢！');</script>");

            return;
        }

        //if (string.IsNullOrEmpty(Request.Form["USER_AGE"]))
        //{
        //    Response.Write("生日还没填呢！");
        //}

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
        MemberVO memberVO = new MemberVO();
        memberVO.phone = Request.Form["phone"];
        memberVO.gender = Request.Form["sex1"] == null ? Request.Form["sex2"] : Request.Form["sex1"];
        // memberVO.gender = Request.Form["sex1"];
        memberVO.memName = Request.Form["name"];
        //  memberVO.idx = "2016071800001";
        memberVO.idx = DateTime.Now.ToString();
        memberVO.birthday = Request.Form["USER_AGE"];

        int data = APIManage.Register.GetRegister(memberVO);

        if (data == 1223)
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('卡面号重复！');</script>");

            return;
        }
        else if (data == 1221)
        {
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
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>sky('成功！');</script>");

            //  Response.Redirect("Main.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>show_err_msg('输入有误！');</script>");
            return;
        }
    }



    void GetPosPoint()
    {
        MemberVO memberVO = new MemberVO();
        memberVO.phone = "18258224036";
        memberVO.gender = "0";
        memberVO.memName = "buwenqing";
        //  memberVO.idx = "2016071800001";
        memberVO.idx = DateTime.Now.ToString();
        memberVO.birthday = "1987-05-24";

        PointVO pointVO = new PointVO();
        pointVO.yyyy = "2016";
        pointVO.mm = "07";
        pointVO.bgnRowNum = "0";
        pointVO.endRowNum = "10";

        PosPoint.getPosPoint(memberVO, pointVO);
    }

    void GetPosExistMemberInfo()
    {
        MemberVO memberVO = new MemberVO();
        memberVO.phone = "18258224036";

        PosExistMemberInfo posExistMemberInfo = new PosExistMemberInfo();
        posExistMemberInfo.getPosExistMemberInfo(memberVO);
    }

    void getQueryCertiByHyCard()
    {
        QueryCertiByHyCard q = new QueryCertiByHyCard();
        q.getQueryCertiByHyCard();
    }



    protected void btnsumbit_Click(object sender, EventArgs e)
    {
        GetRegister();
    }

    [WebMethod]
    public static int GetRegister(string phone, string memName, string birthday, string gender)
    {
        MemberVO memberVO = new MemberVO();
        memberVO.phone = phone;
        memberVO.gender = gender;

        memberVO.memName = memName;
        //  memberVO.idx = "2016071800001";
        memberVO.idx = DateTime.Now.ToString();
        memberVO.birthday = birthday;

        return APIManage.Register.GetRegister(memberVO);
    }



}
