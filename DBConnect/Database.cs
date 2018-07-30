using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace DBConnect
{
    public class Database:IDatabase
    {
        static Database ob = new Database();
        public SqlConnection connect()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = "Data Source=TAVDESK042;Initial Catalog= BankingDb;Integrated Security=true";
                cn.Open();
                return cn;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return cn;
            }
        }
        public void Add()
        {
            int accountId,accountType;
            string customerName;


            Console.WriteLine("Enter Number of Records to be Added");
            int noofrecords = Convert.ToInt32(Console.ReadLine());
            for (int index = 0; index < noofrecords; index++)
            {
                Console.WriteLine("Enter {0} Account Id", index + 1);
                accountId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter {0} Customer Name", index + 1);
                customerName = Console.ReadLine();
                Console.WriteLine("Enter Account Type:-\n 1. Saving\n 2. Current\n 3. DMAT");
                accountType = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Insert(accountId, customerName, accountType);
                Console.WriteLine("Data Inserted");
            }
        }
        public void Insert(int id, string name, int accType)
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "insert into users1 values(" + id + ",'" + name + "'," + accType + "," + 0 + ")";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Console.WriteLine();
        }
        public void Disp()
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "select * from users1";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Id:" + reader.GetValue(0));
                Console.WriteLine("Name:" + reader.GetValue(1));
                Console.WriteLine("Account Type:" + reader.GetValue(2));
                Console.WriteLine("Total Amount:" + reader.GetValue(3));
            }
            conn.Close();
            Console.WriteLine();
        }
        public void SearchById(int id)
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "select * from users1 where id=" + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("Id:" + reader.GetValue(0));
                Console.WriteLine("Name:" + reader.GetValue(1));
                Console.WriteLine("Account Type:" + reader.GetValue(2));
                Console.WriteLine("Total Amount:" + reader.GetValue(3));
            }

            conn.Close();
            Console.WriteLine();
        }
        public void DepositAmount(int id, int amount)
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "update users1 set balance=balance+" + amount + " where id=" + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Money has been deposited to the account");
            conn.Close();
            Console.WriteLine();
        }
        public void WithdrawlAmount(int id, int amount)
        {
            SqlConnection conn = ob.connect();

            string accountAndBalance = GetAccountTypeWithBalance(id);
            string[] dataSplit = accountAndBalance.Split('-');
            if (dataSplit[0].Equals("1") && Convert.ToInt32(dataSplit[1]) < 1000)
                Console.WriteLine("Insufficient Balance");
            else if (dataSplit[0].Equals("2") && Convert.ToInt32(dataSplit[1]) < 0)
                Console.WriteLine("Insufficient Balance");
            else if (dataSplit[0].Equals("3") && Convert.ToInt32(dataSplit[1]) < -10000)
                Console.WriteLine("Insufficient Balance");
            else
            {
                string sqlQuery = "update users1 set balance=balance-" + amount + "where id=" + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Money has been withdrawn from the account");
                conn.Close();
                Console.WriteLine();

            }
        }
        public static string GetAccountTypeWithBalance(int id)
        {
            string accountAndBalance = "";
            SqlConnection conn = ob.connect();
            string sqlQuery = "select * from users1 where id=" + id;
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                accountAndBalance = reader.GetValue(2) + "-" + reader.GetValue(3);
            }

            conn.Close();
            return accountAndBalance;
        }
        public void CalculateInterest(int id)
        {
            SqlConnection conn = ob.connect();
            string sqlQuery = "select * from users1 where id=" + id + "";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
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
