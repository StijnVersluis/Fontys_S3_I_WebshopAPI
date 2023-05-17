using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebshopAPI.Attributes;
using WebshopAPI_DAL;
using WebshopAPI_Logic;

namespace WebshopAPI.Controllers
{
    [ApiController]
    [Route("Category")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly CategoryDAL categoryDAL = new CategoryDAL();

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public Category GetCategory(int id)
        {
            var category = new Category(id);
            return category.GetCategory(categoryDAL);
        }
    }
}
