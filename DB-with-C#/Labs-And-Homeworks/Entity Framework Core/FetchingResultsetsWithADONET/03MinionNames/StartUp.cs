namespace _03MinionNames
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        private const string DB_NAME = "MinionsDB";

        private static string connectionString = @$"Server=.\SQLEXPRESS;Database={DB_NAME};Integrated Security=true";

        public static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                string idQuery = @"SELECT [Name] FROM Villains WHERE Id = @Id";

                using SqlCommand idCommand = new SqlCommand(idQuery, connection);

                idCommand.Parameters.AddWithValue("@Id", villainId);

                string villainName = (string)idCommand.ExecuteScalar();

                if (villainName == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }

                string minionsQuery = @"SELECT ROW_NUMBER() OVER(ORDER BY [Name]) AS RowNumber, 
                                               m.[Name] AS MinionName, 
                                               m.Age AS MinionAge
                                          FROM MinionsVillains AS mv
                                               JOIN Minions AS m ON m.Id = mv.MinionId
                                         WHERE mv.VillainId = @Id
                                      ORDER BY m.[Name]";

                using SqlCommand minionsCommand = new SqlCommand(minionsQuery, connection);

                minionsCommand.Parameters.AddWithValue("@Id", villainId);

                SqlDataReader sqlDataReader = minionsCommand.ExecuteReader();

                using (sqlDataReader)
                {
                    Console.WriteLine($"Villain: {villainName}");

                    int counter = 1;
                    while (sqlDataReader.Read())
                    {
                        string minionName = (string)sqlDataReader["MinionName"];

                        if (sqlDataReader.HasRows)
                        {
                            int minionAge = (int)sqlDataReader["MinionAge"];

                            Console.WriteLine($"{counter}. {minionName} {minionAge}");
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
            }
        }
    }
}
