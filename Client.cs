using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Drawing.Printing;


public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Categories { get; set; }

    public Client(string name, string address, string phone, string email, string categories)
    {
        Name = name;
        Address = address;
        Phone = phone;
        Email = email;
        Categories = categories;
    }

    public static string connectionString = @"Data Source=..\..\Files\Client.db;version=3;";

    public static void AddClient(Client client)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string insertQuery = @"INSERT INTO clients (Name, Address, Phone, Email, Categories) 
                                   VALUES (@name, @address, @phone, @email, @categories)";
            using (var command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@name", client.Name);
                command.Parameters.AddWithValue("@address", client.Address);
                command.Parameters.AddWithValue("@phone", client.Phone);
                command.Parameters.AddWithValue("@email", client.Email);
                command.Parameters.AddWithValue("@categories", client.Categories);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void RemoveClient(int id)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string deleteQuery = "DELETE FROM clients WHERE Id = @id";
            using (var command = new SQLiteCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }


    public static SortableBindingList<Client> LoadAllClients()
    {
        SortableBindingList<Client> clients = new SortableBindingList<Client>();
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            string selectQuery = "SELECT * FROM Clients";
            using (var command = new SQLiteCommand(selectQuery, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.IsDBNull(1) ? "Unknown" : reader.GetString(1);
                    string address = reader.IsDBNull(2) ? "Not Provided" : reader.GetString(2);
                    string phone = reader.IsDBNull(3) ? "Not Provided" : reader.GetString(3);
                    string email = reader.IsDBNull(4) ? "Not Provided" : reader.GetString(4);
                    string categories = reader.IsDBNull(5) ? "Uncategorized" : reader.GetString(5);

                    clients.Add(new Client(name, address, phone, email, categories) { Id = id });
                }
            }
        }
        return clients;
    }

}