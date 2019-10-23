namespace _02VillainNames
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string DB_NAME = "MinionsDB";

        private static string connectionString = @$"Server=.\SQLEXPRESS;Database={DB_NAME};Integrated Security=true";

        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                string queryText = @"SELECT [Name], 
                                            COUNT(mv.MinionId) AS [MinionsCount]
                                       FROM Villains AS v
                                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                   GROUP BY [Name]
                                     HAVING COUNT(mv.MinionId) > 3
                                   ORDER BY COUNT(mv.MinionId) DESC";

                SqlCommand sqlCommand = new SqlCommand(queryText, connection);

                try
                {
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    using (sqlDataReader)
                    {
                        while (sqlDataReader.Read())
                        {
                            string villainName = (string)sqlDataReader["Name"];
                            int minionsCount = (int)sqlDataReader["MinionsCount"];

                            Console.WriteLine($"{villainName} - {minionsCount}");
                        }
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
