namespace _08IncreaseMinionAge
{
    using System;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Collections.Generic;

    using _01InitialSetup;

    public class StartUp
    {
        private const string DbName = "MinionsDB";

        public static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(String.Format(Configuration.ConnectionString, DbName));

            connection.Open();

            using (connection)
            {
                List<int> minionsIds = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                using SqlCommand updateCmd = new SqlCommand(Queries.UpdateMinions, connection);

                for (int i = 0; i < minionsIds.Count; i++)
                {
                    int currentId = minionsIds[i];
                    updateCmd.Parameters.AddWithValue("@Id", currentId);
                    updateCmd.ExecuteNonQuery();
                    updateCmd.Parameters.Clear();
                }

                using SqlCommand resultCmd = new SqlCommand(Queries.TakeMinionsNameAndAge, connection);
                using SqlDataReader reader = resultCmd.ExecuteReader();

                while (reader.Read())
                {
                    string minionName = (string)reader["Name"];
                    int minionAge = (int)reader["Age"];

                    Console.WriteLine($"{minionName} {minionAge}");
                }
            }
        }
    }
}
