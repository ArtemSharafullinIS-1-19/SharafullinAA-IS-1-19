using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnDBDLL
{
    public class Class1
    {
        public static class ConnBaza
        {
            public static MySqlConnection ConnBaz(string connStr)
            {

                string port = "33333";
                string host = "caseum.ru";
                string user = "test_user";
                string password = "test_pass";
                string db = "db_test";
                connStr = $"server={host};port={port};user={user};database={db};password={password};";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
        }
    }
}
