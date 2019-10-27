namespace _07PrintAllMinionNames
{
    using System;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using _01InitialSetup;

    public class StartUp
    {
        private static string DbName = "MinionsDB";

        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString, DbName));

            connection.Open();

            using (connection)
            {
                using SqlCommand sqlCommand = new SqlCommand(Queries.TakeMinionNames, connection);

                using SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                List<string> originalNames = new List<string>(sqlReader.FieldCount);

                while (sqlReader.Read())
                {
                    string name = (string)sqlReader["Name"];
                    originalNames.Add(name);
                }

                Console.WriteLine($"Original order: {Environment.NewLine + string.Join(Environment.NewLine, originalNames)}");

                Console.WriteLine("----------------");

                Console.WriteLine("New order:");

                while (originalNames.Count != 0)
                {
                    Console.WriteLine(originalNames[0]);
                    originalNames.RemoveAt(0);

                    if (originalNames.Count == 0)
                    {
                        break;
                    }

                    Console.WriteLine(originalNames.Last());
                    originalNames.RemoveAt(originalNames.Count - 1);
                }
            }
        }
    }
}
