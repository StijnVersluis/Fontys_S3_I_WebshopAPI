using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI_Interface;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_DAL
{
    public class ProductDAL : SQLConnect, IProduct
    {
        public ProductDAL()
        {
            InitializeDB();
        }

        public List<int> GetProductIdsOfCategory(int CategoryId)
        {
            var result = new List<int>();

            var commandString = "SELECT Id FROM Products WHERE CategoryId = @categoryId";
            var SqlCommand = new SqlCommand(commandString);
            SqlCommand.Parameters.AddWithValue("categoryId", CategoryId);

            var reader = SqlCommand.ExecuteReader();
            while (reader.Read())
            {
                result.Add((int)reader[0]);
            }

            return result;
        }

        public ProductDTO GetProduct(int id)
        {
            ProductDTO result = new ProductDTO();



            return result;
        }
    }
}
