using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.input_output
{
    public class ExternalCustomerHandler : ICustomerHandler
    {
        public void DisplayCustomerScreen(ExitATMHandler exitATMHandler)
        {
            Console.Clear();
            Console.WriteLine("\n*** External Customer Processes ***");
            System.Console.WriteLine("1 - ");
        }
    }
}