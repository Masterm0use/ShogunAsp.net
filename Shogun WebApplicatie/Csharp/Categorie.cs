using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shogun_WebApplicatie.Csharp
{
    public class Categorie
    {
        private int id;
        private string categorieNaam;
        private int parentid;
        public int ID { get; set; }
        public string CategorieNaam { get; set; }
        public int Parentid { get; set; }

        public Categorie(int id, string categorieNaam, int parentid)
        {
            this.ID = id;
            this.CategorieNaam = categorieNaam;
            this.Parentid = parentid;
        }

        // ReSharper disable once RedundantOverridenMember
        public override string ToString()
        {
            return CategorieNaam;
        }
    }
}