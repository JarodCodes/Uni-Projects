using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            string account;

            while(done == false)
            {
                account = GetAccount();
                if(account == "x")
                {
                    done = true;
                }
                else
                {
                    DetermineResult(account);
                }
            }
        }
        static public string GetAccount()
        {
            Console.Write("Enter type of account (s for Savings, or c for Cheque): ");

            return Console.ReadLine().ToLower();
        }
        static public void DetermineResult(string account)
        {
            double balance, min, interest;
            Console.Write("\nEnter minimum balance: ");
            min = double.Parse(Console.ReadLine());
            Console.Write("\nEnter current balance of customer: ");
            balance = double.Parse(Console.ReadLine());

            if(balance < min)
            {
                if(account == "s")
                {
                    Console.WriteLine("\nService charge of R50.00 must be paid");
                    balance -= 50;
                    Console.WriteLine("Final balance = {0}", balance);
                }
                else
                {
                    Console.WriteLine("\nService charge of R125.00 must be paid");
                    balance -= 125;
                    Console.WriteLine("Final balance = {0}", balance);
                }
            }
            else
            {
                if (account == "s")
                {
                    interest = balance * 0.04;
                    balance += interest;
                    Console.WriteLine("\nInterest = R{0}", interest);
                    Console.WriteLine("\nFinal balance = R{0}\n", balance);
                }
                else if(balance > min + 10000)
                {
                    interest = balance * 0.03;
                    balance += interest;
                    Console.WriteLine("\nInterest = R{0}", interest);
                    Console.WriteLine("\nFinal balance = R{0}\n", balance);
                }
                else
                {
                    interest = balance * 0.05;
                    balance += interest;
                    Console.WriteLine("\nInterest = R{0}", interest);
                    Console.WriteLine("\nFinal balance = R{0}\n", balance);
                }
            }
        }

    }
}
