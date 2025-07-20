using System;
using System.Data.SqlClient;

class Display{
    public void Print()
    {
        Console.WriteLine("*******************Ankit Mishra Bank***********");
        Console.WriteLine("Login Page");
    }
}

static class UseNameAndPass
{
    public static string username;
    public static string password;
}

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
            int noOfCustomers = Convert.ToInt32(Console.ReadLine()); 


            for (int i = 0; i < noOfCustomers; i++)
            {
                Console.Write("Enter UserName for new user: ");
                string tempUserName = UseNameAndPass.username = Console.ReadLine();
                Console.Write("Enter Password for the user: ");
                string tempPass = UseNameAndPass.password = Console.ReadLine();

                command.Parameters.AddWithValue("@username", tempUserName);
                command.Parameters.AddWithValue("@password", tempPass);
                command.Parameters.AddWithValue("@role", "user");
                command.Parameters.AddWithValue("@balance", 0);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
                Console.WriteLine("Data Added Successfully");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Display d = new Display();
        d.Print();
        InsertDataExaple.InsertToUser();
    }
}   