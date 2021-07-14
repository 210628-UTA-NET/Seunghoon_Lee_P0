using System;
using System.Collections.Generic;
using LCGDL;
using LCGModels;

namespace LCGBL
{
    public class StoreBL : IStoreBL
    {
        private IRepository _repo;

        public StoreBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        public List<Store> GetAllStores()
        {
            return _repo.GetAllStores();
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customer GetCustomerByID(int p_customerID)
        {
            return _repo.GetCustomerByID(p_customerID);
        }

        public List<Customer> GetCustomersByPhoneNumber(string p_phoneNumber)
        {
            return _repo.GetCustomersByPhoneNumber(p_phoneNumber);
        }

        public Customer AddCustomer(Customer p_customer)
        {
            return _repo.AddCustomer(p_customer);
        }

        public List<StoreInventory> GetStoreInventory(int p_storeID)
        {
            return _repo.GetStoreInventory(p_storeID);
        }

        public List<Order> GetOrdersByCustomerID(int p_customerID)
        {
            return _repo.GetOrdersByCustomerID(p_customerID);
        }

        public void ReplenishInventory(int p_storeID, int p_productID, int p_increment)
        {
            _repo.ReplenishInventory(p_storeID, p_productID, p_increment);
        }

        public int GetNewOrderID()
        {
            return _repo.GetNewOrderID();
        }

        public LineItem AddLineItem(LineItem p_lineItem)
        {
            return _repo.AddLineItem(p_lineItem);
        }

        public Order AddOrder(Order p_order)
        {
            return _repo.AddOrder(p_order);
        }

        public Product GetProductByID(int p_productID)
        {
            return _repo.GetProductByID(p_productID);
        }
    }
}
