using ATMUygulamasi.src.display;
using ATMUygulamasi.src.input_output;
using ATMUygulamasi.src.users;

internal class Program
{
    private static void Main(string[] args)
    {
        ScreenDisplay screenDisplay = new ScreenDisplay();
        OptionHandler optionHandler = new OptionHandler();
        ExternalCustomerHandler externalCustomerHandler = new ExternalCustomerHandler();
        InternalCustomerHandler internalCustomerHandler = new InternalCustomerHandler();

        screenDisplay.DisplayStartUpScreen();
        optionHandler.GetInput();
    }
}