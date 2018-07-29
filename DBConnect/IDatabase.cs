using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnect
{
    interface IDatabase
    {
        void insert(int id, string name, int accType);
        void Disp();
        void SearchById(int id);
        void DepositAmount(int id, int amount);
        void WithdrawlAmount(int id, int amount);
        void CalculateInterest(int id);
    }
}
