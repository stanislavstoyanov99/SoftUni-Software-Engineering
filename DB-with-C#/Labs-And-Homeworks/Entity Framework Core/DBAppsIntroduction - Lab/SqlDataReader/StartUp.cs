namespace SqlDataReaderExample
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
                string sqlQuery = "SELECT * FROM Employees";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, dbConnection);

                using SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    decimal salary = (decimal)reader["Salary"];

                    Console.WriteLine($"{firstName} {lastName} - {salary}");
                }
            }
        }
    }
}
