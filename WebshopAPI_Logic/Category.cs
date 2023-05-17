using System.Data.SqlTypes;
using WebshopAPI_Interface;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_Logic
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? WebshopId { get; set; }
        public List<int>? Products { get; set; }

        public Category(int id)
        {
            Id = id;
        }
        public Category(string name)
        {
            Name = name;
        }
        public Category(CategoryDTO categoryDTO)
        {
            Id = categoryDTO.Id;
            Name = categoryDTO.Name;
            Description = categoryDTO.Description;
        }

        public Category GetCategory(ICategory iCategory)
        {
            return new Category(iCategory.GetCategory(this.Id));
        }

        public List<int> GetProducts(IProduct ProductDAL)
        {
            this.Products = ProductDAL.GetProductIdsOfCategory(this.Id);
            return this.Products;
        }
    }
}
