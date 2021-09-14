using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using CustomerViewerAPI.Models;
using CustomerViewerAPI.Services;
using MySql.Data.MySqlClient;

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
            Config dbConfig = FileReaderService.GetDbConfig();
            // Connection String.
            string connString = $"Server={dbConfig.DbHost}" + $";Database={dbConfig.DbDatabase}" + $";port={dbConfig.DbPort}" 
                                + $";User Id={dbConfig.DbUserId}" + $";password={dbConfig.DbPassword}";

            var conn = new MySqlConnection(connString);

            return conn;
        }

        /// <summary>
        /// Gets all stored Customers in the database
        /// </summary>
        /// <returns>List of Customers</returns>
        public static async Task<List<User>> GetAllCustomers()
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

        public static async Task<User> GetCustomer(int id)
        {
            string sql = $"SELECT * FROM users WHERE id = {id}";
            User sqlResult = new();

            //create command
            MySqlCommand cmd = new() { Connection = GetDbConnection() };
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
                        sqlResult = new User
                        {
                            Id = int.Parse(reader["id"].ToString() ?? "0"),
                            FirstName = reader["first_name"].ToString(),
                            LastName = reader["last_name"].ToString(),
                            Email = reader["email"].ToString(),
                            Age = int.Parse(reader["age"].ToString() ?? "0")
                        };
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

        public static async Task UpdateCustomer(User customer)
        {
            string sql = $"UPDATE userdb.users t SET t.first_name = '{customer.FirstName}', t.last_name = '{customer.LastName}', " +
                         $"t.email = '{customer.Email}', t.age = {customer.Age} WHERE t.id = {customer.Id}";

            //create command
            MySqlCommand cmd = new() { Connection = GetDbConnection() };
            //set connection for command
            cmd.Connection.Open();
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
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
        }

        public static async Task AddCustomer(User customer)
        {
            string sql = $"INSERT INTO userdb.users (first_name, last_name, email, age) VALUES ('{customer.FirstName}', '{customer.LastName}'," +
                         $" '{customer.Email}', {customer.Age})";

            //create command
            MySqlCommand cmd = new() { Connection = GetDbConnection() };
            //set connection for command
            cmd.Connection.Open();
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
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
        }

        public static async Task DeleteCustomer(int id)
        {
            string sql = $"DELETE FROM userdb.users WHERE id = {id}";

            //create command
            MySqlCommand cmd = new() { Connection = GetDbConnection() };
            //set connection for command
            cmd.Connection.Open();
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
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
        }
    }
}