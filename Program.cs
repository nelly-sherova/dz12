using System;
using System.Data;
using System.Data.SqlClient;

namespace dzz12
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = @"Data source=NILUFARSHEROVA; Initial catalog=Person; Integrated Security = True";
            SqlConnection con = new SqlConnection(connectionString);
            int counter;
            Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->3 \nUpdate - > 4 \nDelete -> 5 \nExit ->0");
            Console.Write("Select a command = ");
            counter = Convert.ToInt32(Console.ReadLine());
            while (counter != 0 )
            {
                switch (counter)
                {
                    case 1:
                    {
                        Console.Write("FirstName: "); string FN = Console.ReadLine();
                        Console.Write("LastName: ");  string LN = Console.ReadLine();
                        Console.Write("MiddleName: "); string MN = Console.ReadLine();
                        Console.Write("Day of Birth (format: dd): ");
                        string day = Console.ReadLine();
                        Console.Write("Month Of Birth (format: MM): ");
                        string month = Console.ReadLine();
                        Console.Write("Year of Birth (format:YYYY): ");
                        string year = Console.ReadLine();
                        string Birthdate = day+"."+month+"."+year;
                        string sqlExpression = $"INSERT INTO Personn ([FirstName],[LastName], [MiddleName], [BirthDate]) VALUES ( '{FN}', '{LN}', '{MN}' , '{Birthdate}')";
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            int number = command.ExecuteNonQuery();
                            Console.WriteLine("Добавлено объектов: {0}", number);
                            Console.Write("Select a command = ");
                            counter = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    break;
                    case 2:
                    string sqlExpression1 = "SELECT * FROM Personn";
                    using (SqlConnection connection1 = new SqlConnection(connectionString))
                    {
                        connection1.Open();
                        SqlCommand command1 = new SqlCommand(sqlExpression1, connection1);
                        SqlDataReader reader  = command1.ExecuteReader();
                        while (reader.Read()) Console.WriteLine($"ID: {reader.GetValue(0)}, Firstname:{reader.GetValue(1)}, LastName:{reader.GetValue(2)}, MiddleName:{reader.GetValue(3)}, BirthDate:{reader.GetValue(4)}");
                        Console.Write("Select a command = ");
                        counter = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                    case 3:
                    Console.Write("id = ");
                    int iD = Convert.ToInt32(Console.ReadLine());
                    string sqlExpression2 = $"select * from table where id in '{iD}'";
                }
            }
        }
    }
}
