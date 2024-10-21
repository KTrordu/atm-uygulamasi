using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.display.users
{
    public class ExternalCustomer : Customer
    {
        public string ExternalCustomerID { get; set; }
        public string ExternalBankName { get; set; }
        public string ExternalAccountID { get; set; }

        public ExternalCustomer(string firstName, string lastName, string nationalIDNumber, string phoneNumber, 
        string externalCustomerID, string externalBankName, string externalAccountID)
        : base(firstName, lastName, nationalIDNumber, phoneNumber)
        {
            ExternalCustomerID = externalCustomerID;
            ExternalBankName = externalBankName;
            ExternalAccountID = externalAccountID;
        }
    }
}