using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace assign5.MemberPage
{
    public partial class Map : System.Web.UI.Page
    {
        //on page load display map obtained from stored value in session 
        protected void Page_Load(object sender, EventArgs e)
        {
            string s= (string)Session["maps"];
            outputlist.Text = (string)Session["maps"];
        }
    }
}