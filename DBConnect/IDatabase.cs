using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnect
{
    interface IDatabase
    {
        void insert(int id, string name, int accType);
        void disp();
        void searchById(int id);
        void depositAmount(int id, int amount);
        void WithdrawlAmount(int id, int amount);
        void CalculateInterest(int id);
    }
}
