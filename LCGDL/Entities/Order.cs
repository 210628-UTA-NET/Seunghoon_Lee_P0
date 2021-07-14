using System;
using System.Collections.Generic;

#nullable disable

namespace LCGDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
