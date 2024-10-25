using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATMUygulamasi.src.users;

namespace ATMUygulamasi.src.input_output
{
    public class ExternalCustomerHandler : ICustomerHandler
    {
        public void DisplayCustomerScreen(ExitATMHandler exitATMHandler)
        {
            Console.Clear();
            Console.WriteLine("*** External Customer Processes ***\n");
            Console.WriteLine("1 - To become a customer.");
            Console.WriteLine("2 - Return to main menu.");
            Console.WriteLine("! - Type \"exit\" to exit the ATM.\n");

            GetCustomerInput(exitATMHandler);
        }

        private void GetCustomerInput(ExitATMHandler exitATMHandler)
        {
            bool shouldExit = false;

            while (!shouldExit)
            {
                try
                {
                    string? readResult = Console.ReadLine();
                    if (readResult == null || readResult.ToLower().Trim().Equals(""))
                        throw new IOException("Please enter a non-empty value.\n");
                    else
                    {
                        switch (readResult.ToLower().Trim())
                        {
                            case "1":
                                MakeCustomer();
                                break;
                            case "2":
                                shouldExit = true;
                                break;
                            case "exit":
                                exitATMHandler.ExitATM();
                                break;
                            default:
                                throw new IOException("Please enter a valid option.\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void MakeCustomer()
        {
            Console.Clear();
            Console.WriteLine("*** New Customer Registration ***\n");

            bool shouldExit = false;
            
            try
            {
                while (!shouldExit)
                {
                    Console.WriteLine("Enter your first name: ");
                    string? firstName = Console.ReadLine();
                    if (firstName == null || firstName.ToLower().Trim().Equals(""))
                        throw new IOException("Please enter a non-empty value.\n");

                    Console.WriteLine("Enter your last name: ");
                    string? lastName = Console.ReadLine();
                    if (lastName == null || lastName.ToLower().Trim().Equals(""))
                        throw new IOException("Please enter a non-empty value.\n");

                    Console.WriteLine("Enter your external customer ID: ");
                    string? externalCustomerID = Console.ReadLine();
                    if (externalCustomerID == null || externalCustomerID.ToLower().Trim().Equals("") || externalCustomerID.Any(char.IsLetter))
                        throw new IOException("Please enter a valid value.\n");

                    if (int.Parse(externalCustomerID) == CustomerRepository.Instance.Customers.Count)
                        externalCustomerID = (CustomerRepository.Instance.Customers.Count + 1).ToString();

                    ExternalCustomer newCustomer = new ExternalCustomer(firstName, lastName, externalCustomerID);
                    CreateInternalCustomer(newCustomer);
                    shouldExit = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CreateInternalCustomer(ExternalCustomer newCustomer)
        {
            CustomerRepository customerRepository = CustomerRepository.Instance;

            Console.Clear();
            Console.WriteLine("Please enter your 4-digit card PIN: ");

            bool shouldExit = false;
            while (!shouldExit)
            {
                try
                {
                    string? readResult = Console.ReadLine();
                    if (readResult == null || readResult.ToLower().Trim().Equals(""))
                        throw new IOException("Please enter a non-empty value.\n");
                    else if (readResult.Length != 4)
                        throw new IOException("Please enter a 4-digit value.\n");
                    else if (readResult.Any(char.IsLetter))
                        throw new IOException("Please only enter numbers.");
                    else
                    {
                        string cardNumber = GenerateCardNumber();
                        string cardPIN = readResult;
                        InternalCustomer newInternalCustomer = new InternalCustomer(newCustomer.FirstName, newCustomer.LastName, 
                        newCustomer.ExternalCustomerID, cardPIN: cardPIN, cardNumber: cardNumber);
                        customerRepository.Customers.Add(newInternalCustomer);

                        Console.WriteLine($"Your card number is: {newInternalCustomer.CardNumber}");
                        Console.WriteLine($"Your card expiration date is: {newInternalCustomer.CardExpiryDate}");
                        Console.WriteLine($"Your Internal Customer ID is: {newInternalCustomer.InternalCustomerID}");
                        Console.WriteLine($"Your balance is: {newInternalCustomer.Balance}");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        shouldExit = true;

                        LoginNewCustomer(newInternalCustomer);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string GenerateCardNumber()
        {
            Random random = new Random();
            string cardNumber = "";

            for (int i = 0; i <= 3; i++)
            {
                cardNumber += random.Next(1000, 9999).ToString();
            }

            return cardNumber;
        }

        private void LoginNewCustomer(InternalCustomer internalCustomer)
        {
            InternalCustomerHandler internalCustomerHandler = new();
            internalCustomerHandler.DisplayCustomerScreen(new ExitATMHandler());
        }
    }
}