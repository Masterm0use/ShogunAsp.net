using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shogun_WebApplicatie.Csharp;

namespace Shogun_WebApplicatie
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private Administratie admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Administratie();
            FillPage();
        }

        private void FillPage()
        {
            //Ophalen van het id in de querystring.
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                string id = Convert.ToString(Request.QueryString["id"]);
                Product product = admin.FindProduct(id);

                //Het vullen van de pagina met de opgehalde data.
                lblTitle.Text = product.Naam;
                lblDescription.Text = product.Beschrijving;
                lblPrice.Text = "Price per unit:<br/>€ " + product.PrijsStuk;
                imgProduct.ImageUrl = "~/Images/Producten/" + product.ImgUrl;
                lblItemNr.Text = product.ID;

                int[] amount = Enumerable.Range(1, 20).ToArray();
                ddlAmount.DataSource = amount;
                ddlAmount.AppendDataBoundItems = true;
                ddlAmount.DataBind();
            }
        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                string mySession = (string) Session["EmailAccout"];
                if (mySession != null)
                {
                    string id = (Request.QueryString["id"]);
                    int amount = Convert.ToInt32(ddlAmount.SelectedValue);
                    bool Gelukt = admin.AddProductToWinkelwagen(admin.FindProduct(id), admin.FindKlant(mySession), amount);

                    if (!Gelukt)
                    {
                        lblResult.Text = "Product bestaat al in uw winkelwagen.";
                    }

                }
                else
                {
                    lblResult.Text = "Please log in to order items";
                }
            }
        }
    }
}