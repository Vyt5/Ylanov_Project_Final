using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Tutorial.SqlConn
{
    class DBMySQLUtils
    {
        public static MySqlConnection
            GetDBConnection(string host, int port, string datbase, string username, string password)
        {
            //Строка подключения
            String connString = "Server="+host+";Database="+datbase+";port="+port+";User id="+username+";password="+password;
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }

    }
}
