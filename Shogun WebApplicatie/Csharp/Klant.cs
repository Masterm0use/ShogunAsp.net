using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shogun_WebApplicatie.Csharp
{
    public class Klant : Account
    {
        private bool abonnement;
        private bool nieuwsbrief;

        public bool Nieuwsbrief { get; set; }
        public bool Abonnement { get; set; }


        public Klant(int id, string email, string wachtwoord, string voornaam, string achternaam, DateTime geboortedatum, string bedrijfsnaam, string btwNummer, string telefoonNummer, bool nieuwsbrief, bool abonnement) 
            : base(id, email, wachtwoord, voornaam, achternaam, geboortedatum, bedrijfsnaam, btwNummer, telefoonNummer)
        {
            this.abonnement = abonnement;
            this.nieuwsbrief = nieuwsbrief;
        }
    }
}