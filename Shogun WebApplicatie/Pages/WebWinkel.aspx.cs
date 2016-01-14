using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Shogun_WebApplicatie.Csharp;

namespace Shogun_WebApplicatie
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private Administratie admin;

        protected void Page_Load(object sender, EventArgs e)
        {
            admin = new Administratie();
            string mySession = (string) Session["EmailAccout"];
            GetPurchasesInCart(mySession);
        }

        private void GetPurchasesInCart(string mySession)
        {
            double subTotal = 0;
            
            //Alle producten van de user die in de cart zitten.
            List<Winkelwagen> purchaseList = admin.GetOrdersInCart(mySession);
            CreateShopTable(purchaseList, out subTotal);

            //Aantal toevoegen aan de webpagina.
            double vat = subTotal * 0.21;
            double totalAmount = subTotal + 15 + vat;

            litTotal.Text = "€" + subTotal;
            litVat.Text = "€" + vat;
            litTotalAmount.Text = "€" + totalAmount;
        }

        private void CreateShopTable(IEnumerable<Winkelwagen> winkelwagens, out double subTotal)
        {
            subTotal = new double();


            foreach (Winkelwagen winkelwagen in winkelwagens)
            {
                Dictionary<Product, int> productenlist = new Dictionary<Product, int>();
                productenlist = winkelwagen.AmountProduct;

                //Het maken van de html en alle producten daar aantoevoegen die in de cart zitten
                foreach (KeyValuePair<Product, int> product in productenlist)
                {
                    Product p = product.Key;
                    p.Aantal = product.Value;
                    ImageButton btnImage = new ImageButton
                    {
                        ImageUrl = string.Format("~/Images/Producten/{0}", p.ImgUrl),
                        PostBackUrl = string.Format("~/Pages/Product.aspx?id={0}", p.ID)
                    };

                    LinkButton lnkDelete = new LinkButton
                    {
                        PostBackUrl = string.Format("~/Pages/ShoppingCart.aspx?productId={0}", p.ID),
                        Text = "Delete Item",
                        ID = "del" + p.ID,
                    };

                    lnkDelete.Click += Delete_Item;


                    int[] amount = Enumerable.Range(1, 20).ToArray();
                    DropDownList ddlAmount = new DropDownList
                    {
                        DataSource = amount,
                        AppendDataBoundItems = true,
                        AutoPostBack = true,
                        ID = p.ID.ToString()
                    };
                    ddlAmount.DataBind();
                    ddlAmount.SelectedValue = p.Aantal.ToString();
                    ddlAmount.SelectedIndexChanged += ddlAmount_SelectedIndexChanged;

                    //Table maken en vervolgens vullen
                    Table table = new Table {CssClass = "CartTable"};
                    TableRow row1 = new TableRow();
                    TableRow row2 = new TableRow();

                    TableCell cell1_1 = new TableCell {RowSpan = 2, Width = 50};
                    TableCell cell1_2 = new TableCell
                    {
                        Text = string.Format("<h4>{0}</h4><br />{1}<br/>In Stock",
                            p.Naam, "Product nummer:" + p.ID),
                        HorizontalAlign = HorizontalAlign.Left,
                        Width = 350,
                    };
                    TableCell cell1_3 = new TableCell {Text = "Price per<hr/>"};
                    TableCell cell1_4 = new TableCell {Text = "Aantal<hr/>"};
                    TableCell cell1_5 = new TableCell {Text = "Totaal:<hr/>"};
                    TableCell cell1_6 = new TableCell();

                    TableCell cell2_1 = new TableCell();
                    TableCell cell2_2 = new TableCell {Text = "€" + p.PrijsStuk};
                    TableCell cell2_3 = new TableCell();
                    TableCell cell2_4 = new TableCell
                    {
                        Text = "€" + Math.Round(((Convert.ToDecimal(1)*p.PrijsStuk)), 2)
                    };
                        // product aantal aapassen
                    TableCell cell2_5 = new TableCell();



                    //De buttons vullen
                    cell1_1.Controls.Add(btnImage);
                    cell1_6.Controls.Add(lnkDelete);
                    cell2_3.Controls.Add(ddlAmount);

                    //De rows en cells adde
                    row1.Cells.Add(cell1_1);
                    row1.Cells.Add(cell1_2);
                    row1.Cells.Add(cell1_3);
                    row1.Cells.Add(cell1_4);
                    row1.Cells.Add(cell1_5);
                    row1.Cells.Add(cell1_6);

                    row2.Cells.Add(cell2_1);
                    row2.Cells.Add(cell2_2);
                    row2.Cells.Add(cell2_3);
                    row2.Cells.Add(cell2_4);
                    row2.Cells.Add(cell2_5);
                    table.Rows.Add(row1);
                    table.Rows.Add(row2);
                    pnlShoppingCart.Controls.Add(table);

                    //TODO: vul totaalprice in..

                }
            }
        }

        private void Delete_Item(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ddlAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
 