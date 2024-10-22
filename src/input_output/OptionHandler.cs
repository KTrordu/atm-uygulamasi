using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMUygulamasi.src.input_output
{
    public class OptionHandler : IInputHandler
    {
        public string GetInput()
        {
            try
            {
                bool shouldExit = false;

                while (!shouldExit)
                {
                    string? readResult = Console.ReadLine();
                    if (readResult == null || readResult.ToLower().Trim().Equals(""))
                        throw new IOException("Please enter a non-empty value.");
                    else return readResult;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new IOException("An error occurred. Please contact your program supplier.").Message;
        }
    }
}