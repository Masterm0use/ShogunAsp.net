using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shogun_WebApplicatie.Csharp 
{
    public abstract class Account
    {
        private readonly int id;
        private readonly string email;
        private readonly string wachtwoord;
        private readonly string voornaam;
        private readonly string achternaam;
        private readonly DateTime geboortedatum;
        private readonly string bedrijfsnaam;
        private readonly string btwNummer;
        private readonly string telefoonNummer;
        private Winkelwagen winkelwagen;

        public int ID { get { return id; } }
        public string Email { get { return email; } }
        public string Wachtwoord{ get { return wachtwoord; } }
        public string Voornaam { get { return voornaam; } }
        public string Achternaam { get { return achternaam; } }
        public DateTime Geboortedatum { get { return geboortedatum; } }
        public string Bedrijfsnaam { get { return bedrijfsnaam; } }
        public string BtwNummer { get { return btwNummer; } }
        public string TelefoonNummer { get { return telefoonNummer; } }
      
        public Account(int id, string email, string wachtwoord, string voornaam, string achternaam, DateTime geboortedatum, string bedrijfsnaam, string btwNummer, string telefoonNummer)
        {
            this.id = id;
            this.email = email;
            this.wachtwoord = wachtwoord;
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.geboortedatum = geboortedatum;
            this.bedrijfsnaam = bedrijfsnaam;
            this.btwNummer = btwNummer;
            this.telefoonNummer = telefoonNummer;
        }

        public override string ToString()
        {
            //override tostring methode om gegevens gemakkelijk weer te geven
            //wachtwoord staat niet in tostring methode (voor nu)    

            return base.ToString();
        }
    }
}
