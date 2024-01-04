using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace ToolShelfAPI.Data
{
    
    public class HomeDataLayer: IHomeDataLayer
    {
        private readonly SqlConnection _connection;
        public HomeDataLayer(SqlConnection connection)
        {
            _connection = connection;
        }
        public List<ToolList> GetToolsList()
        {
            List<ToolList> results = new List<ToolList>();
            try
            {
                _connection.Open();

                // Call your stored procedure
                using (SqlCommand command = new SqlCommand("GetToolList", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters if your stored procedure requires them
                    //command.Parameters.Add(new SqlParameter("@ParameterName", SqlDbType.NVarChar) { Value = "Parameter value" });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //List<ToolList> results = new List<ToolList>();

                        while (reader.Read())
                        {
                            ToolList result = new ToolList
                            {

                                // Map the result columns to your model
                                ToolId = Convert.ToInt32(reader["ToolId"]),
                                ToolName = reader["ToolName"].ToString(),
                                ToolDescription = reader["ToolDescription"].ToString(),
                                ToolAvailable = Convert.ToInt32(reader["ToolAvailable"]),
                                PhotoLink = reader["PhotoLink"].ToString(),

                                // Add other properties as needed
                            };

                            results.Add(result);
                        }

                        return results;
                    }
                }
            }
            catch (Exception ex)
            {
                return results;
            }
            finally
            {
                _connection.Close();
            }
        }

    }
}
