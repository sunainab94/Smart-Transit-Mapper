using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EncryptDecrypt;

namespace assign5
{
    public partial class StaffLogon : System.Web.UI.Page
    {
        //on page load use cookie to store  information about different staff
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpCookie myCookies = Request.Cookies["newcookie123"];
                if ((myCookies == null) || (myCookies["Name"] == ""))
                {
                    Output.Text = "Welcome, new user";
                }
                else
                {
                    Output.Text = "Already logged in as , " + myCookies["Name"];
                }

            }
        }

        //On button click login staff
        protected void LoginFunc(object sender, EventArgs e)
        {
            //if myAuthenticate returns true after parsing staff.xml
            if (myAuthenticate(UserName.Text, Password.Text))
            {
                HttpCookie myCookies = new HttpCookie("newcookie123");
                myCookies["Name"] = UserName.Text;
                myCookies.Expires = DateTime.Now.AddMonths(6);
                Response.Cookies.Add(myCookies);
                FormsAuthentication.RedirectFromLoginPage(UserName.Text, Persistent.Checked);
            }
            else
                Output.Text = "Invalid login";
        }

        //Parse staff.xml file to check for valid credentials
        bool myAuthenticate(string username, string password)
        {
            //Creating object for the class in DLL library
            Cryption dec = new Cryption();
            //Virtual path
            string fLocation = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/staff.xml");
            FileStream FS = null;
            try
            {
                if (File.Exists(fLocation))
                {
                    FS = new FileStream(fLocation, FileMode.Open);
                    XmlDocument xd = new XmlDocument();
                    xd.Load(FS);
                    XmlNode node = xd;
                    XmlNodeList children = node.FirstChild.ChildNodes;
                    //Parse staff.xml
                    foreach (XmlNode child in node.LastChild.ChildNodes)
                    {
                        if (child.Name == "staff")
                        {
                            string user = "";
                            string pass = "";
                            foreach (XmlNode temp in child.ChildNodes)
                            {
                                if (temp.Name == "username")
                                    user = temp.InnerText;
                                else if (temp.Name == "password")
                                {
                                    string ecryptPass = temp.InnerText;
                                    pass = dec.Decrypt(ecryptPass);
                                  
                                }

                            }
                            //checking credentials
                            if (user.Equals(username) && pass.Equals(password))
                            {
                                FS.Close();
                                return true;
                            }
                        }
                    }
                }
            }
            finally { FS.Close(); }
                
            return false;
        }
    }
}