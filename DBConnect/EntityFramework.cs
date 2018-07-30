using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBConnect
{
    public class EntityFramework : IDatabase
    {
        static BankingDbEntities1 bankingDbEntities = new BankingDbEntities1();
        static users1 user = new users1();
        public void Add()
        {
            int accountId, amount, accountType;
            string customerName;


            Console.WriteLine("Enter Number of Records to be Added");
            int noOfRecords = Convert.ToInt32(Console.ReadLine());
            for (int index = 0; index < noOfRecords; index++)
            {
                Console.WriteLine("Enter {0} Account Id", index + 1);
                accountId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter {0} Customer Name", index + 1);
                customerName = Console.ReadLine();
                Console.WriteLine("Enter Account Type:-\n 1. Saving\n 2. Current\n 3. DMAT");
                accountType = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Insert(accountId, customerName, accountType);
                Console.WriteLine("Data Inserted Succesfully");
            }
        }
            public void Insert(int id, string name, int accType)
            {
              
                user.id = id;
                user.name = name;
                user.accountType = accType;
                user.balance = 0;
                bankingDbEntities.users1.Add(user);
                bankingDbEntities.SaveChanges();
            }
        public void SearchById(int id)
        {
          
                Console.WriteLine("AccountId:-{0} ", bankingDbEntities.users1.Find(id).id);
                Console.WriteLine("CustomerName:-{0}", bankingDbEntities.users1.Find(id).name);
                Console.WriteLine("AccountType:-{0}",bankingDbEntities.users1.Find(id).accountType);
                Console.WriteLine("Balance:-{0}",bankingDbEntities.users1.Find(id).balance);
            

        }
        public void Disp()
        {
            var details = bankingDbEntities.users1.ToList();
            Console.WriteLine("Account Details:-");
            foreach (var detail in details)
            {
                Console.WriteLine("AccountId:-{0} \nCustomerName:-{1}  \nAccountType:-{2} \nBalance:-{3}", detail.id, detail.name, detail.accountType, detail.balance);
                Console.WriteLine();
            }
            Console.WriteLine("");
        }

        public void DepositAmount(int id,int amount)
        {
          var obj = bankingDbEntities.users1.Find(id);
            obj.balance = obj.balance + amount;
            bankingDbEntities.SaveChanges();
            Console.WriteLine("Amount have been added to the account successfully");

        }
        public void WithdrawlAmount(int id, int amount)
        {
            int balance = bankingDbEntities.users1.Find(id).balance;
            
            int type = bankingDbEntities.users1.Find(id).accountType;
            if (type == 1 && balance < 1000)
                Console.WriteLine("Insufficient balance:-Balance cannot be withdrwan");
            else if (type == 2 && balance<0)
                Console.WriteLine("Insufficient balance:-Balance cannot be withdrwan");
            else if (type == 3 && balance < -10000)
                Console.WriteLine("Insufficient balance:-Balance cannot be withdrwan");
            bankingDbEntities.users1.Find(id).balance = balance - amount;
            bankingDbEntities.SaveChanges();
            Console.WriteLine("Amount have been withdrawn");
        }
        public void CalculateInterest(int id)
        {
            int interest = 0;
            int previousBalance = bankingDbEntities.users1.Find(id).balance;
            int type = bankingDbEntities.users1.Find(id).accountType;
            if (type == 1)
                interest = previousBalance * 4 / 100;
            else if (type == 2)
                interest = previousBalance * 4 / 100;
            else
                Console.WriteLine("Interest is not applicable on DMAT account");
            Console.WriteLine("CalculatedInterest:-{0}",interest);
        }

    }
}
