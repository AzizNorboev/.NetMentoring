using System;

namespace EventDelegate
{

    internal class Program
    {
        //public Action<decimal> MyDelegate;
        //public delegate TResult Func<in T, out TResult>(T arg);
        //Predicate<string> val;

        static Account acc = new Account(100);
        static void Main(string[] args)
        {
            acc.OnWithdraw += Acc_OnWithdraw;
            acc.OnInsufficientFund += Acc_OnInsufficientFund;
            acc.OnTopUp += Acc_OnTopUp;
            acc.OnActive += Acc_OnActive;
            acc.OnStart += Acc_OnStart;


            acc.Start();
            Console.WriteLine("----");
            acc.CheckActiveness(acc.Balance);
            Console.WriteLine("----");
            acc.Add(100);
            Console.WriteLine("----");
            acc.Withdraw(200);
            Console.ReadLine();
        }

        private static void Acc_OnStart()
        {
            Console.WriteLine("Process has started");
        }

        private static bool Acc_OnActive(decimal obj)
        {
            if(obj >= 100)
            {
                Console.WriteLine("True");
                return true;
            }
            else
                Console.WriteLine("False");
            return false;

        }

        private static decimal Acc_OnTopUp(decimal arg)
        {
            Console.WriteLine(arg + " has been added to the balance");
            acc.Balance += arg;
            Console.WriteLine($"now balance is: {acc.Balance}");
            return acc.Balance;
        }

        //Обработчик событий
        private static void Acc_OnInsufficientFund(object sender, EventArgs e)
        {
            if(sender is Account)
            Console.WriteLine($"insufficient funds: {((Account)sender).Balance}");
        }

        private static void Acc_OnWithdraw(decimal amount)
        {
            acc.Balance -= amount;
            Console.WriteLine($"${amount} has been Withdrawn");
            Console.WriteLine($"Funds in balance: {acc.Balance}");
        }
    }
}
