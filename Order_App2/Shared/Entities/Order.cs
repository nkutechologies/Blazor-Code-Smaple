using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Order_App2.Shared.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public ICollection<Window>? Windows { get; set; }
    }
}

