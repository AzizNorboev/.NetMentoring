using AdoNetFundamentals.Entities;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetFundamentals.Repositories
{
    public class ProductRepository:IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();

                string commandText = "select p.Name, p.Description, p.Weight, p.Height, p.Width, p.Length from Products p";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("AllProducts: ");
                SqlDataReader data = command.ExecuteReader();

                var products = new List<Product>();

                return products;
            }
        }

        public void AddProduct(string name, string description, float weight, float height, float width, float length)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string commandText = $"insert into Products(Name, Description, Weight, Height, Width, Length) " +
                                        $"values('{name}', '{description}', {weight}, {height}, {width}, {length})";
                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameter paramName = command.Parameters.Add("@Name", SqlDbType.NVarChar);
                SqlParameter paramDescription = command.Parameters.Add("@Description", SqlDbType.NVarChar);
                paramName.Value = name;
                paramDescription.Value = description;
                command.ExecuteNonQuery();
                Console.WriteLine("successfully inserted data to Products table: ");
            }
        }

        public void UpdateProduct(string columnName, string value, int id)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string commandText = $"update Products set {columnName} = '{value}' where ID = {id}";
                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameter paramColumnName = command.Parameters.Add("@ColumnName", SqlDbType.NVarChar);
                SqlParameter paramValue = command.Parameters.Add("@Value", SqlDbType.NVarChar);
                paramColumnName.Value = columnName;
                paramValue.Value = value;
                command.ExecuteNonQuery();
            }
        }

        public void DeleteProductById(int id)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string commandText = $"delete Products where ID = {id}";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();
            }
        }

        public Product GetProductByName(string productName)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string procedure = "SP_GetProductByName";
                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = command.Parameters.Add("@Name", SqlDbType.NVarChar);
                param.Value = productName;
                command.ExecuteNonQuery();

                SqlDataReader data = command.ExecuteReader();
                Product product = null;

                return product;
            }
        }

    }
}
