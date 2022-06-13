using AdoNetFundamentals.Entities;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetFundamentals.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetAllOrders()
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();

                string commandText = "select * from Orders";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();

                Console.WriteLine("All Orders: ");
                SqlDataReader data = command.ExecuteReader();

                var orders = new List<Order>();

                return orders;
            }
        }

        public void AddOrder(DateTime createdDate, DateTime updatedDate, string status, int productId)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string commandText = $"insert into Orders (CreatedDate, UpdatedDate, Status, ProductID) " +
                    $"                  values('{createdDate}', '{updatedDate}', '{status}', {productId})";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateOrder(string columnName, string value, int id)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string commandText = $"update Orders set {columnName} = '{value}' where ID = {id}";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrderById(int id)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string commandText = $"delete Orders where ID = {id}";
                SqlCommand command = new SqlCommand(commandText, connection);
                command.ExecuteNonQuery();
            }
        }

        public void BulkDeleteOrderById(List<int> ids)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                foreach (int id in ids)
                {
                    try
                    {                        
                        string commandText = $"delete Orders where ID = {id}";
                        SqlCommand command = new SqlCommand(commandText, connection);
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                    }
                }
            }          
        }

        public List<Order> GetOrderByCreatedDateMonth(string month)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string procedure = "SP_GetOrderByCreatedDateMonth";

                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = command.Parameters.Add("@Month", SqlDbType.NVarChar);
                param.Value = month;
                command.ExecuteNonQuery();

                SqlDataReader data = command.ExecuteReader();
                var orders = new List<Order>();

                return orders;
            }
        }

        public List<Order> GetOrderByStatus(string statusvalue)
        {
            using (SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString()))
            {
                connection.Open();
                string procedure = "SP_GetOrderByStatus";

                SqlCommand command = new SqlCommand(procedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = command.Parameters.Add("@Status", SqlDbType.NVarChar);
                param.Value = statusvalue;
                command.ExecuteNonQuery();

                SqlDataReader data = command.ExecuteReader();

                var orders = new List<Order>();

                return orders;
            }
        }

        public List<Order> GetOrderByStatusUsingAdapter(string statusvalue)
        {
            SqlConnection connection = new SqlConnection(SeedExtension.GetConnectionString());
            connection.Open();
            string procedure = "SP_GetOrderByStatus";

            SqlDataAdapter adapter = new SqlDataAdapter(new SqlCommand()
            {
                CommandText = procedure,
                CommandType = CommandType.StoredProcedure,
                Connection = connection,
            });

            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Status", statusvalue));

            DataSet data = new DataSet();
            adapter.Fill(data);
            var orders = new List<Order>();

            foreach (DataTable dt in data.Tables)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    Console.Write($" \t {column}");
                }
                Console.WriteLine();
                foreach (DataRow row in dt.Rows)
                {
                    var status = Enum.GetValues(typeof(Status)).Cast<Status>().SingleOrDefault(x => x.ToString() == row[4].ToString());
                    Console.WriteLine($" \t {row[0]} \t {row[1]} \t \t {row[2]} \t \t {row[3]} \t \t {row[4]}");
                    var order = new Order(Convert.ToDateTime(row[1]), Convert.ToDateTime(row[2]), status, Convert.ToInt32(row[4]));
                    orders.Add(order);
                }
            }

            return orders;
        }
    }
}




