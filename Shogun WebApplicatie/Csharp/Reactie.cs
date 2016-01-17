using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shogun_WebApplicatie.Csharp
{
    public abstract class Reactie
    {
        private int reactieID;
        private Klant schijverKlant;
        private string reactieuit;
        private DateTime datepost;

        public int ReactieID { get { return reactieID; } }
        public Klant SchijverKlant { get { return schijverKlant; } }
        public string Reactieuit { get { return reactieuit; } }
        public DateTime Datepost { get { return datepost; } }

        public Reactie(int reactieID, Klant schijverKlant, string reactieuit, DateTime datepost)
        {
            this.reactieID = reactieID;
            this.schijverKlant = schijverKlant;
            this.reactieuit = reactieuit;
            this.datepost = datepost;
        }

        public override string ToString()
        {
            string returnReactie = schijverKlant.Voornaam + ": " + reactieuit;
            return returnReactie;
        }
    }
}
