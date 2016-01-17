using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shogun_WebApplicatie.Csharp
{
    public class Winkelwagen
    {
        private decimal totalprice;
        public int ID { get; set; }
        public Klant Klant { get; set; }
        public Dictionary<Product , int> AmountProduct  { get; set; }


        public Winkelwagen(int id, Klant klant, Dictionary<Product, int>amountProduct)
        {
            ID = id;
            Klant = klant;
            AmountProduct = amountProduct;
        }

        public decimal TotaalPrijs()
        {
            totalprice = 0;
            foreach (KeyValuePair<Product, int> product in AmountProduct)
            {
                Product p = product.Key;
                p.Aantal = product.Value;

                decimal buffer = p.Aantal*p.PrijsStuk;
                totalprice += buffer;
            }
            return totalprice;
        }
    }
}