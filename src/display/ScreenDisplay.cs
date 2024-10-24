using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.display
{
    public class ScreenDisplay
    {
        public void DisplayStartUpScreen()
        {
            Console.WriteLine("Welcome to the ATM.\n");
            Console.WriteLine("1 - For external customers.");
            Console.WriteLine("2 - For internal customers.");
            Console.WriteLine("! - Type \"exit\" to exit the ATM.\n");
        }
    }
}