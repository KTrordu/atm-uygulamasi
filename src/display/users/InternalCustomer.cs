using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.display.users
{
    public class InternalCustomer : Customer
    {
        public string InternalCustomerID { get; set; }
        public decimal Balance { get; set; } = 0;
        public string CardPIN { get; set; } = "0000";
        public string CardNumber { get; set; } = "0000000000000000";
        public string CardExpiryDate { get; set; } = DateTime.Parse("2034-01-01").ToString("yyyy-MM-dd");
        public string CardStatus { get; set; } = "Passive";

        public InternalCustomer(string firstName, string lastName, string nationalIDNumber, string phoneNumber, string internalCustomerID) 
        : base(firstName, lastName, nationalIDNumber, phoneNumber)
        {
            InternalCustomerID = internalCustomerID;
        }
    }
}