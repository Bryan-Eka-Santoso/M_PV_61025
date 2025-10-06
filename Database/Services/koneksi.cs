using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public static class koneksi
    {
        static string host = "localhost";
        static string dbName = "warung";
        static string username = "root";
        static string password = "";

        static MySqlConnection conn;
        public static void open()
        {
            conn = new MySqlConnection(
                $"server={host};" +
                $"database={dbName};" +
                $"username={username};" +
                $"password={password}"
                );
            conn.Open();
        }
        public static MySqlConnection getConn()
        {
            return conn;
        }
        public static void close()
        {
            conn.Close();
        }
    }
}
