using WebshopAPI_Interface.DTO;

namespace WebshopAPI_Interface
{
    public interface IProduct
    {
        public ProductDTO GetProduct(int id);
        public List<int> GetProductIdsOfCategory(int CategoryId);
    }
}