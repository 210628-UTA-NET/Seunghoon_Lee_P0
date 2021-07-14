using System;
using System.Collections.Generic;
using LCGBL;
using LCGModels;

namespace LCGUI
{
    public class CustomerListScreen : IScreen
    {
        private StoreBL _storeBL;
        private Customer _customer = null;
        private List<Customer> _customers;
        public CustomerListScreen(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Render()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Customer List - Enter the customer number to be selected");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            _customers = _storeBL.GetAllCustomers();
            foreach(Customer customer in _customers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("[x] Go Back");            
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }
        public ScreenType GetRoute()
        {
            Console.Write("-> ");
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "x":
                    return ScreenType.CustomerScreen;
                default :
                    _customer = _storeBL.GetCustomerByID(Int32.Parse(userInput));
                    if(_customer != null)
                    {
                        Current.CurrentCustomerID = _customer.CustomerID;
                        Current.CurrentCustomerName = _customer.FirstName + " " + _customer.LastName;
                        return ScreenType.MainScreen;
                    }
                    else 
                    {
                        Console.WriteLine("Your input is not valid! Press any key to continue... ");
                        Console.ReadLine();
                        return ScreenType.CustomerListScreen;
                    }

            }

        }
    }
}