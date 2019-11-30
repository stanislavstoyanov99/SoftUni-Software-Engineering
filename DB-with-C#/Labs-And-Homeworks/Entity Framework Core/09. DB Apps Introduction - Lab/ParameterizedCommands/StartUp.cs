namespace ParameterizedCommands
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=SoftUni;Integrated Security=true";
            SqlConnection dbConnection = new SqlConnection(connectionString);

            dbConnection.Open();

            using (dbConnection)
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Projects WHERE ProjectId = 128", dbConnection);
                using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    string projectName = (string)sqlDataReader["Name"];
                    string description = (string)sqlDataReader["Description"];
                    string startDate = Convert.ToDateTime(sqlDataReader["StartDate"]).ToString("dd-MM-yyyy");
                    string endDate = Convert.ToDateTime(sqlDataReader["EndDate"]).ToString("dd-MM-yyyy");

                    // Prints Pesho - Test - 23-10-2019 - 20-10-2019
                    Console.WriteLine($"{projectName} {description} - {startDate} - {endDate}");
                }
            }
        }

        public static int InsertProject(string name, string description, DateTime startDate,
            DateTime endDate, SqlConnection dbConnection)
        {
            string sqlQuery = @"INSERT INTO Projects(Name, Description, StartDate, EndDate) VALUES (@name, @desc, @start, @end)";

            SqlCommand sqlCommand = new SqlCommand(sqlQuery, dbConnection);

            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@desc", description);
            sqlCommand.Parameters.AddWithValue("@start", startDate);
            sqlCommand.Parameters.AddWithValue("@end", endDate);

            // returns affected rows
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
