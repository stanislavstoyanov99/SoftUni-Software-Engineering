namespace _01InitialSetup
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            connection.Open();

            using (connection)
            {
                using SqlCommand sqlCommand = new SqlCommand(Configuration.CreateDatabase, connection);

                try
                {
                    sqlCommand.ExecuteNonQuery();
                    Console.WriteLine("Successfully created database MinionsDB");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid operation: {ex.Message}");
                    return;
                }

                foreach (var query in Configuration.CreateTablesQueries)
                {
                    using SqlCommand createTableCmd = new SqlCommand(query, connection);

                    try
                    {
                        createTableCmd.ExecuteNonQuery();
                        Console.WriteLine($"Successfully created tables");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid operation: {ex.Message}");
                    }
                }

                foreach (var query in Configuration.InsertQueries)
                {
                    using SqlCommand insertCmd = new SqlCommand(query, connection);

                    try
                    {
                        int affectedRows = insertCmd.ExecuteNonQuery();
                        Console.WriteLine("Successfully inserted data into tables");
                        Console.WriteLine($"Affected rows: {affectedRows}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Invalid operation: {ex.Message}");
                    }
                }
            }
        }
    }
}
