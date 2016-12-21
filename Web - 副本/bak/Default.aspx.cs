using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using APIManage;



    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //  GetPosPoint();
            //   GetPosExistMemberInfo();
            getQueryCertiByHyCard();

        }

        void GetRegister()
        {
            
            //if (string.IsNullOrEmpty(this.phone.Value.ToString()))
            //{
            //    Response.Write("手机还没填呢！");
            //}

            ////if (string.IsNullOrEmpty(Request.Form["USER_AGE"]))
            ////{
            ////    Response.Write("生日还没填呢！");
            ////}

            //if (string.IsNullOrEmpty(this.USER_AGE.Value))
            //{
            //    Response.Write("生日还没填呢！");
            //}

            //if (string.IsNullOrEmpty(this.name.Value))
            //{
            //    Response.Write("姓名(会员名)还没填呢！");
            //}
            MemberVO memberVO = new MemberVO();
            memberVO.phone = Request.Form["phone"];
            memberVO.gender = Request.Form["sex1"] == null ? Request.Form["sex2"] : Request.Form["sex1"];
            // memberVO.gender = Request.Form["sex1"];
            memberVO.memName = Request.Form["name"];
            //  memberVO.idx = "2016071800001";
            memberVO.idx = DateTime.Now.ToString();
            memberVO.birthday = Request.Form["USER_AGE"];

            int data = Register.GetRegister(memberVO);

            if (data == 1223)
            {
                Response.Write("卡面号重复!");
            }
            else if (data == 1221)
            {
                Response.Write("手机号已存在，请登陆!");
            }
            else if (data == 1222)
            {
                Response.Write("证件号重复!");
            }

            else if (data == 0)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            //http://127.0.0.1/bchataspx/manager/Sac/SacDataImport.aspx
            /*pointStart*/
            string actionUrl = Request.RawUrl.ToString();//得到当前url
            actionUrl = Server.UrlEncode(Request.RawUrl.ToString());//对url进行编码
            /*pointEnd*/
            if (Request.Cookies["userId"] == null || Request.Cookies["userId"].Value.ToString().Trim() == "")
            {
                if (actionUrl != "")
                    Response.Redirect("/bchataspx/admin/LoginMenu.aspx?ReturnUrl=" + actionUrl);
                else
                    Response.Redirect("/bchataspx/admin/LoginMenu.aspx");
            }
            else
            {
                int uid = int.Parse(Request.Cookies["userId"].Value.Trim());
                //  u = new User(uid);
                base.OnLoad(e);
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

            return Register.GetRegister(memberVO);
        }

    }
