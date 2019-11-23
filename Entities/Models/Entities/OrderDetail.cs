using sample_netcore.Models;
using System;

namespace sample_netcore.Models.Entities
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }

        public int DishId { get; set; }

        public int Quantity { get; set; }

        public Table Table { get; set; }
    }
}
