using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATMUygulamasi.src.card;

namespace ATMUygulamasi.src.users
{
    public class InternalCustomer : Customer
    {
        public string InternalCustomerID { get; set; }
        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            private set { _balance = value; }
        }

        public Card card{ get; set; } = new Card("0000", "0000000000000000", DateTime.Now.AddYears(5).ToString("MM/yy"));

        public InternalCustomer(string firstName, string lastName, string internalCustomerID,
        decimal balance = 100)
        : base(firstName, lastName)
        {
            InternalCustomerID = internalCustomerID;
            Balance = balance;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount > Balance)
                    throw new ArgumentOutOfRangeException("Amount cannot be greater than the balance.");
            else Balance -= amount;
        }

        public void DepositMoney(decimal amount)
        {
            Balance += amount;
        }
    }
}