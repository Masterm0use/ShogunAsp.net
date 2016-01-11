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

            if ((Session["Check"] != null) && (Convert.ToBoolean(Session["Check"]) == true))
            {
                // Als de user is ingelogd zal de user door verbonden worden
                if (User.Identity.IsAuthenticated)
                    Response.Redirect("~/Pages/Index.aspx");
            }
        }

        protected void Login1_Authenticate1(object sender, AuthenticateEventArgs e)
        {
            Boolean blnresult = false;

            //Er zal ingelogd worden, als de user in de database staat zal er een true terug komen.
            blnresult =
                admin.CheckLogin(Login1.UserName, Login1.Password);


            // Als er true terug komt.
            if (blnresult == true)
            {
                // Hiermee Authenticate we de user.
                e.Authenticated = true;
                // Vervolgens store ik dat in de session
                Session["Check"] = true;
                Session["EmailAccout"] = Login1.UserName;
                string mySession = (string)Session["EmailAccout"];
                Response.Redirect("~/Pages/Index.aspx");
                
            }
            else
                //Als het wachtwoord niet goed is zal er false uitkomen.
                e.Authenticated = false;
        }
    }
}
