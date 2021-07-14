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
        private List<string> _productNames = new List<string>();
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
                _productNames.Add(product.Name);
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

                for(int i = 0; i <_lineItems.Count; i++)
                {
                    Console.WriteLine(
                        $"[{_lineItems[i].ProductID}] {_productNames[i]} / Quantity: {_lineItems[i].Quantity} / Sub total: ${_lineItems[i].SubTotal}"
                    );
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
                        OrderDate = DateTime.Now,
                        Total = _total
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