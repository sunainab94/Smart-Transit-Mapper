using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace assign5
{
    public partial class Default : System.Web.UI.Page
    {
        //cookies to keep track of user profile information
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["newcookie123"];
            if ((myCookies == null) || (myCookies["Name"] == ""))
            {
                Button6.Visible = false;
            }
            else
            {
                Button6.Visible = true;
            }
           
        }
        //Staff Login on button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffLogon.aspx");
        }

        //Staff Page if already logged in else redirect to Staff login
        protected void Button3_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Protected/StaffPage.aspx");
        }

        
        //Member Login
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Logon.aspx");
        }

        //Self register member
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        //clear cookie before signing out
        protected void Button6_Click(object sender, EventArgs e)
        {
            try
            {
                HttpCookie myCookies = Request.Cookies["newcookie123"];
                if ((myCookies != null) || (myCookies["Name"] != ""))
                {
                    HttpCookie myCookie = new HttpCookie("newcookie123");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }
                FormsAuthentication.SignOut();
                string path = "Default.aspx";
                Response.Redirect(path);
            }
            catch (Exception) { }
        }

        //Member Page
        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberPage/DistanceTime.aspx");
        }
    }
}