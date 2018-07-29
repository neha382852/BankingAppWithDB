using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnect;
using System.Data.SqlClient;
namespace Banking_Application
{
    class Account
    {
        static Database db = new Database();
        public void insert(int id, string name, int accType)
        {
            db.insert(id, name, accType);
        }
        public void disp()
        {
            db.disp();
        }
        public void searchById(int id)
        {
            db.searchById(id);
        }
        public void depositAmount(int id, int amount)
        {
            db.depositAmount(id, amount);
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


