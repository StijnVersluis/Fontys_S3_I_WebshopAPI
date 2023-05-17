using System.Reflection;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_Logic
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public Product(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
        public Product(ProductDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            Price = dto.Price;
            Description = dto.Description;
        }
    }
}
