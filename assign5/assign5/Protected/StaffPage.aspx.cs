using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assign5.Protected
{
    public partial class StaffPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //clear contents in cookie before signing out
        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["newcookie123"];
            if ((myCookies != null) || (myCookies["Name"] != ""))
            {
                HttpCookie myCookie = new HttpCookie("newcookie123");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            FormsAuthentication.SignOut();
            string path = "../Default.aspx";
            Response.Redirect(path);
            //Server.Transfer(path);
        }

        //Admin page
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Staff1Page/WebForm1.aspx");
        }
        //Staff page
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Staff2Page/WebForm1.aspx");
        }
    }
}