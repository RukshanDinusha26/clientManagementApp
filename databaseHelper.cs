using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class DatabaseHelper
{

    public static string connectionString = @"Data Source=..\..\Files\Client.db;version=3;";

    public static void InitializeDatabase()
    {
        if (!File.Exists(@"..\..\Files\Client.db"))
        {
            SQLiteConnection.CreateFile(@"..\..\Files\Client.db");
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Clients (
                                            ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                            Name TEXT NOT NULL,
                                            Address TEXT,
                                            Phone TEXT,
                                            Email TEXT,
                                            Categories TEXT)";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
