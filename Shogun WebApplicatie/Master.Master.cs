using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shogun_WebApplicatie
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmailAccout"] != null)
            {
                btnLogin.Text = "Logout";
                btnLogin.NavigateUrl = "/Pages/Inlog.aspx?logout";

                if (Request.Url.ToString().EndsWith("?logout"))
                {
                    Session.RemoveAll();
                    Response.Redirect("/Pages/Inlog.aspx");
                }
            }
        }
    }
}