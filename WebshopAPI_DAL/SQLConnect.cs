using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopAPI_DAL
{
    public class SQLConnect
    {
        internal SqlConnection DbConnection;

        internal void InitializeDB()
        {
            string connectionString = @"Data Source=mssqlstud.fhict.local;Database=dbi482774_webshopapi;User Id=dbi482774_webshopapi;Password=WebshopSV;MultipleActiveResultSets=true;";
            DbConnection = new SqlConnection(connectionString);
        }

        internal bool OpenConnection()
        {
            try
            {
                if (DbConnection.State != ConnectionState.Open)
                    DbConnection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool CloseConnection()
        {
            try
            {
                if (DbConnection != null && DbConnection.State == ConnectionState.Open)
                    DbConnection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
