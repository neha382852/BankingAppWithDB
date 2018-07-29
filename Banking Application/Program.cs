using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    class Program
    {

        static Account account = new Account();
        static void Main(string[] args)
        {
            
            int accountId,amount,accountType;
            string customerName;
          
          
             Console.WriteLine("Enter Number of Records to be Added");
            int noofrecords = Convert.ToInt32(Console.ReadLine());
            for (int index = 0; index < noofrecords; index++)
            {
                Console.WriteLine("Enter {0} Account Id",index+1);
                accountId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter {0} Customer Name",index+1);
                customerName = Console.ReadLine();
                Console.WriteLine("Enter Account Type:-\n  1. Saving\n 2. Current\n 3. DMAT");
                accountType = int.Parse(Console.ReadLine());
                Console.WriteLine();
                account.insert(accountId, customerName, accountType);
                Console.WriteLine("Data Inserted");
            }
            int flag = 1;
            do
            {
                Console.Write("Enter \n 1. To check Account Details\n 2. Search by Account ID \n 3. To deposit money\n 4. To withdraw money\n 5. To Calulate Interest on an account \n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        account.disp();            //Reference parameter passed
                        break;
                    case 2:
                        int accountNumber = int.Parse(Console.ReadLine());
                        account.searchById(accountNumber);
                        break;
                    case 3:
                        Console.WriteLine("Enter Id");
                        accountNumber=int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter amount");
                        amount = int.Parse(Console.ReadLine());
                        account.depositAmount(accountNumber,amount);
                        break;
                    case 4:
                        Console.WriteLine("Enter Id");
                        accountNumber=int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter amount");
                        amount = int.Parse(Console.ReadLine());
                        account.WithdrawlAmount(accountNumber,amount);
                        break;
                    case 5:
                        Console.WriteLine("Enter Id");
                        accountNumber = int.Parse(Console.ReadLine());
                        account.CalculateInterest(accountNumber);
                        break;
                    default:
                        Console.WriteLine("Invalid Entry!");
                        break;

                }
                Console.WriteLine("Enter 1 to Continue and 0 To Stop :- ");
                Console.WriteLine();
                flag = int.Parse(Console.ReadLine());
            }
            while (flag == 1);
            Console.ReadKey();
        }
    }
}
