namespace _04AddMinion
{
    using System;
    using System.Data.SqlClient;
    using _01InitialSetup;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)[1];
            string[] minionInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];

            string[] villainInfo = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries);

            string villainName = villainInfo[1];

            SqlConnection connection = new SqlConnection(Configuration.ConnectionString);

            connection.Open();

            using (connection)
            {
                // Town check
                using SqlCommand townCmd = new SqlCommand(Queries.TakeTownId, connection);

                townCmd.Parameters.AddWithValue("@townName", minionTown);

                object townId = townCmd.ExecuteScalar();

                if (townId != null)
                {
                    townId = (int)townId;
                }
                else
                {
                    using SqlCommand townCmdToAdd = new SqlCommand(Queries.InsertTownName, connection);

                    townCmdToAdd.Parameters.AddWithValue("@townName", minionTown);

                    townCmdToAdd.ExecuteNonQuery();

                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                // TODO - change methods logic
                // Villain check
                string villainQueryForExistence = @"SELECT Id FROM Villains WHERE Name = @Name";

                using SqlCommand villainCmd = new SqlCommand(villainQueryForExistence, connection);

                villainCmd.Parameters.AddWithValue("@Name", villainName);

                object villainId = villainCmd.ExecuteScalar();

                // Villain does not exist in database
                if (villainId != null)
                {
                    villainId = (int)villainId;

                    string villainQueryToAdd = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

                    using SqlCommand villainCmdToAdd = new SqlCommand(villainQueryToAdd, connection);

                    villainCmdToAdd.Parameters.AddWithValue("@villainName", villainName);

                    villainCmdToAdd.ExecuteNonQuery();

                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                // Minion check
                string minionQueryForExistence = @"SELECT Id FROM Minions WHERE Name = @Name";

                using SqlCommand minionCmd = new SqlCommand(minionQueryForExistence, connection);

                minionCmd.Parameters.AddWithValue("@Name", minionName);

                object minionId = minionCmd.ExecuteScalar();

                // Minion does not exist in database
                if (minionId != null)
                {
                    minionId = (int)minionId;

                    string minionQueryToAdd = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

                    using SqlCommand minionCmdToAdd = new SqlCommand(minionQueryToAdd, connection);

                    minionCmdToAdd.Parameters.AddWithValue("@name", minionName);
                    minionCmdToAdd.Parameters.AddWithValue("@age", minionAge);
                    minionCmdToAdd.Parameters.AddWithValue("@townId", townId);
                    minionCmdToAdd.ExecuteNonQuery();
                }

                // Adding minion to be servant of villain
                string servantOfVillain = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

                using SqlCommand minionOfVillainCmd = new SqlCommand(servantOfVillain, connection);
                minionOfVillainCmd.Parameters.AddWithValue("@villainId", villainId);
                minionOfVillainCmd.Parameters.AddWithValue("@minionId", minionId);
                minionOfVillainCmd.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}
