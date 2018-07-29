using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    interface IDatabaseInterface
    {
        void insert(int id, string name, int accType);
        void disp();
        void searchById(int id);
        void depositAmount(int id, int amount);
        void WithdrawlAmount(int id, int amount);
        void CalculateInterest(int id);


    }
}
