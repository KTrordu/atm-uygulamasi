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
                    else if(!int.TryParse(readResult.Trim(), out int cardNumber))
                        throw new IOException("Please enter a valid card number and pin.\n");
                    else if(readResult.Trim().Length != 20)
                        throw new IOException("Your card number must be 20 characters long and your pin must be 4 characters long.\n");
                    else
                    {
                        string cardNumberEntered = readResult.Trim().Substring(0, 16);
                        string cardPINEntered = readResult.Trim().Substring(16, 4);
                        List<string> cardDetailsEntered = new List<string>() { cardNumberEntered, cardPINEntered };

                        if (AuthenticateCustomer(customerRepository, cardDetailsEntered) != null)
                            internalCustomerLoggedIn = AuthenticateCustomer(customerRepository, cardDetailsEntered);
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

        private InternalCustomer? AuthenticateCustomer(CustomerRepository customerRepository, List<string> cardDetailsEntered)
        {
            foreach (InternalCustomer customer in customerRepository.Customers)
            {
                if (cardDetailsEntered[0] == customer.CardNumber && cardDetailsEntered[1] == customer.CardPIN)
                {
                    return customer;
                }
            }

            return null;
        }
    }
}