using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetFundamentals
{
    public static class SeedExtension
    {
        public static string GetConnectionString()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            
            configurationBuilder.AddJsonFile(path, false);
            string connectionString = configurationBuilder.Build().GetSection("ConnectionStrings:DefaultConnectionString").Value;
            return connectionString;
        }

        private static void CreateTableProduct(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                if (DoesTableExist(tableName))
                {
                    Console.WriteLine("Table exists");
                }
                else
                {
                    var createTableQuery = "CREATE TABLE Products (ID INT PRIMARY KEY IDENTITY, " +
                                                            "Name NVARCHAR(100) NOT NULL, " +
                                                            "Description NVARCHAR(100) NULL, " +
                                                            "Weight float NULL, " +
                                                            "Height float NULL, " +
                                                            "Width float NULL, " +
                                                            "Length float NULL)";

                    SqlCommand command = new SqlCommand(createTableQuery, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table Products is created");
                }
            }
        }

        private static void CreateTableOrders(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                if (DoesTableExist(tableName))
                {
                    Console.WriteLine("Table exists");
                }
                else
                {
                    var createTableQuery = "CREATE TABLE Orders (ID INT PRIMARY KEY IDENTITY, " +
                                                         "CreatedDate Date NOT NULL, " + // YYYY-MM-DD
                                                         "UpdatedDate Date NULL, " +
                                                         "Status nvarchar(100) NOT NULL CHECK(Status IN('NotStarted', 'Loading', 'InProgress', 'Arrived', 'Unloading', 'Cancelled', 'Done')) DEFAULT 'Done', " +
                                                         "ProductID Int FOREIGN KEY REFERENCES Products(ID)) ";
                    SqlCommand command = new SqlCommand(createTableQuery, connection);
                    command.ExecuteNonQuery();

                    Console.WriteLine("Table Orders is created");
                }
            }
        }

        public static void CreateTables()
        {
            Console.WriteLine("Creating Tables: ");
            CreateTableProduct("Products");
            CreateTableOrders("Orders");
        }

        private static bool DoesTableExist(string TableName)
        {
            using (SqlConnection conn =
                         new SqlConnection(GetConnectionString()))
            {
                conn.Open();

                DataTable dTable = conn.GetSchema("TABLES",
                               new string[] { null, null, TableName });

                return dTable.Rows.Count > 0;
            }
        }
    }
}
