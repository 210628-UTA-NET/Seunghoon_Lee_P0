using System;

namespace LCGModels
{
    public class Order
    {
        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total {get; set;}

        public override string ToString()
        {
            return $"[{OrderID}] Date: {OrderDate} / Amount: {Total}";
        }
    }
}