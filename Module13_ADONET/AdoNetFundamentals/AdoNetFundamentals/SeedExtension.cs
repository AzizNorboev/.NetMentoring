using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace AdoNetFundamentals
{
    public static class SeedExtension
    {
        public static string GetConnectionString()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = "C:\\Users\\Aziz_Norboev\\Documents\\GitHub\\.NetMentoring\\Module13_ADONET\\AdoNetFundamentals\\AdoNetFundamentals\\appsettings.json";
            
            configurationBuilder.AddJsonFile(path, false);
            string connectionString = configurationBuilder.Build().GetSection("ConnectionStrings:DefaultConnectionString").Value;
            return connectionString;
        }

        private static void CreateTableProduct()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                var getAllTablesQuery = "SELECT t.name FROM sys.tables t where t.name = 'Products'";
                SqlCommand command = new SqlCommand(getAllTablesQuery, connection);
                command.ExecuteNonQuery();

                SqlDataReader data = command.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Console.WriteLine($"Table {data.GetValue(0)} exists");
                    }
                }
                else
                {
                    data.Close();
                    var createTableQuery = "CREATE TABLE Products (ID INT PRIMARY KEY IDENTITY, " +
                                                            "Name NVARCHAR(100) NOT NULL, " +
                                                            "Description NVARCHAR(100) NULL, " +
                                                            "Weight float NULL, " +
                                                            "Height float NULL, " +
                                                            "Width float NULL, " +
                                                            "Length float NULL)";

                    command = new SqlCommand(createTableQuery, connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table Products is created");
                }
            }
        }

        private static void CreateTableOrders()
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();

                var getAllDbQuery = "SELECT t.name FROM sys.tables t where t.name = 'Orders'";
                SqlCommand command = new SqlCommand(getAllDbQuery, connection);

                command.ExecuteNonQuery();
                SqlDataReader data = command.ExecuteReader();

                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        Console.WriteLine($"Table {data.GetValue(0)} exists");
                    }
                }
                else
                {
                    data.Close();
                    var createTableQuery = "CREATE TABLE Orders (ID INT PRIMARY KEY IDENTITY, " +
                    "CreatedDate Date NOT NULL, " + // YYYY-MM-DD
                    "UpdatedDate Date NULL, " +
                   "Status nvarchar(100) NOT NULL CHECK(Status IN('NotStarted', 'Loading', 'InProgress', 'Arrived', 'Unloading', 'Cancelled', 'Done')) DEFAULT 'Done', " +
                    "ProductID Int FOREIGN KEY REFERENCES Products(ID)) ";
                  
                    command = new SqlCommand(createTableQuery, connection);
                    command.ExecuteNonQuery();

                    Console.WriteLine("Table Orders is created");
                }
            }
        }

        public static void CreateTables()
        {
            Console.WriteLine("Creating Tables: ");
            CreateTableProduct();
            CreateTableOrders();
        }
    }
}
