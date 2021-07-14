using System;
using System.Collections.Generic;

#nullable disable

namespace LCGDL.Entities
{
    public partial class LineItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
