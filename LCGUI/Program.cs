using System;
using System.Collections.Generic;
using LCGModels;

namespace LCGUI
{
    public static class Current
    {
        public static int CurrentStoreID { get; set; }
        public static string CurrentStoreName { get; set; }
        public static int CurrentCustomerID { get; set; }
        public static string CurrentCustomerName { get; set; }
        public static List<LineItem> CurrentLineItems { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ScreenType screenType = ScreenType.MainScreen;
            IScreenFactory screenFactory = new ScreenFactory();
            IScreen screen = screenFactory.GetScreen(screenType);
            bool repeat = true;

            while(repeat)
            {
                Console.Clear();
                screen.Render();
                screenType = screen.GetRoute();

                switch(screenType)
                {
                    case ScreenType.MainScreen :
                        screen = screenFactory.GetScreen(ScreenType.MainScreen);
                        break;
                    case ScreenType.SelectStoreScreen :
                        screen = screenFactory.GetScreen(ScreenType.SelectStoreScreen);
                        break;
                    case ScreenType.CustomerScreen :
                        screen = screenFactory.GetScreen(ScreenType.CustomerScreen);
                        break;
                    case ScreenType.AddCustomerScreen :
                        screen = screenFactory.GetScreen(ScreenType.AddCustomerScreen);
                        break;
                    case ScreenType.CustomerListScreen :
                        screen = screenFactory.GetScreen(ScreenType.CustomerListScreen);
                        break;
                    case ScreenType.SearchCustomerByPhoneNumberScreen :
                        screen = screenFactory.GetScreen(ScreenType.SearchCustomerByPhoneNumberScreen);
                        break;
                    case ScreenType.StoreInventoryListScreen :
                        screen = screenFactory.GetScreen(ScreenType.StoreInventoryListScreen);
                        break;
                    case ScreenType.OrderHistoryScreen :
                        screen = screenFactory.GetScreen(ScreenType.OrderHistoryScreen);
                        break;
                    case ScreenType.PlaceOrderScreen :
                        screen = screenFactory.GetScreen(ScreenType.PlaceOrderScreen);
                        break;
                    case ScreenType.Exit :
                        repeat = false;
                        break;
                    default :
                        Console.WriteLine("No route found! Press any key to continue... ");
                        Console.ReadLine();
                        break;
                }

            }
        }
    }
}
