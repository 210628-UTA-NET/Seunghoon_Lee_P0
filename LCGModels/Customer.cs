namespace LCGModels
{
    /// <summary>
    /// Customer contains information of a customer
    /// </summary>
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public override string ToString()
        {
            return $"[{CustomerID}] {FirstName} {LastName} / Email: {Email} / Phone: {PhoneNumber}";
        }
        
    }
}
