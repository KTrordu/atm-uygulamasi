using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATMUygulamasi.src.users;

namespace ATMUygulamasi.src.input_output
{
    public class CustomerRepository
    {
        private static CustomerRepository? _instance = null;

        private CustomerRepository() {}

        public static CustomerRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerRepository();
                }
                return _instance;
            }
        }

        public static List<InternalCustomer> customers = [
            new InternalCustomer("John", "Doe", "11111111111", "5051112233", "1"),
            new InternalCustomer("Jane", "Doe", "22222222222", "5051112233", "2")
        ];

        public List<InternalCustomer> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                customers = value;
            }
        }

        /* public InternalCustomer? GetCustomer(string cardNumber, string cardPIN)
        {
            foreach (InternalCustomer customer in customers)
            {
                if (customer.CardNumber == cardNumber && customer.CardPIN == cardPIN)
                    return customer;
            }

            return null;
        }

        public InternalCustomer? GetCustomer(string internalCustomerID)
        {
            foreach (InternalCustomer customer in customers)
            {
                if (customer.InternalCustomerID == internalCustomerID)
                    return customer;
            }

            return null;
        } */
    }
}