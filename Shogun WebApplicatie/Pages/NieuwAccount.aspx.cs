using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shogun_WebApplicatie.Csharp;

namespace Shogun_WebApplicatie
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private Administratie admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Administratie();
        }

        protected void OnClick(object sender, EventArgs e)
        {
            try
            {
                int year = Convert.ToInt32(tbxGeboortedatumJaar.Text);
                int month = Convert.ToInt32(tbxGeboortedatumMaand.Text);
                int day = Convert.ToInt32(tbxGeboortedatumDag.Text);
                DateTime geboorteDateTime = new DateTime(year, month, day);

                admin.AddKlant(new Klant(0, tbxEmail.Text, tbxWachtwoord.Text, tbxVoornaam.Text, tbxAchternaam.Text,
                    geboorteDateTime, "Geen", "Geen", tbxMobielnummer.Text, cbxNieuwsbrief.Checked, cbxSMSfunctie.Checked));

                Response.Redirect("/Pages/Inlog.aspx");
            }
            catch
            {

            }
        }
    }
}