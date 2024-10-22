using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.users
{
    public class InternalCustomer : Customer
    {
        public string InternalCustomerID { get; set; }
        public decimal Balance { get; set; }
        public string CardPIN { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDate { get; set; }
        public string CardStatus { get; set; }

        public InternalCustomer(string firstName, string lastName, string nationalIDNumber, string phoneNumber, string internalCustomerID,
        decimal balance = 0, string cardPIN = "0000", string cardNumber = "0000000000000000", string cardExpiryDate = "2034-01-01",
        string cardStatus = "Passive") 
        : base(firstName, lastName, nationalIDNumber, phoneNumber)
        {
            InternalCustomerID = internalCustomerID;
            Balance = balance;
            CardPIN = cardPIN;
            CardNumber = cardNumber;
            CardExpiryDate = cardExpiryDate;
            CardStatus = cardStatus;
        }
    }
}