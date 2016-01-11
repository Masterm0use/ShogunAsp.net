using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shogun_WebApplicatie.Csharp;

namespace Shogun_WebApplicatie
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private Administratie admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Administratie();
            List<Product> products = admin.Products;

            if (products != null)
            {
                foreach (Product product in products)
                {
                    Panel productPanel = new Panel();
                    ImageButton imageButton = new ImageButton
                    {
                        ImageUrl = "~/Images/Producten/" + product.ImgUrl,
                        CssClass = "productImage",
                        PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", product.ID)
                    };
                    Label lblName = new Label
                    {
                        Text = product.Naam,
                        CssClass = "productName"
                    };
                    Label lblPrice = new Label
                    {
                        Text = " €" + product.PrijsStuk,
                        CssClass = "productPrice"
                    };

                    productPanel.Controls.Add(imageButton);
                    productPanel.Controls.Add(new Literal {Text = "<br/>"});
                    productPanel.Controls.Add(lblName);
                    productPanel.Controls.Add(new Literal {Text = "<br/>"});
                    productPanel.Controls.Add(lblPrice);

                    // aanmaken van dynamic controls
                    pnlProducts.Controls.Add(productPanel);
                }
            }
            else
                pnlProducts.Controls.Add(new Literal {Text = "Er zijn geen producten gevonden"});
        }
    }
}

        
    