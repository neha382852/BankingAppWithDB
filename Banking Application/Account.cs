using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnect;
using System.Data.SqlClient;
namespace Banking_Application
{
   public class Account
    {
        IDatabase db;
        public Account()
        {
            string connectionType = System.Configuration.ConfigurationManager.AppSettings["db"];
            if (connectionType.Equals("ADO.NET"))
                db = new Database();
            else if (connectionType.Equals("ENTITYFRAMEWORK"))
                db = new EntityFramework();
        }
        
        public void AddAccount()
        {
            db.Add();
        }
        public void Insert(int id, string name, int accType)
        {
            db.Insert(id, name, accType);
        }
        public void Disp()
        {
            db.Disp();
        }
        public void SearchById(int id)
        {
            db.SearchById(id);
        }
        public void DepositAmount(int id, int amount)
        {
            db.DepositAmount(id, amount);
        }
        public void WithdrawlAmount(int id, int amount)
        {
            db.WithdrawlAmount(id, amount);
        }
        public void CalculateInterest(int id)
        {
            db.CalculateInterest(id);
        }

    }
}


