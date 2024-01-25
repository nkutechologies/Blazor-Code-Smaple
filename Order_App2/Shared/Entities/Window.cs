using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Order_App2.Shared.Entities
{
    public class Window
    {
        public int WindowId { get; set; }
        public string Name { get; set; }
        public int? QuantityOfWindows { get; set; }
        public int? TotalSubElements { get; set; }
        public int? OrderId { get; set; }
        [JsonIgnore]
        public Order? Order { get; set; }
        public ICollection<SubElement>? SubElements { get; set; }


    }
}

