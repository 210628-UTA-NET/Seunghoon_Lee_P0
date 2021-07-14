using System;
using System.Collections.Generic;
using LCGBL;
using LCGModels;

namespace LCGUI
{
    public class SelectStoreScreen : IScreen
    {
        private StoreBL _storeBL;
        private List<Store> _stores;
        public SelectStoreScreen(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Render()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Store List - Enter the store number to be selected");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            _stores = _storeBL.GetAllStores();
            foreach(Store store in _stores)
            {
                Console.WriteLine(store);
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
                    if(Int32.Parse(userInput) >= 1 && Int32.Parse(userInput) <= _stores.Count )
                    {
                        Current.CurrentStoreID = Int32.Parse(userInput);
                        Current.CurrentStoreName = _stores.Find(s => s.StoreID == Current.CurrentStoreID).Name;
                        return ScreenType.MainScreen;
                    }
                    else 
                    {
                        Console.WriteLine("Your input is not valid! Press any key to continue... ");
                        Console.ReadLine();
                        return ScreenType.SelectStoreScreen;
                    }
            }
        }
    }
}