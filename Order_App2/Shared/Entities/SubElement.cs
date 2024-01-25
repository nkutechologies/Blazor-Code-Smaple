using System;
using System.Text.Json.Serialization;

namespace Order_App2.Shared.Entities
{
    public class SubElement
    {
        public int SubElementId { get; set; }
        public int Element { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int WindowId { get; set; }
        [JsonIgnore]
        public Window? Window { get; set; }
    }
}

