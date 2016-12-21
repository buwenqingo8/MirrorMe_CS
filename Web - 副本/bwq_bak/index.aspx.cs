using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APIManage;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //  GetPosPoint();
    List<CardJson> list=    getQueryCertiByHyCard();
    this.rtInvite.DataSource = list;
    this.rtInvite.DataBind();


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

    List<CardJson> getQueryCertiByHyCard()
    {
        QueryCertiByHyCard q = new QueryCertiByHyCard();
    return   q.getQueryCertiByHyCard();
    }
}