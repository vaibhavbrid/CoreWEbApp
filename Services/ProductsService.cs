using CoreWEbApp.Models;
using System.Data.SqlClient;

namespace CoreWEbApp.Services
{
    public class ProductsService
    {
        private static string db_server = "apps-services-net7-vai.database.windows.net";
        private static string db_user = "azadmin";
        private static string db_password = "azureAdmin1@#";
        private static string db_database = "Northwind";

        private SqlConnection GetConnection()
        {
            var sqlStringBuilder = new SqlConnectionStringBuilder();
            sqlStringBuilder.DataSource = db_server;
            sqlStringBuilder.UserID = db_user;
            sqlStringBuilder.Password = db_password;
            sqlStringBuilder.InitialCatalog = db_database;
            return new SqlConnection(sqlStringBuilder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            SqlConnection connection = GetConnection();
            List<Product> products = new List<Product>();

            string sqlStatement = "SELECT ProductId, ProductName from Products";

            connection.Open();

            SqlCommand sqlCommand = new(sqlStatement, connection);
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new()
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                    };

                    products.Add(product);
                }
            }
            return products;
        }
    }
}
