using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EncryptDecrypt;

namespace assign5
{
    public partial class Register : System.Web.UI.Page
    {
        //on loading page load image using image verifier service from repository
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ImageVerifier.ServiceClient service = new ImageVerifier.ServiceClient();
                string capValue = service.GetVerifierString("4");
                Image1.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + capValue;
                //store the VerifierString in a session
                Session["verifyStr"] = capValue;
            }
        }

        
        //On click register 
        protected void RegisterNewUser(object sender, EventArgs e)
        {
            string Uname = UserName.Text;
            string Mail = Email.Text;
            string Pass = Password.Text; 
            string PassConfirm = ConfirmPassword.Text;
            String captcha = TextBox1.Text;
            Label1.Text = "";
            try
            {
                //Check for all fields
                bool validated = Validate(Uname, Mail, Pass, PassConfirm);
                //if true
                if (validated)
                {
                    //Check session
                    String s = "";
                    if (Session["verifyStr"] != null)
                    {
                        s = Session["verifyStr"].ToString();
                    }
                    //Do image verification validation
                    if (captcha.Equals(s))
                    {
                        registerUser(Uname, Mail, Pass);
                        Response.Redirect("Default.aspx");

                    }
                    else
                    {
                        Label1.Text = "Invalid Image Verification";
                    }
                }
            }
            catch (Exception)
            {
                Label1.Text = "Please register again...";
            }
           
        }

        //Check if all the regestering credentials are in correct format 
        bool Validate(string Uname, string Mail, string Pass, string PassConfirm)
        {
            try
            {
                if (Uname.Equals("") || Mail.Equals("") || Pass.Equals("") || PassConfirm.Equals(""))
                {
                    Label1.Text = "Invalid Details! Enter All Fields";
                    return false;
                }
                else
                {
                    if (Pass.Equals(PassConfirm) && !Pass.Equals(""))
                    {
                        if (!alreadyUser(Uname))
                        {
                            return true;
                        }
                        else
                        {
                            Label1.Text = "Username already exists";
                            return false;
                        }
                    }
                    else
                    {
                        Label1.Text = "Invalid Password";
                        return false;
                    }

                }
            }
            catch (Exception)
            {
                Label1.Text = "Please register again..";
                return false;
            }
        }

        //Check for already existing user
        private bool alreadyUser(string uname)
        {
            //Traverse thru the xml file and check if uname is present already return boolean
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
                    XmlNodeList children = node.ChildNodes;
                    foreach (XmlNode child in node.LastChild.ChildNodes)
                    {
                        if (child.Name == "user")
                        {
                            string user = "";
                            
                            foreach (XmlNode temp in child.ChildNodes)
                            {
                                if (temp.Name == "username")
                                    user = temp.InnerText;
                               
                            }
                            if (user.Equals(uname))
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

        //Append new registered users to users.xml file permanently
        bool registerUser(string uname, string mail, string pass)
        {
            //Creating object for the class in DLL library for encryption
            Cryption enc = new Cryption();
            string fLocation = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/users.xml");
            
            if (File.Exists(fLocation))
            {
               
                XmlDocument doc = new XmlDocument();
                doc.Load(fLocation);

                XmlNode node = doc.CreateNode(XmlNodeType.Element, "user", null);

                XmlNode nodeuname = doc.CreateElement("username");
                nodeuname.InnerText = uname;

                XmlNode nodemail = doc.CreateElement("MailID");
                nodemail.InnerText = mail;

                XmlNode nodepass = doc.CreateElement("password");
                string encryptPass = enc.Encrypt(pass);
                nodepass.InnerText = encryptPass;
                

                node.AppendChild(nodeuname);
                node.AppendChild(nodemail);
                node.AppendChild(nodepass);

                doc.DocumentElement.AppendChild(node);

                doc.Save(fLocation);

            }
            return true;
        }

        //Reload image
        protected void Button1_Click(object sender, EventArgs e)
        {
            ImageVerifier.ServiceClient service = new ImageVerifier.ServiceClient();
            string capValue = service.GetVerifierString("4");
            Image1.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + capValue;
            Session["verifyStr"] = capValue;
        }
    }
}