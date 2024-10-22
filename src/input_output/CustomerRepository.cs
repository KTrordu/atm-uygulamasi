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

        private CustomerRepository() { }

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

        public static List<Customer> customers = [
            new InternalCustomer("John", "Doe", "11111111111", "5051112233", "1")
        ];

        public List<Customer> Customers
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