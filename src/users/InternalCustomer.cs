using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string CardPIN { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDate { get; set; } = DateTime.Now.AddYears(5).ToString("MM/yy");

        public InternalCustomer(string firstName, string lastName, string internalCustomerID,
        decimal balance = 100, string cardPIN = "0000", string cardNumber = "0000000000000000")
        : base(firstName, lastName)
        {
            InternalCustomerID = internalCustomerID;
            Balance = balance;
            CardPIN = cardPIN;
            CardNumber = cardNumber;
        }

        public void SetBalance(decimal amount, bool isWithdraw = true)
        {
            if (!isWithdraw)
            {
                Balance += amount;
            }
            else
            {
                if (amount > Balance)
                    throw new ArgumentOutOfRangeException("Amount cannot be greater than the balance.");
                else Balance -= amount;
            }
        }
    }
}