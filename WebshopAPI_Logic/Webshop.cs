using WebshopAPI_Interface;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_Logic
{
    public class Webshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? WebUrl { get; set; }
        public List<int>? Categories { get; set; }

        public Webshop() { }
        public Webshop(int id)
        {
            Id = id;
        }
        public Webshop(int id, string name, string? description, string? webUrl, List<int>? categories)
        {
            Id = id;
            Name = name;
            Description = description;
            WebUrl = webUrl;
            Categories = categories;
        }
        public Webshop(WebshopDTO webshopDTO)
        {
            Id = webshopDTO.Id;
            Name = webshopDTO.Name;
            Description = webshopDTO.Description;
        }

        public Webshop GetWebshop(IWebshop iWebshop)
        {
            var webshopDTO = iWebshop.GetWebshop(this.Id);
            return new Webshop()
            {
                Id = webshopDTO.Id,
                Name = webshopDTO.Name,
                Description = webshopDTO.Description,
            };
        }

        public List<int> GetWebshopCategoryIds(IWebshop iWebshop)
        {
            return iWebshop.GetWebshopCategoryIds(this.Id);
        }
    }
}
