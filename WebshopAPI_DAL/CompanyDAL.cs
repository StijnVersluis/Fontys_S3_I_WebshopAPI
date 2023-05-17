using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI_Interface;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_DAL
{
    public class CompanyDAL : SQLConnect, ICompany
    {
        public CompanyDAL() { InitializeDB(); }

        public List<int> GetCompanyWebshops(int CompanyId)
        {
            List<int> result = new List<int>();
            try
            {
                OpenConnection();

                SqlCommand getWebshopIdsCom = new SqlCommand("SELECT Id FROM Webshops WHERE CompanyId = @cId", DbConnection);
                getWebshopIdsCom.Parameters.AddWithValue("cId", CompanyId);

                var webshopIdReader = getWebshopIdsCom.ExecuteReader();

                while (webshopIdReader.Read())
                {
                    result.Add((int)webshopIdReader[0]);
                }
            }
            catch { return null; }
            finally { CloseConnection(); }
            return result;
        }
    

        public string GetCompanyApiKeyByUserName(string CompanyUserName)
        {
            string result = "not existing";

            try
            {
                OpenConnection();

                SqlCommand getApiKeyCom = new SqlCommand("SELECT AUTH_KEY FROM Companies WHERE UserName = @uName", DbConnection);
                getApiKeyCom.Parameters.AddWithValue("uName", CompanyUserName);

                var apiKeyReader = getApiKeyCom.ExecuteReader();

                while (apiKeyReader.Read())
                {
                    result = (string)apiKeyReader[0];
                }
            }
            catch { return "Something went wrong"; }
            finally { CloseConnection(); }
            return result;
        }
    }
}
