using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shogun_WebApplicatie.Csharp;

namespace Shogun_WebApplicatie.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestClassKlant()
        {
            DateTime testDatumBirth1 = new DateTime(2001, 1, 1);
            DateTime testDatumBirth2 = new DateTime();

            Klant k = new Klant(1, "123@test.nl", "TestWW", "Test", "Test", testDatumBirth1, "TestDatum", "BTW123456",
                "0613556430", true, true);
            Klant k1 = new Klant(1, "123@test.nl", "TestWW", "Test", "Test", testDatumBirth2, "TestDatum", "BTW123456",
                "0613556430", true, true);

            //Klant Data testen
            Assert.AreEqual(k.Nieuwsbrief, true);
            Assert.AreEqual(k.Abonnement, true);
            Assert.AreEqual(k.Email, "123@test.nl");

            Assert.AreEqual(k.ToString(), "123@test.nl - Test - Test - 0613556430 - 1-1-2001 00:00:00");
            Assert.AreEqual(k1.ToString(), "123@test.nl - Test - Test - 0613556430 - 1-1-0001 00:00:00");
        }

        [TestMethod]
        public void TestClassCategorie()
        {
            Categorie c = new Categorie(1, "Airsoft", 1);


            Assert.AreEqual(c.CategorieNaam, "Airsoft");
            Assert.AreEqual(c.ID, 1);
            Assert.AreEqual(c.Parentid, 1);

            Assert.AreEqual(c.ToString(), "Airsoft");
        }

        [TestMethod]
        public void TestClassMedewerker()
        {
            DateTime testDatumBirth1 = new DateTime(1994, 9, 4);

            Medewerker m = new Medewerker(1, "Marioschi@kpnmail.nl", "TEST", "Mario", "Schipper", testDatumBirth1,
                "Klokuus", "", "0612366666", true);
            Medewerker m1 = new Medewerker(2, "testschi@kpnmail.nl", "TEST", "Mario", "Schipper", testDatumBirth1,
                "Klokuus", "", "0612366666", false);
            Klant k = new Klant(1, "123@test.nl", "TestWW", "Test", "Test", testDatumBirth1, "TestDatum", "BTW123456",
                "0613556430", true, true);

            Assert.AreEqual(m.BewerkRechten, true);
            m.BewerkRechten = false;
            Assert.AreEqual(m.BewerkRechten, false);
            Assert.AreEqual(m.Email, "Marioschi@kpnmail.nl");

            Assert.AreEqual(m.ToString(), "Marioschi@kpnmail.nl - Mario - GeenRechten");
            Assert.AreEqual(m1.ToString(), "testschi@kpnmail.nl - Mario - GeenRechten");
        }

        [TestMethod]

        public void TestClassBlog()
        {
            DateTime testDatumBirth1 = new DateTime(1994, 9, 4);
            DateTime testGeplaatst = new DateTime(2016, 1, 16);

            Medewerker m = new Medewerker(1, "Marioschi@kpnmail.nl", "TEST", "Mario", "Schipper", testDatumBirth1,
                "Klokuus", "", "0612366666", true);
            Klant k = new Klant(1, "123@test.nl", "TestWW", "Test", "Test", testDatumBirth1, "TestDatum", "BTW123456",
                "0613556430", true, true);
            Blog b = new Blog(1, m, "Gratis airsoft geweren.", "Bij een aankoop van 10 eu gratis guns!", testDatumBirth1);
            Reactie r = new BlogReactie(1, k, "Mooie actie!", testGeplaatst, 1);

            //Testen van classe blog:
            b.AddComment(r);
            Assert.AreEqual(b.ToString(),
                "Gratis airsoft geweren. door: Marioschi@kpnmail.nl - Mario - Rechten - Bij een aankoop van 10 eu gratis guns!");

            Assert.AreEqual(b.BlogID, 1);
            Assert.AreEqual(b.BlogID, r.ReactieID);
            Assert.AreEqual(b.DateUit, testDatumBirth1);
            Assert.AreEqual(b.Schrijver.Voornaam, m.Voornaam);
            Assert.AreEqual(b.Tekst, "Bij een aankoop van 10 eu gratis guns!");
            Assert.AreEqual(b.Titel, "Gratis airsoft geweren.");

            //Testen van de classe reactie
            Assert.AreEqual(r.ReactieID, 1);
            Assert.AreEqual(r.Reactieuit, "Mooie actie!");
            Assert.AreEqual(r.Datepost, testGeplaatst);
            Assert.AreEqual(r.SchijverKlant, k);
            Assert.AreEqual(r.ToString(), "Test: Mooie actie!");

        }

        [TestMethod]
        public void TestClassWinkelwagen()
        {
            DateTime testDatumBirth1 = new DateTime(1994, 9, 4);
            Klant k = new Klant(1, "123@test.nl", "TestWW", "Test", "Test", testDatumBirth1, "TestDatum", "BTW123456",
                "0613556430", true, true);
            Categorie c = new Categorie(1, "Airsoft", 1);
            Dictionary<Product, int> productenlist = new Dictionary<Product, int>();
            Product p = new Product("112342", c, "Geweer", "Ja", 10, 1, "mooi", "/Imageurl");
            Product p1 = new Product("112342", c, "Geweer", "Ja", 20, 1, "mooi", "/Imageurl");

            productenlist.Add(p, 4);
            Winkelwagen w = new Winkelwagen(1, k, productenlist);

            //Nu gaan we de methode testen in de winkelwagen. Aangezien de prijs van het product 10eu kost 
            //en we hebben er 4 producten van hetzelfde product erin gedaan. Dus hier moet 40 uitkomen 4*10
            decimal pricetotaal = w.TotaalPrijs();
            Assert.AreEqual(pricetotaal, 40);

            //Nu voegen we nog een product toe van 20 eu, dus nu moet de prijs uitkomen op 60 eu.
            productenlist.Add(p1, 1);
            pricetotaal = 0;
            pricetotaal = w.TotaalPrijs();
            Assert.AreEqual(pricetotaal, 60);

            //De overige get testen.
            Assert.AreEqual(w.ID, 1);
            Assert.AreEqual(w.Klant, k);
        }
    }
}
