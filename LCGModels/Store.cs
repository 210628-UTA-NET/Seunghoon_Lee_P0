namespace LCGModels
{
    /// <summary>
    /// Store contains information of a store
    /// </summary>
    public class Store
    {
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return $"[{StoreID}] {Name} / Email: {Email} / Phone: {PhoneNumber}";
        }

    }
}