using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shogun_WebApplicatie.Csharp;
using System.IO;
using System.Collections;

namespace Shogun_WebApplicatie
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private Administratie admin;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                admin = new Administratie();
                FillhoofdList();
                GetImages();
              }
            else admin = new Administratie();
            return;
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            Product product = new Product(txtID.Text, new Categorie(0,ddlCategorie.SelectedValue,0), txtName.Text, txtBeschikbaar.Text, Convert.ToDecimal(txtPrice.Text), 0, txtDescription.Text, ddlImage.SelectedValue);
            admin.AddProduct(product);
        }

        public void FillhoofdList()
        {
            //DropDown Categorie zal hier worden gebonden aan de Dropdown.
            List<Categorie>parentCategories = new List<Categorie>();
            foreach (Categorie c in admin.Categories)
            {
                if (c.Parentid == 0)
                {
                    parentCategories.Add(c);
                }
            }
             
            ddlCategorieParanet.DataSource = parentCategories;
            ddlCategorieParanet.DataBind();
        }

        //Het vullen van de listen
        public void FillSubList(int idHoofdcategorie)
        {
            List<Categorie> subCats = new List<Categorie>();
            foreach (Categorie c in admin.Categories)
            {
                if (c.Parentid == idHoofdcategorie)
                {
                    subCats.Add(c);
                }
            }
            ddlCategorie.DataSource = subCats;
            ddlCategorie.DataBind();
        }


        private void GetImages()
        {
            try
            {
                //Het op halen van de filepaths
                string[] images = Directory.GetFiles(Server.MapPath("~/Images/Producten/"));
                //Alle namen ophalen en vullen
                ArrayList imageList = new ArrayList();
                foreach (string image in images)
                {
                    string imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    imageList.Add(imageName);
                }
                //De arry bounde in de ddl.
                ddlImage.DataSource = imageList;
                ddlImage.AppendDataBoundItems = true;
                ddlImage.DataBind();
            }
            catch (Exception e)
            {
                lblResult.Text = e.ToString();
            }
        }

        protected void ddlCategorieParanet_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlCategorieParanet.SelectedItem.Text;

            foreach (Categorie c in admin.Categories)
            {
                if (c.CategorieNaam == selected)
                {
                    int CatID = c.ID;
                    FillSubList(CatID);
                }
            }
        }
        
        protected void ddlCategorie_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlCategorie.SelectedItem.Text;

            foreach (Categorie c in admin.Categories)
            {
                if (c.CategorieNaam == selected)
                {
                     int test = c.ID;
                }
            }
        }
    }
}