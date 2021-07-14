using System;
using System.Collections.Generic;
using LCGBL;
using LCGDL;
using LCGModels;

namespace LCGUI
{
    public class OrderHistoryScreen : IScreen
    {
        private StoreBL _storeBL;
        private List<Order> _orders;
        public OrderHistoryScreen(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }

        public void Render()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Order History - Enter order number to see lineitems");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            _orders = _storeBL.GetOrdersByCustomerID(Current.CurrentCustomerID);
            foreach(Order order in _orders)
            {
                Console.WriteLine(order);
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
                    return ScreenType.MainScreen;
                default :
                    {
                        Console.WriteLine("Your input is not valid! Press any key to continue... ");
                        Console.ReadLine();
                        return ScreenType.OrderHistoryScreen;
                    }
            }
        }
    }
}