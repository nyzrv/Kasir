using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp3
{
    class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = (@"Data Source = LAPTOP-4K0HTB1A\RIZKA; initial catalog = DB_makanan; integrated security = true");
            return Conn;


        }

    }
}
