using System;

namespace LCGUI
{
    public class CustomerScreen : IScreen
    {
        public void Render()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Customer - Select your choice");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("[1] Show all customers");
            Console.WriteLine("[2] Search customer by phone number");
            Console.WriteLine("[3] Add new customer");
            Console.WriteLine("[x] Go back");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        public ScreenType GetRoute()            
        {
            Console.Write("-> ");
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                    return ScreenType.CustomerListScreen;
                case "2":
                    return ScreenType.SearchCustomerByPhoneNumberScreen;
                case "3":
                    return ScreenType.AddCustomerScreen;
                case "x":
                    return ScreenType.MainScreen;
                default :
                    Console.WriteLine("Your input is not valid! Press any key to continue... ");
                    Console.ReadLine();
                    return ScreenType.MainScreen;
            }
        }
    }
}