namespace LCGModels
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public decimal ListPrice { get; set; }
    }
}