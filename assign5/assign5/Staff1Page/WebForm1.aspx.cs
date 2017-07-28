using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace assign5.Staff1Page
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }       

        //News Focus Service implemented by Admin already deployed in webstrar not accessible to staff
        protected void findnews_Click(object sender, EventArgs e)
        {
            NewsWeatherService.Service1Client s = new NewsWeatherService.Service1Client();
            string[] topics = NewsTextBox1.Text.Split(' ');
            string list = null;
            try
            {
                //call method NewsFocus using service
                string[] listUrl = s.NewsFocus(topics);

                if (listUrl[0] == "No URL found. Invalid input.")
                {
                    list += "<br />" + listUrl[0];
                }
                else
                {
                    //get the URLs by iterating over URL list
                    for (int i = 0; i < listUrl.Length; i++)
                    {
                        list += "<br />" + "<a href=" + listUrl[i] + " runat=\"server\">" + listUrl[i] + "</a>";
                    }
                }
            }
            catch (Exception) { }
            Newsoutputlist.Text = list;
        }

        //Go back to public page
        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = "../Default.aspx";
            Response.Redirect(path);
        }
    }
}