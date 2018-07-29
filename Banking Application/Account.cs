using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnect;
using System.Data.SqlClient;
namespace Banking_Application
{
    class Account:IDatabaseInterface
    {
        static Database ob = new Database();
        public void insert(int id,string name,int accType)
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "insert into users values(" + id + "," + name + "," + accType + ","+0+")";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void disp()
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "select * from users";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.NextResult())
            {
                Console.WriteLine("Id:"+reader.GetValue(0));
                Console.WriteLine("Name:" + reader.GetValue(1));
                Console.WriteLine("Account Type:" + reader.GetValue(2));
                Console.WriteLine("Total Amount:" + reader.GetValue(3));
            }
            conn.Close();
        }
        public void searchById(int id)
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "select * from users where id=" + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.NextResult())
            {
                Console.WriteLine("Id:" + reader.GetValue(0));
                Console.WriteLine("Name:" + reader.GetValue(1));
                Console.WriteLine("Account Type:" + reader.GetValue(2));
                Console.WriteLine("Total Amount:" + reader.GetValue(3));
            }
            
            conn.Close();
        }
        public void depositAmount(int id,int amount)
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "update users set balance=balance+" + amount + " where id=" + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void WithdrawlAmount(int id, int amount)
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "select * from users where id=" + id + "";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int check=0;
            if (reader.NextResult())
            {
                int balance = (int)reader.GetValue(3);
                int accType = (int)reader.GetValue(2);
                if (accType == 1 && balance < 1000)
                    Console.WriteLine("Insufuccient balance you can not withdraw money");
                else if (accType == 2 && balance < 0)
                    Console.WriteLine("Insufuccient balance you can not withdraw money");
                else if (accType == 3 && balance < -10000)
                    Console.WriteLine("Insufuccient balance you can not withdraw money");
                else
                    check = 1;
            }
            conn.Close();
            conn = ob.connect();
            if (check == 1)
            {
                string sqlQueryNew = "update users set balance=balance-" + amount + " where id=" + id;
                SqlCommand cmdNew = new SqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void CalculateInterest(int id)
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "select * from users where id="+id+"";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.NextResult())
            {
                int amount = (int)reader.GetValue(3);
                int accType = (int)reader.GetValue(2);
                if (accType == 1)
                    Console.WriteLine("Calculated Interest=" + amount * 4 / 100);
                else if (accType == 2)
                    Console.WriteLine("Calculated Interest=" + amount * 1 / 100);
                else
                    Console.WriteLine("Invalid Account Type");
            }
            conn.Close();
        }

    }
}


