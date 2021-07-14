using System;
using LCGBL;
using LCGModels;

namespace LCGUI
{
    public class AddCustomerScreen : IScreen    
    {
        private static Customer _newCustomer = new Customer();
        private IStoreBL _storeBL;
        public AddCustomerScreen(IStoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Render()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("New Customer - Enter the number of item you want to add or edit");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("[1] First name   : " + _newCustomer.FirstName);
            Console.WriteLine("[2] Last name    : " + _newCustomer.LastName);
            Console.WriteLine("[3] Email        : " + _newCustomer.Email);
            Console.WriteLine("[4] Phone number : " + _newCustomer.PhoneNumber);
            Console.WriteLine("[5] Street       : " + _newCustomer.Street);
            Console.WriteLine("[6] City         : " + _newCustomer.City);
            Console.WriteLine("[7] State        : " + _newCustomer.State);
            Console.WriteLine("[8] ZIP Code     : " + _newCustomer.Zip);
            Console.WriteLine("[9] Add Customer");
            Console.WriteLine("[x] Go Back");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        public ScreenType GetRoute()            
        {
            Console.Write("-> ");
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                    Console.Write("First name: ");
                    _newCustomer.FirstName = Console.ReadLine();
                    return ScreenType.AddCustomerScreen;
                case "2":
                    Console.Write("Last name: ");
                    _newCustomer.LastName = Console.ReadLine();
                    return ScreenType.AddCustomerScreen;
                case "3":
                    Console.Write("Email: ");
                    _newCustomer.Email = Console.ReadLine();
                    return ScreenType.AddCustomerScreen;
                case "4":
                    Console.Write("Phone number: ");
                    _newCustomer.PhoneNumber = Console.ReadLine();
                    return ScreenType.AddCustomerScreen;
                case "5":
                    Console.Write("Street address: ");
                    _newCustomer.Street = Console.ReadLine();
                    return ScreenType.AddCustomerScreen;
                case "6":
                    Console.Write("City: ");
                    _newCustomer.City = Console.ReadLine();
                    return ScreenType.AddCustomerScreen;
                case "7":
                    Console.Write("State: ");
                    _newCustomer.State = Console.ReadLine();
                    return ScreenType.AddCustomerScreen;
                case "8":
                    Console.Write("ZIP code: ");
                    _newCustomer.Zip = Console.ReadLine();
                    return ScreenType.AddCustomerScreen;
                case "9":
                    _storeBL.AddCustomer(_newCustomer);
                    Current.CurrentCustomerID = _newCustomer.CustomerID;
                    Current.CurrentCustomerName = _newCustomer.FirstName + " " + _newCustomer.LastName;
                    return ScreenType.MainScreen;
                case "x":
                    return ScreenType.CustomerScreen;
                default :
                    Console.WriteLine("Your input is not valid! Press any key to continue... ");
                    Console.ReadLine();
                    return ScreenType.AddCustomerScreen;
            }
        }
    }
}