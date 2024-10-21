using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.users
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIDNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string DateOfBirth { get; set; } = DateTime.Parse("1970-01-01").ToString("dd/MM/yyyy");

        public Customer(string firstName, string lastName, string nationalIDNumber, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalIDNumber = nationalIDNumber;
            PhoneNumber = phoneNumber;
        }

        public string FullName(string FirstName, string LastName)
        {
            return $"{FirstName} {LastName}";
        }
    }
}