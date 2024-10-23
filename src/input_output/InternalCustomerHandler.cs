using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATMUygulamasi.src.users;

namespace ATMUygulamasi.src.input_output
{
    public class InternalCustomerHandler : ICustomerHandler
    {
        public void DisplayCustomerScreen(ExitATMHandler exitATMHandler)
        {
            Console.Clear();
            Console.WriteLine("\n*** Internal Customer Processes ***");
            Console.WriteLine("1 - Login with your card number.");
            Console.WriteLine("2 - Return to main menu.");
            Console.WriteLine("! - Type \"exit\" to exit the ATM.\n");

            GetCustomerInput(exitATMHandler);
        }

        public void DisplayLoginScreen()
        {
            Console.WriteLine("\n*** Login ***\n");
            Console.WriteLine("Please enter your card number and your card pin with 1 space between them.\n");
            Console.WriteLine("Type \"exit\" to exit the ATM.\n");

        }

        private void GetCustomerInput(ExitATMHandler exitATMHandler)
        {
            bool shouldExit = false;
            CustomerRepository customerRepository = CustomerRepository.Instance;

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
                                LoginWithCardNumber(exitATMHandler, customerRepository);
                                break;
                            case "2":
                                shouldExit = true;
                                break;
                            case "exit":
                                exitATMHandler.ExitATM();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void LoginWithCardNumber(ExitATMHandler exitATMHandler, CustomerRepository customerRepository)
        {
            Console.Clear();
            DisplayLoginScreen();
            InternalCustomer? internalCustomerLoggedIn = null;

            bool shouldExit = false;

            while (!shouldExit)
            {
                try
                {
                    string? readResult = Console.ReadLine();

                    if (readResult == null || readResult.ToLower().Trim().Equals(""))
                        throw new IOException("Please enter a non-empty value.\n");
                    else if (!readResult.Any(char.IsDigit))
                        throw new IOException("Please enter a valid card number and pin.\n");
                    else if (readResult.Count(count => count != ' ') != 20 || readResult.Split(" ")[0].Length != 16 || readResult.Split(" ")[1].Length != 4)
                        throw new IOException("Your card number must be 16 characters long and your pin must be 4 characters long.\n");
                    else if (readResult.ToLower().Trim() == "exit")
                        exitATMHandler.ExitATM();
                    else
                    {
                        string[] cardDetailsEntered = readResult.Split(" ");
                        string cardNumberEntered = cardDetailsEntered[0];
                        string cardPINEntered = cardDetailsEntered[1];
                        List<string> cardDetailsToCheck = new List<string>() { cardNumberEntered, cardPINEntered };

                        if (AuthenticateCustomer(customerRepository, cardDetailsToCheck) != null)
                        {
                            internalCustomerLoggedIn = AuthenticateCustomer(customerRepository, cardDetailsToCheck);
                            Console.WriteLine("\nYou have successfully logged in.\n");
                        }
                        else
                        {
                            throw new IOException("Your card number or pin is incorrect.\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private InternalCustomer? AuthenticateCustomer(CustomerRepository customerRepository, List<string> cardDetailsToCheck)
        {
            foreach (InternalCustomer customer in customerRepository.Customers)
            {
                if (cardDetailsToCheck[0] == customer.CardNumber && cardDetailsToCheck[1] == customer.CardPIN)
                {
                    return customer;
                }
            }

            return null;
        }
    }
}