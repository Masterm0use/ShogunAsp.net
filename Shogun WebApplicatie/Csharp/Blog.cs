using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shogun_WebApplicatie.Csharp
{
    public class Blog
    {
        private int blogID;
        private Medewerker schrijver;
        private string titel;
        private string tekst;
        private DateTime dateUit;
        private List<Reactie> reacties;

        public int BlogID
        {
            get { return blogID; }
        }

        public Medewerker Schrijver
        {
            get { return schrijver; }
        }

        public string Titel
        {
            get { return titel; }
        }

        public string Tekst
        {
            get { return tekst; }
        }

        public DateTime DateUit
        {
            get { return dateUit; }
        }

        public List<Reactie> Reacties
        {
            get { return reacties; }
        }

        public Blog(int blogID, Medewerker schrijver, string titel, string tekst, DateTime dateUit)
        {
            this.blogID = blogID;
            this.schrijver = schrijver;
            this.titel = titel;
            this.tekst = tekst;
            this.dateUit = dateUit;
            this.reacties = new List<Reactie>();
        }

        public void AddComment(Reactie reactie)
        {
            Reacties.Add(reactie);
        }

        public override string ToString()
        {
            string returnstring = titel + " door: " + schrijver + " - " + tekst;
            return returnstring;
        }
    }
}