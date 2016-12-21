using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using APIManage;
using Util;

public partial class index : System.Web.UI.Page
{
     //string mobile = "";
    //static string phone = "";
    protected void Page_Load(object sender, EventArgs e)
    {
          string phone = "";

       
      //    phone=  Request.QueryString["phone"];

        if (HttpContext.Current.Request.Cookies["cookiePhone"] != null)
        {
            phone = HttpContext.Current.Request.Cookies["cookiePhone"].Value;

               
        }

        //if (HttpContext.Current.Response.Cookies["cookiePhone"] != null && !string.IsNullOrEmpty(HttpContext.Current.Response.Cookies["cookiePhone"].Value.Trim()))
        //{
        //    phone = HttpContext.Current.Response.Cookies["cookiePhone"].Value;
        //}

        if (string.IsNullOrEmpty(phone.Trim()))
        {
              if (HttpContext.Current.Session["ss"]!=null&&!string.IsNullOrEmpty(HttpContext.Current.Session["ss"].ToString()))
        {
            phone = HttpContext.Current.Session["ss"].ToString();
        }
        }

       
       

        if (string.IsNullOrEmpty(phone.Trim()))
        {
           

           
                ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>cc();</script>");
                return;

        }

       

        if (string.IsNullOrEmpty(phone))
        {
            //if (!string.IsNullOrEmpty(mobile.Trim()))
            //{
            //    phone = mobile;
            //    string url = "index.aspx?phone= " + strphone + "";
            //    System.Web.HttpContext.Current.Response.Redirect(url);
            //}

            //// Response.Write("<script language=javascript>window.location.reload( ); </script>" );  
            //else
            //{
            //    ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>if(!window.name){window.name = 'test';  window.location.href = 'index.aspx';}</script>");
            //}

            ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>if(!window.name){window.name = 'test';  window.location.href = 'login.aspx';}</script>");

        }

        else　
        {

            txtName.InnerText = "";
            PosExistMemberInfo posExistMemberInfo = new PosExistMemberInfo();
            MemberVO memberVO = new MemberVO();
            memberVO.phone = phone;

            MemberVOXML memberVOXML = new MemberVOXML();



            string xml = posExistMemberInfo.getPosExistMemberInfo(memberVO);

            memberVOXML = (MemberVOXML)XMLToModel.XMLToModelT(xml, memberVOXML);

            //if (memberVOXML.Gender == "0")
            //{
            //    memberVOXML.Gender = "男";
            //}
            //else if (memberVOXML.Gender == "1")
            //{
            //    memberVOXML.Gender = "女";
            //}

            txtname1.Value = txtName.InnerText = memberVOXML.VIPName;
            txtbrith.Value = memberVOXML.Birthday;
            txtphone.Value = phone;
        //    txtsex.Value = memberVOXML.Gender;
            txtVIP.InnerText = memberVOXML.CardTypeName;

            if (memberVOXML.CardTypeCode=="502")
            {
                imgVIP.Src = "/images/VIP-01.jpg";
            }

            else if (memberVOXML.CardTypeCode=="503")
            {
                imgVIP.Src = "/images/VVIP-01.png";
            }

            lblJF.InnerText = memberVOXML.SumJfTotal;

            if (string.IsNullOrEmpty(lblJF.InnerText.Trim()))
            {
                lblJF.InnerText = "0";
            }

            QueryCertiByHyCard q = new QueryCertiByHyCard();
            List<CardJson> list = q.getQueryCertiByHyCard(phone);
            if (!string.IsNullOrEmpty(list[0].CERTINO.ToString().Trim()))
            {
                lblYHQ.InnerText = list.Count.ToString();

            }
            else
            {
                lblYHQ.InnerText = "0";
            }
            rtInvite.DataSource = list;
            this.rtInvite.DataBind();

            PointVO posPoint = new PointVO();

            posPoint.yyyy = DateTime.Now.Year.ToString();
            if (selYY.SelectedIndex!=0)
            {
                posPoint.mm = (selYY.SelectedIndex+1).ToString("00");
            }
            else
            {
                selYY.SelectedIndex = DateTime.Now.Month - 1;
                if (selYY.SelectedIndex==0)
                {
                    selYY.SelectedIndex = 12;
                }
                posPoint.mm = DateTime.Now.Month.ToString("00");
            }
  
            posPoint.bgnRowNum = "1";
            posPoint.endRowNum = "100";

             memberVO.posCardNo = memberVOXML.CardFaceNo;

         

         string xmlPoints=   PosPoint.getPosPoint(memberVO, posPoint);

         IList<PointVOXML> listPont = new List<PointVOXML>();

     //    listPont = XmlToEntityList(xmlPoints);

         listPont = PosPoint.xmlToList<PointVOXML>(xmlPoints);

         rtpContact.DataSource = listPont;
         this.rtpContact.DataBind();

        }



    }


    public static IList<PointVOXML> XmlToEntityList(string xml)
    {
        XmlDocument doc = new XmlDocument();
        try
        {
            doc.LoadXml(xml);
        }
        catch
        {
            return null;
        }
   

        XmlNode node = doc.ChildNodes[0];

        IList<PointVOXML> items = new List<PointVOXML>();

        foreach (XmlNode child in node.ChildNodes)
        {
            if (child.Name.ToLower() == typeof(PointVOXML).Name.ToLower())
                items.Add(XmlNodeToEntity(child));
        }

        return items;
    }


    private static PointVOXML XmlNodeToEntity(XmlNode node)
    {
        PointVOXML item = new PointVOXML();

        if (node.NodeType == XmlNodeType.Element)
        {
            XmlElement element = (XmlElement)node;

            System.Reflection.PropertyInfo[] propertyInfo =
        typeof(PointVOXML).GetProperties(System.Reflection.BindingFlags.Public |
        System.Reflection.BindingFlags.Instance);

            foreach (XmlAttribute attr in element.Attributes)
            {
                string attrName = attr.Name.ToLower();
                string attrValue = attr.Value.ToString();
                foreach (System.Reflection.PropertyInfo pinfo in propertyInfo)
                {
                    if (pinfo != null)
                    {
                        string name = pinfo.Name.ToLower();
                        Type dbType = pinfo.PropertyType;
                        if (name == attrName)
                        {
                            if (String.IsNullOrEmpty(attrValue))
                                continue;
                            switch (dbType.ToString())
                            {
                                case "System.Int32":
                                    pinfo.SetValue(item, Convert.ToInt32(attrValue), null);
                                    break;
                                case "System.Boolean":
                                    pinfo.SetValue(item, Convert.ToBoolean(attrValue), null);
                                    break;
                                case "System.DateTime":
                                    pinfo.SetValue(item, Convert.ToDateTime(attrValue), null);
                                    break;
                                case "System.Decimal":
                                    pinfo.SetValue(item, Convert.ToDecimal(attrValue), null);
                                    break;
                                case "System.Double":
                                    pinfo.SetValue(item, Convert.ToDouble(attrValue), null);
                                    break;
                                default:
                                    pinfo.SetValue(item, attrValue, null);
                                    break;
                            }
                            continue;
                        }
                    }
                }
            }
        }
        return item;
    }

    [WebMethod]
    public static void getPhone(string strphone)
    {
  //      System.Web.HttpContext.Current.Response.Write("<script>window.location.href='login.aspx?phone= " + strphone + "'</script>");
       //   mobile = strphone;
          //CZ cz = new CZ();
          //cz.str = strphone;

     //   Hidden1.Value = strphone;

  //      System.Web.HttpContext.Current.Response.Write("<script language=javascript>window.location.reload( ); </script>");
  //string url="login.aspx?phone= " + strphone + "";
  //System.Web.HttpContext.Current.Response.Redirect(url);

        HttpCookie cookie = new HttpCookie("cookiePhone");
        cookie.Value = strphone;
     //   cookie.Expires = DateTime.MinValue;


        cookie.Expires = DateTime.MaxValue;
        HttpContext.Current.Response.Cookies.Add(cookie);

        HttpContext.Current.Session["ss"] = strphone;

    }



    protected void btnQuery_Click(object sender, EventArgs e)
    {

    }

    class CZ
    {

        public string str { get; set; }
      public   void cURL(string str)
        {


         //   System.Web.HttpContext.Current.Response.Write("<script>this.top.location.href='index.aspx?phone= "+str+"'</script>");


            System.Web.HttpContext.Current.Response.Write("<script>if(!window.name){window.name = 'test';window.location.href='login.aspx?phone= " + str + "'}</script>");

          //  ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>if(!window.name){window.name = 'test';  window.location.href = 'login.aspx';}</script>");

          
        }
    }

}




