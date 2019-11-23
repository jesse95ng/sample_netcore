using System;
using System.Collections.Generic;

namespace sample_netcore.Models.Entities
{
    public class Table
    {
        public Guid Id { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
