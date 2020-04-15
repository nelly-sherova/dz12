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
                            Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->3 \nUpdate - > 5 \nDelete -> 3 \nExit ->0");
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
                        while (reader.Read()) Console.WriteLine($"ID: {reader.GetValue(0)}, Firstname:{reader.GetValue(1)} | LastName:{reader.GetValue(2)} | MiddleName:{reader.GetValue(3)} | BirthDate:{reader.GetValue(4)}");
                        Console.Write("Select a command = ");
                        Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->3 \nUpdate - > 4\nDelete -> 5 \nExit ->0");
                        counter = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                    case 4:
                    Console.Write("id = ");
                    int iD = Convert.ToInt32(Console.ReadLine());
                    string  sqlExpressionn = $"Select * from Personn where Personn.Id = {iD}";
                    using (SqlConnection connectionn = new SqlConnection(connectionString))
                    {
                        connectionn.Open();
                        SqlCommand commandd = new SqlCommand(sqlExpressionn, connectionn);
                        var reader1 = commandd.ExecuteReader();
                        while (reader1.Read())
                        {
                        Console.WriteLine($"id :{reader1.GetValue("Id")} | {reader1.GetValue("FirstName")} | {reader1.GetValue("LastName")} | {reader1.GetValue("MiddleName")} | {reader1.GetValue("BirthDate")}");
                        }
                        Console.Write("Select a command = ");
                        Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->3 \nUpdate - > 4 \nDelete -> 5 \nExit ->0");
                        counter = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                    case 3:
                    Console.Write("id = ");
                    int i = Convert.ToInt32(Console.ReadLine());
                    string sqlExpression3 = $"DELETE  FROM Personn WHERE Id ='{i}'";
                    using (SqlConnection connection3 = new SqlConnection(connectionString))
                    {
                    connection3.Open();
                    SqlCommand command3 = new SqlCommand(sqlExpression3, connection3);
                    int number1 = command3.ExecuteNonQuery();
                    Console.WriteLine("Удалено объектов: {0}", number1);
                    Console.Write("Select a command = ");
                    Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->3 \nUpdate - > 4 \nDelete -> 5 \nExit ->0");
                    counter = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                    case 5:
                    Console.WriteLine("Choose line: \n 1->FirstName \n 2->LastName \n 3->MiddleName \n 4-> BirthDate");
                    int line = Convert.ToInt32(Console.ReadLine());
                    switch (line)
                    {
                        case 1: 
                            Console.Write("Firstname: "); string name = Console.ReadLine();
                            Console.Write("new FirstName: "); string name1 = Console.ReadLine();
                            string sqlExpression4 = $"UPDATE Personn SET FirstName = '{name1}'  WHERE FirstName ='{name}'";
                            using (SqlConnection connection4 = new SqlConnection(connectionString))
                            {
                            connection4.Open();
                            SqlCommand command4 = new SqlCommand(sqlExpression4, connection4);
                            int number2 = command4.ExecuteNonQuery();
                            Console.WriteLine("Обновлено объектов: {0}", number2);
                            Console.Write("Select a command = ");
                            Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->3 \nUpdate - > 4 \nDelete -> 5 \nExit ->0");
                            counter = Convert.ToInt32(Console.ReadLine());
                            }
                        break;
                        case 2: 
                            Console.Write("Lastname: "); string surname = Console.ReadLine();
                            Console.Write("new LastName: "); string surname1 = Console.ReadLine();
                            string sqlExpression42 = $"UPDATE Personn SET LastName = '{surname1}'  WHERE LastName ='{surname}'";
                            using (SqlConnection connection42 = new SqlConnection(connectionString))
                            {
                            connection42.Open();
                            SqlCommand command42 = new SqlCommand(sqlExpression42, connection42);
                            int number22 = command42.ExecuteNonQuery();
                            Console.WriteLine("Обновлено объектов: {0}", number22);
                            Console.Write("Select a command = ");
                            Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->3 \nUpdate - > 4 \nDelete -> 5 \nExit ->0");
                            counter = Convert.ToInt32(Console.ReadLine());
                            }
                        break;
                        case 3: 
                            Console.Write("Middlename: "); string midname = Console.ReadLine();
                            Console.Write("new MiddleName: "); string midname1 = Console.ReadLine();
                            string sqlExpression43 = $"UPDATE Personn SET MiddleName = '{midname1}'  WHERE MiddleName ='{midname}'";
                            using (SqlConnection connection43 = new SqlConnection(connectionString))
                            {
                            connection43.Open();
                            SqlCommand command43 = new SqlCommand(sqlExpression43, connection43);
                            int number23 = command43.ExecuteNonQuery();
                            Console.WriteLine("Обновлено объектов: {0}", number23);
                            Console.Write("Select a command = ");
                            Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->3 \nUpdate - > 4 \nDelete -> 5 \nExit ->0");
                            counter = Convert.ToInt32(Console.ReadLine());
                            }
                        break;
                        case 4: 
                            Console.Write("BirthDate: "); 
                            Console.Write("Day of Birth (format: dd): ");
                            string day1 = Console.ReadLine();
                            Console.Write("Month Of Birth (format: MM): ");
                            string month1 = Console.ReadLine();
                            Console.Write("Year of Birth (format:YYYY): ");
                            string year1 = Console.ReadLine();
                            string Birthdate1 = day1+"."+month1+"."+year1;
                            Console.Write("New BirthDate: "); 
                            Console.Write("Day of Birth (format: dd): ");
                            string day2 = Console.ReadLine();
                            Console.Write("Month Of Birth (format: MM): ");
                            string month2 = Console.ReadLine();
                            Console.Write("Year of Birth (format:YYYY): ");
                            string year2 = Console.ReadLine();
                            string Birthdate2 = day2+"."+month2+"."+year2;
                            string sqlExpression44 = $"UPDATE Personn SET BirthDate = '{Birthdate2}' Where  BirthDate ='{Birthdate1}'";
                            using (SqlConnection connection44 = new SqlConnection(connectionString))
                            {
                            connection44.Open();
                            SqlCommand command44 = new SqlCommand(sqlExpression44, connection44);
                            int number24 = command44.ExecuteNonQuery();
                            Console.WriteLine("Обновлено объектов: {0}", number24);
                            Console.Write("Select a command = ");
                            Console.WriteLine("Insert -> 1 \nSelect All -> 2 \nSelect by Id ->3 \nUpdate - > 4 \nDelete -> 5 \nExit ->0");
                            counter = Convert.ToInt32(Console.ReadLine());
                            }
                        break;
                    }
                    break;
                }
            }
        }
    }
}
