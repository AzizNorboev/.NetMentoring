using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDelegate
{
    public class Account
    {

        public delegate void MyDelegate();
        public event MyDelegate OnStart;

        public event Action<decimal> OnWithdraw;
        public event Func<decimal, decimal> OnTopUp;
        public event Predicate<decimal> OnActive;
        //An event handler in C# is a delegate with a special signature, given below. The first parameter (sender) in
        //the above declaration specifies the object that fired the event. The second parameter (e) of the above declaration
        //holds data that can be used in the event handler
        public event EventHandler OnInsufficientFund;
        public decimal Balance { get; set; }
        public int AccountNumber = new Random().Next(1000, 9999);
        public bool IsActive { get; set; }

        public Account(decimal balance)
        {
            Balance = balance;
        }
        public void Start()
        {
            OnStart?.Invoke();
        }

        public void CheckActiveness(decimal amount)
        {
            OnActive?.Invoke(amount);
        }
        public void Withdraw(decimal amount)
        {
            if(Balance >= amount)
            {
                OnWithdraw?.Invoke(amount);
            }
            else
                OnInsufficientFund?.Invoke(this, null);
        }
        public void Add(decimal amount)
        {
            OnTopUp?.Invoke(amount);
        }
    }
}
