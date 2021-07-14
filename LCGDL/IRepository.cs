using System;
using System.Collections.Generic;
using LCGModels;

namespace LCGDL
{
    /// <summary>
    /// It is responsible for accessing the database
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Get all the stores from the database
        /// </summary>
        /// <returns>The list of stores</returns>
        List<Store> GetAllStores();

        /// <summary>
        /// Get all the customers from the database
        /// </summary>
        /// <returns>The list of customers</returns>
        List<Customer> GetAllCustomers();

        /// <summary>
        /// Get Customer by ID
        /// </summary>
        /// <param name="p_customerID"></param>
        /// <returns>Customer</returns>
        Customer GetCustomerByID(int p_customerID);

        /// <summary>
        /// Get Customers by phone number
        /// </summary>
        /// <param name="p_phoneNumber"></param>
        /// <returns>Customer List</returns>
        List<Customer> GetCustomersByPhoneNumber(string p_phoneNumber);

        /// <summary>
        /// Add new customer to the database
        /// </summary>
        /// <param name="p_customer"></param>
        /// <returns>The customer object added</returns>
        Customer AddCustomer(Customer p_customer);

        /// <summary>
        /// Get inventory by store from the database
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <returns>List of inventorries</returns>
        List<Inventory> GetInventoriesByStoreID(int p_storeID);

        /// <summary>
        /// Get all products from the database
        /// </summary>
        /// <returns>List of products</returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Get all brands from the databae
        /// </summary>
        /// <returns>List of brands</returns>
        List<Brand> GetAllBrands();

        /// <summary>
        /// Get all categories from the database
        /// </summary>
        /// <returns>List of categories</returns>
        List<Category> GetAllCategory();

        /// <summary>
        /// Get orders by customer ID from the database
        /// </summary>
        /// <param name="p_customerID"></param>
        /// <returns>List of orders</returns>
        List<Order> GetOrdersByCustomerID(int p_customerID);

        /// <summary>
        /// Get store inventory by store id from the database
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <returns>List of store inventories</returns>
        List<StoreInventory> GetStoreInventory(int p_storeID);

        /// <summary>
        /// Change inventory count
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <param name="p_productID"></param>
        void ChangeInventoryCount(int p_storeID, int p_productID, int p_increment);

        /// <summary>
        /// Get next order ID to be added
        /// </summary>
        /// <returns>int OrderID</returns>
        int GetNewOrderID();

        /// <summary>
        /// Add new line item
        /// </summary>
        /// <param name="lineItem"></param>
        /// <returns>LineItem</returns>
        LineItem AddLineItem(LineItem p_lineItem);

        /// <summary>
        /// Add new order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Order</returns>
        Order AddOrder(Order p_order);

        /// <summary>
        /// Get Product information by id from the database
        /// </summary>
        /// <param name="p_productID"></param>
        /// <returns>Product</returns>
        Product GetProductByID(int p_productID);

    }
}
