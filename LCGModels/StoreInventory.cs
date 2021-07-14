namespace LCGModels
{
    public class StoreInventory
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ListPrice { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"[{ProductID}] {ProductName} / Price: {ListPrice} / Quantity: {Quantity}";;
        }
    }

}