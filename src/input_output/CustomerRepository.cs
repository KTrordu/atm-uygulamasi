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
            new InternalCustomer("John", "Doe", "1"),
            new InternalCustomer("Jane", "Doe", "2")
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
    }
}