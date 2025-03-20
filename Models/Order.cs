using System;
using System.Collections.Generic;

namespace TechMarketSweden.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderItem> OrderItems { get; set; }
    }
}
