namespace DBAppsIntroduction
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
                string sqlQuery = @"SELECT COUNT(*) FROM Employees";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, dbConnection);

                int employeesCount = (int)sqlCommand.ExecuteScalar();
                Console.WriteLine($"Employees count: {employeesCount} employees from Employees table, SoftUni Database");
            }
        }
    }
}
