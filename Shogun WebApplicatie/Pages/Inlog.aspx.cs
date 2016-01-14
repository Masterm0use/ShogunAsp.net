using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Shogun_WebApplicatie.Csharp;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Shogun_WebApplicatie
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Administratie admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Administratie();

            if (Request.Url.ToString().EndsWith("?logout"))
            {
                Response.Write("<script language=\"javascript\">alert('" + "You have succesfully logged out!" +
                               "');</script>");
            }
        }

        protected void btnInloggen_Click(object sender, EventArgs e)
        {
            Boolean blnresult = false;
            blnresult =
                admin.CheckLogin(tbxInputUsername.Text, tbxInputPassword.Text);

            if (blnresult)
            {
                Session["Check"] = true;
                Session["EmailAccout"] = tbxInputUsername.Text;
                string mySession = (string) Session["EmailAccout"];
                Response.Redirect("~/Pages/Index.aspx");
            }
            else
            {
                errorLabel.Text = "Incorrect Username or Password";
            }
        }
    }
}
    
