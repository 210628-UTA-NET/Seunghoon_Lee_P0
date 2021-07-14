using System;
using System.Collections.Generic;
using LCGBL;
using LCGModels;

namespace LCGUI
{
    public class StoreInventoryListScreen : IScreen
    {
        private StoreBL _storeBL;
        private List<StoreInventory> _inventories;
        private string _increment;

        public StoreInventoryListScreen(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }
        public void Render()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Store Inventory List - Enter the product number to be replenished");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            _inventories = _storeBL.GetStoreInventory(Current.CurrentStoreID);
            foreach(StoreInventory inventory in _inventories)
            {
                Console.WriteLine(inventory);
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
                    if(Int32.Parse(userInput) >= 1 && Int32.Parse(userInput) <= _inventories.Count )
                    {
                        Console.Write("Enter the quantity you want to replenish: ");
                        _increment = Console.ReadLine();
                        _storeBL.ReplenishInventory(Current.CurrentStoreID, Int32.Parse(userInput), Int32.Parse(_increment));
                        return ScreenType.StoreInventoryListScreen;
                    }
                    else 
                    {
                        Console.WriteLine("Your input is not valid! Press any key to continue... ");
                        Console.ReadLine();
                        return ScreenType.StoreInventoryListScreen;
                    }
            }

        }

    }
}