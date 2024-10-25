using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.users
{
    public class ExternalCustomer : Customer
    {
        public string ExternalCustomerID { get; set; }

        public ExternalCustomer(string firstName, string lastName, string externalCustomerID)
        : base(firstName, lastName)
        {
            ExternalCustomerID = externalCustomerID;
        }
    }
}