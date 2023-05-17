using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI_Interface;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_DAL
{
    public class WebshopDAL : SQLConnect, IWebshop
    {
        public WebshopDAL()
        {
            InitializeDB();
        }

        public WebshopDTO GetWebshop(int WebshopId)
        {
            var result = new WebshopDTO();
            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand("SELECT Id, Name, Description FROM Webshops WHERE Id = @id", DbConnection);
                command.Parameters.AddWithValue("id", WebshopId);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Id = WebshopId;
                    result.Name = (string)reader["Name"];
                    result.Description = (string)reader["Description"];
                }
            }
            catch { return new WebshopDTO() { Id = WebshopId }; }
            finally { CloseConnection(); }
            return result;
        }

        public List<int> GetWebshopCategoryIds(int WebshopId)
        {
            var result = new List<int>();
            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand("SELECT Id FROM Categories WHERE WebshopId = @wId", DbConnection);
                command.Parameters.AddWithValue("wId", WebshopId);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add((int)reader[0]);
                }
            }
            catch { return null; }
            finally { CloseConnection(); }
            return result;
        }
    }
}
