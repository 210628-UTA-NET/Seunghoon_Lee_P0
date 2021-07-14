using System;
using System.Collections.Generic;
using LCGBL;
using LCGModels;

namespace LCGUI
{
    public class PlaceOrderScreen : IScreen
    {
        private StoreBL _storeBL;
        private int _orderID;
        private List<LineItem> _lineItems = new List<LineItem>();
        private decimal _total = (decimal)0.00;
        private string _userInput = "n";
        public PlaceOrderScreen(StoreBL p_storeBL)
        {
            _storeBL = p_storeBL;
            _orderID = _storeBL.GetNewOrderID();
        }

        public void Render()
        {
            do
            {
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.Write("Product ID: ");
                int _productID = Int32.Parse(Console.ReadLine());
                Product product = _storeBL.GetProductByID(_productID);
                Console.Write("Quantity  : ");
                int _quantity = Int32.Parse(Console.ReadLine());
                decimal _subTotal = product.ListPrice * _quantity;
                LineItem lineItem = new LineItem()
                {
                    OrderID = _orderID,
                    ProductID = _productID,
                    Quantity = _quantity,
                    SubTotal = _subTotal
                };
                _lineItems.Add(lineItem);
                _total += _subTotal;
                
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine($"Order ID : {_orderID}                                                  Total: ${_total}");
                Console.WriteLine("----------------------------------------------------------------------------------------");

                foreach(LineItem l in _lineItems)
                {
                    Console.WriteLine($"[{l.ProductID}] {product.Name} / Quantity: {_quantity} / Sub total: ${_subTotal} ");
                }
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.Write("Continue? (y/n): ");
                _userInput = Console.ReadLine();

            } while(_userInput == "y");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("[1] Place order");
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
                    Order order = new Order()
                    {
                        StoreID = Current.CurrentStoreID,
                        CustomerID = Current.CurrentCustomerID,
                        OrderDate = DateTime.Now
                    };
                    try{
                        Order newOrder = _storeBL.AddOrder(order);
                        foreach(LineItem l in _lineItems)
                        {
                            _storeBL.AddLineItem(l);
                            _storeBL.ChangeInventoryCount(order.StoreID, l.ProductID, l.Quantity*(-1));
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    return ScreenType.OrderHistoryScreen;
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