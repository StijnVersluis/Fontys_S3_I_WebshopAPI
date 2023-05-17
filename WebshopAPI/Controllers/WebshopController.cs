
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using WebshopAPI.Attributes;
using WebshopAPI_DAL;
using WebshopAPI_Logic;

namespace WebshopAPI.Controllers
{
    [ApiController]
    [Route("Webshop")]
    public class WebshopController : ControllerBase
    {

        private readonly ILogger<WebshopController> _logger;
        private readonly WebshopDAL webshopDAL = new WebshopDAL();
        private readonly CategoryDAL categoryDAL = new CategoryDAL();

        public WebshopController(ILogger<WebshopController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetWebshop")]
        public Webshop Get(int id)
        {
            Webshop webshop = new Webshop()
            {
                Id = id
            };
            var result = webshop.GetWebshop(webshopDAL);
            //TODO: add check if webshop does not exist or company has no access to webshop
            result.Categories = result.GetWebshopCategoryIds(webshopDAL);
            return result;
        }

        [HttpGet("{id}/Categories", Name = "GetCategories")]
        public List<Category> GetCategories(int id)
        {
            var result = new List<Category>();
            Webshop webshop = new Webshop(id);
            var CategoryIds = webshop.GetWebshopCategoryIds(webshopDAL);
            foreach (int catId in CategoryIds)
            {
                var cat = new Category(catId);
                result.Add(cat.GetCategory(categoryDAL));
            }
            return result;
        }

        //[HttpGet(Name = "Test")]
        //public string GetText()
        //{
        //    string result = "";

        //    HttpContext.Request.Headers.TryGetValue("Company", out var CompanyUserName);

        //    result = CompanyUserName;

        //    return result;
        //}
    }
}
