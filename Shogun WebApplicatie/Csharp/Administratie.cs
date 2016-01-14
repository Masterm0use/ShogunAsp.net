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
        private List<Klant> klanten;
        private List<Product> products;
        private List<Categorie> categories;

        public List<Klant> Klanten
        {
            get { return klanten; }
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
            klanten = data.GetAllKlantenWithoutWinkelWagen();
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

        public Klant FindKlant(Klant klant)
        {
            if (Klanten != null)
            {
                foreach (Klant k in klanten)
                {
                    if (k.Email == klant.Email)
                    {
                        return klant ;
                    }
                }
            }
            return null;
        }
        public bool AddKlant(Klant klant)
        {
            foreach (Klant k in klanten)
            {
                if (FindKlant(klant.Email) != null)
                {
                    return false;
                }
                data.InsertKlant(klant);
                RefreshData();
                return true;
            }
            return false;
        }



        public Klant FindKlant(string email)
        {
            if (Klanten != null)
            {
                foreach (Klant k in klanten)
                {
                    if (k.Email == email)
                    {
                        return k;
                    }
                }
            }
            return null;
        }

        public bool AddProductToWinkelwagen(Product product, Klant klant, int aantal)
        {
           data.InsertCart(product, klant, aantal);
            {
                return true;
            }
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
