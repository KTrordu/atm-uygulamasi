using ATMUygulamasi.src.display;
using ATMUygulamasi.src.input_output;
using ATMUygulamasi.src.users;

internal class Program
{
    private static void Main(string[] args)
    {
        ScreenDisplay screenDisplay = new ScreenDisplay();
        OptionHandler optionHandler = new OptionHandler();
        ICustomerHandler externalCustomerHandler = new ExternalCustomerHandler();
        ICustomerHandler internalCustomerHandler = new InternalCustomerHandler();
        ExitATMHandler exitATMHandler = new ExitATMHandler();

        optionHandler.GetMainScreenInput(externalCustomerHandler, internalCustomerHandler, exitATMHandler, screenDisplay);
    }
}