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
        //username en password moeten nog worden ingevuld voor je eigen databaseinstellingen;
        private static string dataUser = "Software";
        private static string dataPass = "Welkom123";
        private static string dataSrc = "//localhost:1521/XE";
        private static readonly string ConnectionString = "User Id=" + dataUser + ";Password=" + dataPass + ";Data Source=" + dataSrc + ";";

        public static OracleConnection Connection
        {
            get
            {
                OracleConnection connection = new OracleConnection(ConnectionString);
                connection.Open();
                return connection;
            }
        }

        public string DatabaseString()
        {
            return
                ConnectionString;
        }

    }
}