using System;

namespace LCGUI
{
    public class MainScreen : IScreen
    {
        public void Render()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Main - Select your choice");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine($"[1] Store                       : {Current.CurrentStoreName}");
            Console.WriteLine($"[2] Customer                    : {Current.CurrentCustomerName}");
            Console.WriteLine("[3] Store inventory list");
            Console.WriteLine("[4] Place an order");
            Console.WriteLine("[5] Order history");
            Console.WriteLine("[x] Exit");
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }
        public ScreenType GetRoute()
        {
            Console.Write("-> ");
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                    return ScreenType.SelectStoreScreen;
                case "2":
                    return ScreenType.CustomerScreen;
                case "3":
                    return ScreenType.StoreInventoryListScreen;
                case "4":
                    return ScreenType.PlaceOrderScreen;
                case "5":
                    return ScreenType.OrderHistoryScreen;
                case "x":
                    return ScreenType.Exit;
                default :
                    Console.WriteLine("Your input is not valid! Press any key to continue... ");
                    Console.ReadLine();
                    return ScreenType.MainScreen;
            }
        }

    }
}