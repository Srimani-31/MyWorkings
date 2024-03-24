using PRO_XY.WebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PRO_XY.WebAPI.Constants;

namespace PRO_XY.WebAPI.Repositories
{
  public class GraphDataRepository 
  {
    private readonly string _connectionString;

    public GraphDataRepository(string connectionString)
    {
      _connectionString = connectionString;
    }

    public async Task<List<object>> CreateJsonWithTwoAxis(string dimension, string measure, string dataset = Dataset.D1)
    {
      try
      {
        await Task.CompletedTask;
        List<object> result = new List<object>();

        string query = $"SELECT [{dimension}], CEILING(SUM([{measure}])) as {dimension + measure} FROM [PRO_XY].[dbo].[{dataset}] GROUP BY [{dimension}]";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
          connection.Open();

          using (SqlCommand command = new SqlCommand(query, connection))
          {
            using (SqlDataReader reader = command.ExecuteReader())
            {
              while (reader.Read())
              {
                var row = new Dictionary<string, object>
                        {
                            { dimension, reader[dimension] },
                            { measure, reader[dimension + measure] }
                        };

                result.Add(row);
              }
            }
          }
        }

        return result;
      }
      catch (Exception)
      {
        throw;
      }
    }

  }
}
