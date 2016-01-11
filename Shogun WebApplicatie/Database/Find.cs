using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Shogun_WebApplicatie.Csharp;

namespace Shogun_WebApplicatie.database
{
    public partial class Database
    {
        public static Boolean Authentication(string username, string password)
        {
            using (OracleConnection connection = Connection)
            {
                string query = "Select EMAILADRES, Wachtwoord from Account where EMAILADRES='" + username +
                               "' and Wachtwoord ='" + password + "'";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            return true;
                        else
                            return false;
                    }
                }
            }
        }
    }
}
            

