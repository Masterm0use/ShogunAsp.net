﻿using System;
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
        public void InsertProduct(Product product)
        {
            using (OracleConnection connection = Connection)
            {
                string Insert = "INSERT INTO Product (ID, Categorieid, Naam, Beschikbaarheid, PrijsStuk, Aantal, Beschrijving, imageUrl) VALUES (:ID, :CATEGORIEID, :NAAM, :BESCHIKBAARHEID, :PRIJSSTUK, :AANTAL, :BESCHRIJVING, :IMAGEURL)";
                using (OracleCommand command = new OracleCommand(Insert, connection))
                {
                    command.Parameters.Add(new OracleParameter("ID", product.ID));
                    command.Parameters.Add(new OracleParameter("CATEGORIEID", product.Categorie.ID)); // ZIT NOG FOUT IN 
                    command.Parameters.Add(new OracleParameter("NAAM", product.Naam));
                    command.Parameters.Add(new OracleParameter("BESCHIKBAARHEID", product.Beschikbaarheid));
                    command.Parameters.Add(new OracleParameter("PRIJSSTUK", product.PrijsStuk));
                    command.Parameters.Add(new OracleParameter("AANTAL", product.Aantal));
                    command.Parameters.Add(new OracleParameter("BESCHRIJVING", product.Beschrijving));
                    command.Parameters.Add(new OracleParameter("IMAGEURL", product.ImgUrl));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(Product product)
        {
            using (OracleConnection connection = Connection)
            {
                string Update = "UPDATE PRODUCT SET CATEGORIENAAM =:Categorienaam, NAAM =:Naam, BESCHIKBAARHEID =:Beschikbaarheid, PRIJSSTUK =:PrijsStuk, AANTAL =:Aantal, BESCHRIJVING =:Beschrijving, imageUrl =:imageUrl WHERE ID =:ID";
                using (OracleCommand command = new OracleCommand(Update, connection))
                {
                    command.Parameters.Add(new OracleParameter("CATEGORIENAAM", product.Categorie));
                    command.Parameters.Add(new OracleParameter("NAAM", product.Naam));
                    command.Parameters.Add(new OracleParameter("BESCHIKBAARHEID", product.Beschikbaarheid));
                    command.Parameters.Add(new OracleParameter("PRIJSSTUK", product.PrijsStuk));
                    command.Parameters.Add(new OracleParameter("AANTAL", product.Aantal));
                    command.Parameters.Add(new OracleParameter("BESCHRIJVING", product.Beschrijving));
                    command.Parameters.Add(new OracleParameter("imageUrl", product.ImgUrl));
                    command.Parameters.Add(new OracleParameter("ID", product.ID));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void RemoveProduct(Product product)
        {
            using (OracleConnection connection = Connection)
            {
                string delete = "DELETE FROM PRODUCT WHERE ID =" + product.ID;

                using (OracleCommand command = new OracleCommand(delete, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertCart(Product p, Klant k, int aantal)
        {
            
            using (OracleConnection connection = Connection)
            {
                string Insert = "INSERT INTO BESTELLINGPRODUCT (BestellingID, ProductID, AccontID, Aantal) VALUES (seq_bestelling_ID.nextval, :PRODUCTID, :ACCOUNTID, :AANTAL)";
                using (OracleCommand command = new OracleCommand(Insert, connection))
                {
                    command.Parameters.Add(new OracleParameter("PRODUCTID", p.ID ));
                    command.Parameters.Add(new OracleParameter("ACCOUNTID", k.ID));
                    command.Parameters.Add(new OracleParameter("AANTAL", aantal));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void InsertKlant(Klant klant)
        {

            using (OracleConnection connection = Connection)
            {
                string Insert = "INSERT INTO ACCOUNT (ID, Emailadres, Wachtwoord, Voornaam, Achternaam, Geboortedatum, Bedrijf, BtwNummer, Telefoonnummer) VALUES(seq_Account_ID.nextval,':EMAIL', ':WACHTWOORD', ':VOORNAAM',':ACHTERNAAM',':GEBOORTEDATUM', ':BTWNUMMER', ':TELEFOONNUMMER');";
                using (OracleCommand command = new OracleCommand(Insert, connection))
                {
                    command.Parameters.Add(new OracleParameter("EMAIL", klant.Email));
                    command.Parameters.Add(new OracleParameter("WACHTWOORD", klant.Wachtwoord));
                    command.Parameters.Add(new OracleParameter("VOORNAAM", klant.Voornaam ));
                    command.Parameters.Add(new OracleParameter("ACHTERNAAM", klant.Achternaam ));
                    command.Parameters.Add(new OracleParameter("GEBOORTEDATUM",klant.Geboortedatum));
                    command.Parameters.Add(new OracleParameter("BTWNUMMER", 0));
                    command.Parameters.Add(new OracleParameter("TELEFOONNUMMER", 1));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}