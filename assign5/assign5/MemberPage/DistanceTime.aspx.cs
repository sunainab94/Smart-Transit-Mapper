using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace assign5.MemberPage
{
    public partial class DistanceTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string uname = "";
                HttpCookie myCookies = Request.Cookies["newcookie123"];
                if ((myCookies == null) || (myCookies["Name"] == ""))
                {
                    Label8.Text = "Welcome, new user";
                }
                else
                {
                    Label8.Text = "Welcome, " + myCookies["Name"];
                    uname = myCookies["Name"];
                }
                
                if (uname == "" || (!checkifMember(uname)))
                {
                    Response.Redirect("../Logon.aspx");
                }
               
            }
        }

        //check if member is present in the users.xml
        private bool checkifMember(string name)
        {
            string fLocation = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/users.xml");
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
                    foreach (XmlNode child in node.LastChild.ChildNodes)
                    {
                        if (child.Name == "user")
                        {
                            string user = "";
                            foreach (XmlNode temp in child.ChildNodes)
                            {
                                if (temp.Name == "username")
                                {
                                    user = temp.InnerText;
                                }

                            }
                            if (user.Equals(name))
                            {
                                FS.Close();
                                return true;
                            }
                        }
                    }
                }
            }
            finally
            {
                FS.Close();
            }

            return false;
        }

        //Then access the service to get Distance and time using public google API
        protected void Button1_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            string start = TextBox1.Text;
            string destination = TextBox2.Text;
            string mode = DropDownList1.SelectedValue.ToString();
            string s = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + start + "&destinations=" + destination + "&mode=" + mode;
            s += "&key=AIzaSyA5jF_HdhHH2aQ80evIUrHDhRr9-2nJ64Y";
            string output = client.DownloadString(s);
            dynamic parsed = JObject.Parse(output);

            string distance = "Not Available";
            string time = "Not Available";
            try
            {
                distance = Convert.ToString(parsed["rows"][0]["elements"][0]["distance"]["text"]);
                time = Convert.ToString(parsed["rows"][0]["elements"][0]["duration"]["text"]);
            }
            catch(Exception)
            {

            }
        

            Label3.Text = "Distance : "+distance;
            Label4.Text = "Duration : "+time;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Sign out 
        protected void Button2_Click(object sender, EventArgs e)
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
        }

       
        protected void Button3_Click(object sender, EventArgs e)
        {
            string path = "../Default.aspx";
            Response.Redirect(path);
        }

        //Use session to store destination string to be accessed in Map.aspx
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string destination = TextBox2.Text;
                //Call self implemented map service in assignment 3
                MapService.Service1Client s = new MapService.Service1Client();
                string ss = s.mapService(destination);
                Session["maps"] = ss;
                Response.Redirect("Map.aspx");
            }
            catch (Exception)
            {
                Label3.Text = "Give a Valid Destination";
            }
        }
    }
}