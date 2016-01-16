using System;
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

            Assert.AreEqual(b.ToString(), "Gratis airsoft geweren. door: Marioschi@kpnmail.nl - Mario - Rechten - Bij een aankoop van 10 eu gratis guns!");

            // Assert.AreEqual(b,"" );
            Assert.AreEqual(b.BlogID, 1);
            Assert.AreEqual(b.DateUit, testDatumBirth1);
            Assert.AreEqual(b.Schrijver.Voornaam, m.Voornaam);
            Assert.AreEqual(b.Tekst, "Bij een aankoop van 10 eu gratis guns!");
            Assert.AreEqual(b.Titel, "Gratis airsoft geweren.");


        }
    }
}
