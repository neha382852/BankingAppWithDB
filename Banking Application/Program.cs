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
            
         
            int flag = 1,amount;
            do
            {
                Console.Write("\n 1. To add account\n 2. To check Account Details\n 3. Search by Account ID \n 4. To deposit money\n 5. To withdraw money\n 6. To Calulate Interest on an account \n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        account.AddAccount();
                        break;
                    case 2:
                        account.Disp();      

                        break;
                    case 3:
                        Console.WriteLine("Enter Id");
                        int accountNumber = int.Parse(Console.ReadLine());
                        account.SearchById(accountNumber);
                        break;
                    case 4:
                        Console.WriteLine("Enter Id");
                        accountNumber=int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter amount");
                        amount = int.Parse(Console.ReadLine());
                        account.DepositAmount(accountNumber,amount);
                        break;
                    case 5:
                        Console.WriteLine("Enter Id");
                        accountNumber=int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter amount");
                        amount = int.Parse(Console.ReadLine());
                        account.WithdrawlAmount(accountNumber,amount);
                        break;
                    case 6:
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
        }
    }
}
