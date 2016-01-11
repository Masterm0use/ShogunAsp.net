using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Shogun_WebApplicatie.database;

namespace Shogun_WebApplicatie.Csharp
{
    public class Administratie
    {
        private Database data;
        private List<Account> accounts;
        private List<Product> products;
        private List<Categorie> categories;

        public List<Account> Accounts
        {
            get { return accounts; }
        }

        public List<Product> Products
        {
            get { return products; }
        }

        public List<Categorie> Categories
        {
            get { return categories; }
        }

        public Administratie()
        {
            data = new Database();
            RefreshData();
        }

        public void RefreshData()
        {
            products = data.GetAllProducten();
            categories = data.GetAllCategories();
        }

        public bool CheckLogin(string username, string password)
        {
            Database.Authentication(username, password);

            if (Database.Authentication(username, password) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AddProduct(Product product)
        {
            foreach (Categorie c in Categories)
            {
                if (FindProduct(product.ID) != null)
                {
                    return false;
                }
                if (c.CategorieNaam != product.Categorie.CategorieNaam) continue;
                product.Categorie.ID = c.ID;
                data.InsertProduct(product);
                RefreshData();
                return true;
            }
            return false;
        }

        public bool ChangeProduct(Product product)
        {
            if (FindProduct(product.ID) != null)
            {
                data.UpdateProduct(product);
                //RefreshClass();
                return true;
            }
            return false;
        }

        public Product FindProduct(string id)
        {
            if (Products != null)
            {
                foreach (Product p in products)
                {
                    if (p.ID == id)
                    {
                        return p;
                    }
                }
            }
            return null;
        }

        public int FindCategorie(string categorie)
        {
            if (Categories != null)
            {
                foreach (Categorie c in categories)
                {
                    if (c.CategorieNaam == categorie)
                    {
                        return c.Parentid;
                    }
                }
            }
            return 0;
        }

        public string GetDataBaseString()
        {
            return data.DatabaseString();
        }

        public List<Winkelwagen> GetOrdersInCart(string mySession)
        {
          return data.GetAllWinkelwagenproducten(mySession);
        }
    }
}
