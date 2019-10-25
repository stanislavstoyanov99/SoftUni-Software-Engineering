namespace _02VillainNames
{
    using System;
    using System.Data.SqlClient;
    using _01InitialSetup;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            connection.Open();

            using (connection)
            {
                using SqlCommand sqlCommand = new SqlCommand(Queries.VillainNames, connection);

                try
                {
                    using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        string villainName = (string)sqlDataReader["Name"];
                        int minionsCount = (int)sqlDataReader["MinionsCount"];

                        Console.WriteLine($"{villainName} - {minionsCount}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid operation: {ex.Message}");
                }
            }
        }
    }
}
