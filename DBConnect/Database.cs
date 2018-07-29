using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace DBConnect
{
    public class Database
    {
        public SqlConnection connect()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = "Data Source=Cyberkid;Initial Catalog= dbname;Integrated Security=true";
                cn.Open();
                return cn;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return cn;
            }
        }
    }
}
