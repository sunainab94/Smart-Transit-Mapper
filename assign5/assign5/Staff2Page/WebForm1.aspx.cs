using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace assign5.Staff2Page
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }       

        //Weather Service implemented by Staff, admin cant access this
        protected void get_Weather(object sender, EventArgs e)
        {
            try
            {
                NewsWeatherService.Service1Client d = new NewsWeatherService.Service1Client();
                string input;
                string[] output = new string[15];

                input = WeatherTextBox1.Text;
                output = d.Weather5day(input);
                Thread.Sleep(500);
                if (output[0] == "Enter a valid zipcode")
                {
                    Label18.Text = output[0];
                    Label4.Text = "NULL";
                    Label7.Text = "NULL";
                    Label10.Text = "NULL";
                    Label13.Text = "NULL";
                    Label15.Text = "NULL";

                    Label5.Text = "NULL";
                    Label8.Text = "NULL";
                    Label11.Text = "NULL";
                    Label14.Text = "NULL";
                    Label16.Text = "NULL";

                    Label6.Text = "NULL";
                    Label9.Text = "NULL";
                    Label12.Text = "NULL";
                    Label17.Text = "NULL";
                    Label19.Text = "NULL";
                }
                else
                {
                    Label4.Text = output[0];
                    Label7.Text = output[1];
                    Label10.Text = output[2];
                    Label13.Text = output[3];
                    Label15.Text = output[4];

                    Label5.Text = output[5];
                    Label8.Text = output[6];
                    Label11.Text = output[7];
                    Label14.Text = output[8];
                    Label16.Text = output[9];

                    Label6.Text = output[10];
                    Label9.Text = output[11];
                    Label12.Text = output[12];
                    Label17.Text = output[13];
                    Label19.Text = output[14];
                }
            }
            catch (Exception)
            {
                Label18.Text = "Enter Valid Zip code";
            }
        }

        //Go back to Public page
        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = "../Default.aspx";
            Response.Redirect(path);
        }
    }
}