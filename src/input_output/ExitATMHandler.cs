using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.input_output
{
    public class ExitATMHandler
    {
        public void ExitATM()
        {
            Console.Clear();
            Console.WriteLine("Exiting the ATM.\n");
            Environment.Exit(0);
        }
    }
}