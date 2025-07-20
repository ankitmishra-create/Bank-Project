using System;
using System.Data.SqlClient;

class InsertDataExaple
{
    public static void InsertToUser()
    {
        string connectionString = "Data Source=localhost;Initial Catalog=bank_records;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
                
            string query = "insert into users (username,password,role,balance) values (@username, @password, @role, @balance)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@username", "testuser");
            command.Parameters.Add("@password", "testpassword");
            command.Parameters.Add("@role", "user");
            command.Parameters.Add("@balance", 1000.00);
            command.ExecuteNonQuery();

            Console.WriteLine("Data inserted successfully into users table.");  
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        InsertDataExaple.InsertToUser();
    }
}   