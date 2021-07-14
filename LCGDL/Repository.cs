using System.Collections.Generic;
using LCGModels;
using System.Linq;
using System;

namespace LCGDL
{
    public class Repository : IRepository
    {
        private Entities.LCGDBContext _context;
        public Repository(Entities.LCGDBContext p_context)
        {
            _context = p_context;
        }

        public List<Store> GetAllStores()
        {
            return _context.Stores.Select(
                s => 
                    new Store()
                    {
                        StoreID = s.StoreId,
                        Name = s.Name,
                        Email = s.Email,
                        PhoneNumber = s.PhoneNumber,
                        Street = s.Street,
                        City = s.City,
                        State = s.State,
                        Zip = s.Zip
                    }
                )
                .ToList();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                c => 
                    new Customer()
                    {
                        CustomerID = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber,
                        Street = c.Street,
                        City = c.City,
                        State = c.State,
                        Zip = c.Zip
                    }
                )
                .ToList();
        }

        public Customer GetCustomerByID(int p_customerID)
        {
            return _context.Customers.Select(
                c =>
                    new Customer()
                    {
                        CustomerID = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber,
                        Street = c.Street,
                        City = c.City,
                        State = c.State,
                        Zip = c.Zip                        
                    }
            )
            .ToList()
            .Where(c => c.CustomerID == p_customerID)
            .FirstOrDefault();
        }

        public List<Customer> GetCustomersByPhoneNumber(string p_phoneNumber)
        {
            return _context.Customers.Select(
                c => 
                    new Customer()
                    {
                        CustomerID = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Email = c.Email,
                        PhoneNumber = c.PhoneNumber,
                        Street = c.Street,
                        City = c.City,
                        State = c.State,
                        Zip = c.Zip
                    }
                )
                .ToList()
                .Where(c => c.PhoneNumber == p_phoneNumber)
                .ToList();
        }

        public Customer AddCustomer(Customer p_customer)
        {
            _context.Customers.Add(
                new Entities.Customer
                {
                    FirstName = p_customer.FirstName,
                    LastName = p_customer.LastName,
                    Email = p_customer.Email,
                    PhoneNumber = p_customer.PhoneNumber,
                    Street = p_customer.Street,
                    City = p_customer.City,
                    State = p_customer.State,
                    Zip = p_customer.Zip
                }
            );

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return p_customer;
        }

        public List<Inventory> GetInventoriesByStoreID(int p_storeID)
        {
            return _context.Inventories.Select(
                i => 
                    new Inventory()
                    {
                        StoreID = i.StoreId,
                        ProductID = i.ProductId,
                        Quantity = i.Quantity
                    }
            )
            .ToList()
            .Where(i => i.StoreID == p_storeID)
            .ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Select(
                p => 
                    new Product
                    {
                        ProductID = p.ProductId,
                        Name = p.Name,
                        BrandID = p.BrandId,
                        CategoryID = p.CategoryId,
                        ListPrice = p.ListPrice
                    }
            ).ToList();
        }

        public List<Brand> GetAllBrands()
        {
            return _context.Brands.Select(
                b => 
                    new Brand
                    {
                        BrandID = b.BrandId,
                        Name = b.Name
                    }
            ).ToList();
        }

        public List<Category> GetAllCategory()
        {
            return _context.Categories.Select(
                c =>
                    new Category
                    {
                        CategoryID = c.CategoryId,
                        Name = c.Name
                    }
            ).ToList();
        }

        public List<Order> GetOrdersByCustomerID(int p_customerID)
        {
            return _context.Orders.Select(
                o =>
                    new Order
                    {
                        OrderID = o.OrderId,
                        StoreID = o.StoreId,
                        CustomerID = o.CustomerId,
                        OrderDate = o.OrderDate,
                        Total = o.Total
                    }
            )
            .ToList()
            .Where(o => o.CustomerID == p_customerID)
            .ToList();
        }

        List<StoreInventory> IRepository.GetStoreInventory(int p_storeID)
        {
            return (
                from i in _context.Inventories
                join p in _context.Products on i.ProductId equals p.ProductId
                where i.StoreId == p_storeID
                select new StoreInventory()
                {
                    ProductID = i.ProductId,
                    ProductName = p.Name,
                    ListPrice = p.ListPrice,
                    Quantity = i.Quantity
                }
            ).ToList();
        }

        public void ChangeInventoryCount(int p_storeID, int p_productID, int p_increment)
        {
            var query =
                from inventory in _context.Inventories
                where inventory.StoreId == p_storeID && inventory.ProductId == p_productID
                select inventory;
            foreach (Entities.Inventory i in query)
            {
                i.Quantity = i.Quantity + p_increment;
            }
            
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public int GetNewOrderID()
        {
            int id = _context.Orders.Select(o => o.OrderId).ToList().Count;
            return ++id;
        }

        public LineItem AddLineItem(LineItem p_lineItem)
        {
             _context.LineItems.Add(
                new Entities.LineItem
                {
                    OrderId = p_lineItem.OrderID,
                    ProductId = p_lineItem.ProductID,
                    Quantity = p_lineItem.Quantity,
                    SubTotal = p_lineItem.SubTotal
                }
            );

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return p_lineItem;
       }

        public Order AddOrder(Order p_order)
        {
             _context.Orders.Add(
                new Entities.Order
                {
                    StoreId = p_order.StoreID,
                    CustomerId = p_order.CustomerID,
                    OrderDate = p_order.OrderDate
                }
            );

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return p_order;
        }

        public Product GetProductByID(int p_productID)
        {
            return _context.Products.Select(
                p =>
                    new Product
                    {
                        ProductID = p.ProductId,
                        Name = p.Name,
                        BrandID = p.BrandId,
                        CategoryID = p.CategoryId,
                        ListPrice = p.ListPrice
                    }
            )
            .ToList()
            .Where(p => p.ProductID == p_productID)
            .FirstOrDefault();
        }
    }
}