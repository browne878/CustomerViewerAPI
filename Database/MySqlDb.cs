using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CustomerViewerAPI.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math.EC;

namespace CustomerViewerAPI.Database
{
    public class MySqlDb
    {
        /// <summary>
        /// Get Database Connection
        /// </summary>
        /// <returns>Closed Database Connection</returns>
        private static MySqlConnection GetDbConnection()
        {
            // Connection String.
            // Never hard code login information like this
            const string connString = "Server=localhost" + ";Database=userdb" + ";port=3306" + ";User Id=root" + ";password=%lhJqJU&C5k2R6zu";

            var conn = new MySqlConnection(connString);

            return conn;
        }

        /// <summary>
        /// Gets all stored Customers in the database
        /// </summary>
        /// <returns>List of Customers</returns>
        public async Task<List<User>> GetAllCustomers()
        {
            const string sql = "SELECT * FROM users ORDER BY ID DESC";
            List<User> sqlResult = new();

            //create command
            MySqlCommand cmd = new() {Connection = GetDbConnection()};
            //set connection for command
            cmd.Connection.Open();
            cmd.CommandText = sql;

            try
            {
                await using DbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        // Parse data into User Object
                        sqlResult.Add(new User
                        {
                            Id = int.Parse(reader["id"].ToString() ?? "0"),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            Email = reader["email"].ToString(),
                            Age = int.Parse(reader["age"].ToString() ?? "0")
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                //close connection
                await cmd.Connection.CloseAsync();
                //Dispose of object, freeing resources
                cmd.Connection.Dispose();
            }

            return sqlResult;
        }
    }
}
