using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shogun_WebApplicatie.Csharp
{
    
    public class Medewerker : Account
    {
        private bool bewerkRechten;
        public bool BewerkRechten { get; set; }

        public Medewerker(int id, string email, string wachtwoord, string voornaam, string achternaam, DateTime geboortedatum, string bedrijfsnaam, string btwNummer, string telefoonNummer, bool bewerkRechten) 
            : base(id, email, wachtwoord, voornaam, achternaam, geboortedatum, bedrijfsnaam, btwNummer, telefoonNummer)
        {
            this.BewerkRechten = bewerkRechten;
        }

        public override string ToString()
        {
            string bewerkRechtentostring = "Rechten";
            if (!BewerkRechten)
            {
                bewerkRechtentostring = "GeenRechten";
                return Email + " - " + Voornaam + " - " + bewerkRechtentostring;
            }
            else
            {
                return Email + " - " + Voornaam + " - " + bewerkRechtentostring;
            }
        }
    }
}