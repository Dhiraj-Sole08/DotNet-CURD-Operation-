using System.Text.Json.Serialization;

namespace AssignmentApp.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
