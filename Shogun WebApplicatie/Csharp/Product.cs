using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shogun_WebApplicatie.Csharp
{
    public class Product
    {
        public string ID { get; set; }
        public Categorie Categorie { get; set; }
        public string Naam { get; set; }
        public string Beschikbaarheid { get; set; }
        public decimal PrijsStuk { get; set; }
        public int Aantal { get; set; }
        public string Beschrijving { get; set; }
        public string ImgUrl { get; set; }


        public Product(string id, Categorie categorie, string naam, string beschikbaarheid, decimal prijsStuk, int aantal, string beschrijving, string imgUrl)
        {
            ID = id;
            Categorie = categorie;
            Naam = naam;
            Beschikbaarheid = beschikbaarheid;
            PrijsStuk = prijsStuk;
            Aantal = aantal;
            Beschrijving = beschrijving;
            ImgUrl = imgUrl;
        }
    }
}