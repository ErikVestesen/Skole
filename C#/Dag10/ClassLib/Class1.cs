using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Account
    {
        private int balance = 0;
        public int Balance
        {
            get { return balance; }
        }

        int minBalance;
        public int MinBalance { get { return minBalance; } set { minBalance = value; } }


        public void deposit(int amount)
        {
            balance += amount;
        }
        public void withdraw(int amount)
        {
            if (balance - amount < minBalance)
            {
                throw new IlligalWithdrawException("Du kraftedme fattig");
            } 
            balance -= amount;
        }
    }

    public class IlligalWithdrawException : Exception
    {
        public IlligalWithdrawException() { }
        public IlligalWithdrawException(string message) : base(message) { }
    }

    public class Customer
    {
        public List<Account> accounts = new List<Account>();
        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }
    }
}
