using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Shogun_WebApplicatie.Csharp;

namespace Shogun_WebApplicatie.database
{
    public partial class Database
    {
        
        public List<Product> GetAllProducten()
        {
            List<Categorie> categories = GetAllCategories();
            List<Product> products = new List<Product>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM Product Order by Id";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(CreateProductFromReader(reader, categories));
                        }
                    }
                }
            }
            return products;
        }

        public List<Klant> GetAllKlantenWithoutWinkelWagen()
        {
            List<Klant> klanten = new List<Klant>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM Account a, klant k " +
                               "Order by Id";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            klanten.Add(KlantFromReader(reader));
                        }
                    }
                }
            }
            return klanten;
        }

        private Klant KlantFromReader(OracleDataReader reader)
        {
            bool nieuwsbriefbool = false;
            bool abonnementbool = false;

            int id = Convert.ToInt32(reader["ID"]);
            string email = Convert.ToString(reader["EMAILADRES"]);
            string wachtwoord = Convert.ToString(reader["EMAILADRES"]);
            string voornaam = Convert.ToString(reader["VOORNAAM"]);
            string achternaam = Convert.ToString(reader["achternaam"]);
            DateTime geboortedatum = Convert.ToDateTime(reader["geboortedatum"]);
            int colIndex = Convert.ToInt32(reader.GetOrdinal("BEDRIJF"));
            string bedrijfsnaam = SafeGetString(reader, colIndex);
            int colIndex1 = Convert.ToInt32(reader.GetOrdinal("BTWNUMMER"));
            string btwnummer = SafeGetString(reader, colIndex1);
            int colIndex2 = Convert.ToInt32(reader.GetOrdinal("TELEFOONNUMMER"));
            string telefoonnummer = SafeGetString(reader, colIndex2);
            int nieuwsbrief = Convert.ToInt32(reader["NIEUWSBRIEF"]);
            int abonnement = Convert.ToInt32(reader["abonnement"]);

            if (nieuwsbrief == 0)
            {
                nieuwsbriefbool = false;
            }
            else
                nieuwsbriefbool = true;

            if (abonnement == 0)
            {
                abonnementbool = false;
            }
            else
                abonnementbool = true;


            return new Klant(id, email, wachtwoord, voornaam, achternaam, 
                geboortedatum, bedrijfsnaam, btwnummer, telefoonnummer, nieuwsbriefbool, abonnementbool);
        }

        private Product CreateProductFromReader(OracleDataReader reader, List<Categorie> categories)
        {
            string id = Convert.ToString(reader["ID"]);
            string naam = Convert.ToString(reader["Naam"]);
            string beschikbaarheid = Convert.ToString(reader["beschikbaarheid"]);
            decimal prijsStuk = Convert.ToDecimal(reader["prijsStuk"]);
            int colIndex = Convert.ToInt32(reader.GetOrdinal("aantal"));
            int aantal = SafeGetInt(reader, colIndex);
            string beschrijving = Convert.ToString(reader["beschrijving"]);
            string imgUrl = Convert.ToString(reader["imageUrl"]);
            Categorie localCategorie = null;

            foreach (Categorie categorie in categories)
            {
                if (categorie.ID == Convert.ToInt32(reader["CategorieID"]))
                {
                    localCategorie = categorie;
                }
            }
            return new Product(id, localCategorie, naam, beschikbaarheid, prijsStuk, aantal, beschrijving, imgUrl);
        }

        public List<Categorie> GetAllCategories()
        {
            List<Categorie> categorielList = new List<Categorie>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT * FROM Categories";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorielList.Add(CreateCategorieFromReader(reader));
                        }
                    }
                }
            }
            return categorielList;
        }

        private Categorie CreateCategorieFromReader(OracleDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string categorieNaam = Convert.ToString(reader["CategorieNaam"]);
            int colIndex = Convert.ToInt32(reader.GetOrdinal("parentid"));
            int parentid = SafeGetInt(reader, colIndex);

            return new 
                Categorie(id, categorieNaam, parentid);
        }

        public List<Winkelwagen> GetAllWinkelwagenproducten(string useremail)
        {
            List<Klant> klantenlijst = GetAllKlantenWithoutWinkelWagen();
            List<Product> productenlijst = GetAllProducten();
            List<Winkelwagen> winkelwagens = new List<Winkelwagen>();
            using (OracleConnection connection = Connection)
            {
                string query = "SELECT BP.BestellingID, a.ID, P.ID, BP.AANTAL FROM BESTELLINGPRODUCT BP, ACCOUNT A, PRODUCT P, BESTELLING B " +
                               "WHERE P.ID = BP.PRODUCTID AND B.ID = BP.BESTELLINGID AND A.ID = B.ACCOUNTID " +
                               "AND a.emailadres ="+ "'"+ useremail +"'";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            winkelwagens.Add(CreateWinkelwagenFromReader(reader, productenlijst, klantenlijst));
                        }
                    }
                }
            }
            return winkelwagens;
        }

        private Winkelwagen CreateWinkelwagenFromReader(OracleDataReader reader, List<Product> productenlijst, List<Klant> klantenlijst)
        {
            Dictionary<Product, int> producteninCart = new Dictionary<Product, int>();

            int bestellingid = Convert.ToInt32(reader["BESTELLINGID"]);
            int accountid = Convert.ToInt32(reader["ID"]);
            string productid = Convert.ToString(reader["ID_1"]);
            int aantal = Convert.ToInt32(reader["AANTAL"]);

            Klant klantMetCart = null;
            foreach (Product product in productenlijst)
            {
                if (product.ID == productid)
                {
                    producteninCart.Add(product, aantal);
                }
            }
            foreach (Klant klant in klantenlijst)
            {
                if (klant.ID == accountid)
                {
                    klantMetCart = klant;
                }
            }

            return new
                Winkelwagen(bestellingid, klantMetCart, producteninCart);
        }

        

        private static string SafeGetString(OracleDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            else
                return string.Empty;
        }

        private static int SafeGetInt(OracleDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetInt32(colIndex);
            else
                return 0;
        }
    }
}