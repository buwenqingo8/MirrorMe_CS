using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using APIManage;

namespace Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        //   APIManage.GetPublicKey.GetSysPublicKey();

            PosPoint.JsonToList(); 
           
        }

        protected void btnSign_Click(object sender, EventArgs e)
        {
            Global.getSign();
        }

       
    }
}