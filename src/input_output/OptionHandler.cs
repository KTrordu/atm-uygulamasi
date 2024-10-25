using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATMUygulamasi.src.display;

namespace ATMUygulamasi.src.input_output
{
    public class OptionHandler
    {
        public void GetMainScreenInput(ICustomerHandler externalCustomerHandler, 
        ICustomerHandler internalCustomerHandler, ExitATMHandler exitATMHandler, ScreenDisplay screenDisplay)
        {
            bool shouldExit = false;
            while (!shouldExit)
            {
                Console.Clear();
                screenDisplay.DisplayStartUpScreen();
                try
                {
                    string? readResult = Console.ReadLine();
                    if (readResult == null || readResult.Trim().Equals(""))
                        throw new IOException("Please enter a non-empty value.\n");
                    else
                    {
                        switch (readResult.ToLower().Trim())
                        {
                            case "1":
                                externalCustomerHandler.DisplayCustomerScreen(exitATMHandler);
                                break;
                            case "2":
                                internalCustomerHandler.DisplayCustomerScreen(exitATMHandler);
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
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    screenDisplay.DisplayStartUpScreen();
                }
            }
        }
    }
}