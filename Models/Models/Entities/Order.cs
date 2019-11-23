using System;

namespace sample_netcore.Models.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public DateTime CreatedDate { get; set; }

        public int DiscountPercent { get; set; }

        public double TotalBeforeDiscount { get; set; }

        public double TotalAfterDiscount { get; set; }

        public Employee Employee { get; set; }
    }
}
