using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shogun_WebApplicatie.Csharp;

namespace Shogun_WebApplicatie.Pages.UserControls
{
    public partial class ProductCategorie : System.Web.UI.UserControl
    {
        private Categorie categorie;
        private string HuidigeCategorie;

        public Categorie Categorie { get { return categorie; } set { categorie = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            HuidigeCategorie = Convert.ToString(Request.QueryString["categorienaam"]);
            SelectCategory();
        }

        private void SelectCategory()
        {
            string longurl = Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf('/')) + "Pages/Index.aspx";
            var uriBuilder = new UriBuilder(longurl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["categorienaam"] = Categorie.CategorieNaam;
            uriBuilder.Query = query.ToString();
            longurl = uriBuilder.ToString();

            HyperLink hyperlink = new HyperLink();
            hyperlink.NavigateUrl = longurl;
            hyperlink.Text = Categorie.CategorieNaam;
            hyperlink.CssClass = "list-group-item";

            categorieLink.Controls.Add(hyperlink);
        }
    }
}
