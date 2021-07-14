using System;
using System.Collections.Generic;
using LCGBL;
using LCGModels;

namespace LCGUI
{
    public class PlaceOrderScreen : IScreen
    {
        private StoreBL _storeBL;
        public PlaceOrderScreen(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
        }

        public void Render()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Order - Enter your choice");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            if(Current.CurrentLineItems != null)
            {
                foreach(LineItem l in Current.CurrentLineItems)
                {
                    string pName = _storeBL.GetProductByID(l.ProductID).Name;
                    Console.WriteLine($"[{l.ProductID}] {pName} / Quantity: {l.Quantity} / Sub total: {l.SubTotal}");
                }
            }
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("[1] Add item");
            Console.WriteLine("[2] Place order");
            Console.WriteLine("[3] Empty");
            Console.WriteLine("[x] Go Back");            
            Console.WriteLine("----------------------------------------------------------------------------------------");
        }

        public ScreenType GetRoute()
        {
            Console.Write("-> ");
            string userInput = Console.ReadLine();
            int _orderID;
            switch(userInput)
            {
                case "1":
                    Console.Write("Product ID: ");
                    int _productID = Int32.Parse(Console.ReadLine());
                    Product product = _storeBL.GetProductByID(_productID);
                    Console.Write("Quantity  : ");
                    int _quantity = Int32.Parse(Console.ReadLine());
                    decimal _subTotal = product.ListPrice * _quantity;
                    _orderID = _storeBL.GetNewOrderID();
                    LineItem lineItem = new LineItem()
                    {
                        OrderID = _orderID,
                        ProductID = _productID,
                        Quantity = _quantity,
                        SubTotal = _subTotal
                    };
                    try
                    {
                        LineItem newLineItem = _storeBL.AddLineItem(lineItem);
                        Current.CurrentLineItems.Add(lineItem);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }

                    return ScreenType.PlaceOrderScreen;
                case "2":
                    Order order = new Order()
                    {
                        StoreID = Current.CurrentStoreID,
                        CustomerID = Current.CurrentCustomerID,
                        OrderDate = DateTime.Now
                    };
                    try{
                        Order newOrder = _storeBL.AddOrder(order);
                        Current.CurrentLineItems = null;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    return ScreenType.OrderHistoryScreen;
                case "3":
                    Current.CurrentLineItems = null;
                    return ScreenType.PlaceOrderScreen;
                case "x":
                    return ScreenType.MainScreen;
                default :
                    {
                        Console.WriteLine("Your input is not valid! Press any key to continue... ");
                        Console.ReadLine();
                        return ScreenType.PlaceOrderScreen;
                    }
            }
        }
    }
}