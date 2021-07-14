namespace LCGModels
{
    public class LineItem
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    
        public override string ToString()
        {
            return $"[{ProductID}] Quantity: {Quantity} / Sub total: {SubTotal}";
        }
    }

}