using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shogun_WebApplicatie;
using Shogun_WebApplicatie.Csharp;

namespace Shogun_WebApplicatie.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void Initialize()
        {
            
        }
        [TestMethod]
        public void TestClassKlant()
        {
            DateTime testDatumBirth1 = new DateTime(2001, 1, 1);
            DateTime testDatumBirth2 = new DateTime();

            Klant k = new Klant(1, "123@test.nl", "TestWW", "Test", "Test", testDatumBirth1, "TestDatum", "BTW123456", "0613556430", true, true);
            Klant k1 = new Klant(1, "123@test.nl", "TestWW", "Test", "Test", testDatumBirth2, "TestDatum", "BTW123456", "0613556430", true, true);

            //Klant Data testen
            Assert.AreEqual(k.Nieuwsbrief, true);
            Assert.AreEqual(k.Abonnement, true);
            Assert.AreEqual(k.Email, "123@test.nl");

            Assert.AreEqual(k.ToString(), "123@test.nl - Test - Test - 0613556430 - 1-1-2001 00:00:00");
            Assert.AreEqual(k1.ToString(), "123@test.nl - Test - Test - 0613556430 - 1-1-0001 00:00:00");
        }
    }
}
