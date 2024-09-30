using System.Text.Json.Serialization;

namespace AssignmentApp.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public string  Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public ProductCategory Category { get; set; }
    }
}
