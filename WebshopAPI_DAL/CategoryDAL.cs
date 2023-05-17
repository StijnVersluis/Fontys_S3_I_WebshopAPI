using System.Data.SqlClient;
using WebshopAPI_Interface;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_DAL
{
    public class CategoryDAL : SQLConnect, ICategory
    {
        public CategoryDAL()
        {
            InitializeDB();
        }

        public CategoryDTO GetCategory(int id)
        {
            CategoryDTO dto = new CategoryDTO();

            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand("SELECT Name, Description FROM Categories WHERE Id = @id", DbConnection);
                command.Parameters.AddWithValue("id", id);

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dto = new CategoryDTO()
                    {
                        Id = id,
                        Name = (string)reader[0],
                        Description = reader[1] == DBNull.Value ? string.Empty : (string)reader[1]
                    };
                }
            }
            catch (Exception e) {
                dto.Name = e.StackTrace;
                dto.Description = e.Message;
                return dto;
            }
            finally { CloseConnection(); }

            return dto;
        }
    }
}