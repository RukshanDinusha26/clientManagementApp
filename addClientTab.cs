using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientManagementApp
{
    public partial class addClientTab : UserControl
    {
        BindingSource clientBindingSource = new BindingSource();


        public addClientTab()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadClients();
            LoadCategories();
            searchBox.TextChanged += searchBox_TextChanged_1;
            dataGridViewClients.CellContentClick += dataGridViewClients_CellContentClick;
        }

        public void LoadClients()
        {
            var clients = Client.LoadAllClients();
            clientBindingSource.DataSource = clients;
            dataGridViewClients.DataSource = clientBindingSource;


        }

        private void searchBox_TextChanged_1(object sender, EventArgs e)
        {
            string filterText = searchBox.Text.Trim();


            if (string.IsNullOrEmpty(filterText))
            {

                dataGridViewClients.DataSource = new SortableBindingList<Client>(Client.LoadAllClients());
            }
            else
            {

                int filterId = -1;
                bool isIdFilter = int.TryParse(filterText, out filterId);


                var filteredClients = Client.LoadAllClients().Where(client =>
                    (isIdFilter && client.Id == filterId) ||
                    (client.Name != null && client.Name.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (client.Address != null && client.Address.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (client.Phone != null && client.Phone.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (client.Email != null && client.Email.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (client.Categories != null && client.Categories.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) >= 0)).ToList();

                dataGridViewClients.DataSource = new SortableBindingList<Client>(filteredClients);
                dataGridViewClients.Refresh();
            }
        }

        private void dataGridViewClients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure we're not triggering an update when the edit is being made to the new row
            if (e.RowIndex >= 0)
            {
                var columnName = dataGridViewClients.Columns[e.ColumnIndex].Name;

                // Skip the 'Id' column, since it shouldn't be editable
                if (columnName == "Id") return;

                // Get the updated value and client Id
                var clientId = dataGridViewClients.Rows[e.RowIndex].Cells["Id"].Value.ToString(); // Assuming 'Id' column is the primary key
                var updatedValue = dataGridViewClients.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); // Get updated value

                // Call a method to update the database with the new value
                UpdateClientInDatabase(clientId, columnName, updatedValue);
            }
        }

        private void UpdateClientInDatabase(string clientId, string columnName, string updatedValue)
        {

            string updateQuery = $"UPDATE Clients SET {columnName} = @updatedValue WHERE Id = @clientId";

            using (var connection = new SQLiteConnection(Client.connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(updateQuery, connection))
                {

                    command.Parameters.AddWithValue("@updatedValue", updatedValue);
                    command.Parameters.AddWithValue("@clientId", clientId);

                    try
                    {

                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating data: {ex.Message}");
                    }
                }
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewClients.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (DataGridViewCell cell in row.Cells)
                {

                    var columnName = dataGridViewClients.Columns[cell.ColumnIndex].Name;


                    if (dataGridViewClients.Columns[cell.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        continue; // Skip the button column
                    }

                    if (columnName == "Id") continue;

                    var updatedValue = cell.Value.ToString();
                    var clientId = row.Cells["Id"].Value.ToString();
                    UpdateClientInDatabase(clientId, columnName, updatedValue);
                }
            }

            MessageBox.Show("All changes saved successfully!");
        }

        private void LoadCategories()
        {
            // Example predefined categories
            var categories = new string[] { "Software", "Laptops & PC", "Games", "Office Tools", "Accessories" };

            // Bind the categories to the ComboBox
            txtCategory.Items.AddRange(categories);

            // Optionally set the first item as the default
            if (txtCategory.Items.Count > 0)
            {
                txtCategory.SelectedIndex = 0;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect input from text fields
                string name = txtName.Text.Trim();
                string address = txtAddress.Text.Trim();
                string phone = txtPhone.Text.Trim();
                string email = txtEmail.Text.Trim();
                string categories = txtCategory.SelectedItem?.ToString(); // Get selected category

                // Validate inputs
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create a new Client object and save to database
                Client newClient = new Client(name, address, phone, email, categories);
                Client.AddClient(newClient);

                MessageBox.Show("Client added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshClientData();
                ClearFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            public void RefreshClientData()
        {
            
            
                var clients = Client.LoadAllClients(); 
                clientBindingSource.DataSource = clients;
                dataGridViewClients.DataSource = clientBindingSource;
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshClientData();
        }
        private void ClearFields()
        {
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCategory.SelectedIndex = 0; // Reset to the first category
        }

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the clicked row is valid
            if (e.RowIndex < 0 || e.RowIndex >= dataGridViewClients.Rows.Count)
                return;

            // Ensure the click is on the Remove button column
            if (dataGridViewClients.Columns[e.ColumnIndex].Name == "remove")
            {
                int clientId = Convert.ToInt32(dataGridViewClients.Rows[e.RowIndex].Cells["Id"].Value);

                // Confirm deletion
                var confirmResult = MessageBox.Show($"Are you sure you want to remove this client (ID: {clientId})?",
                                                    "Confirm Remove",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Remove the client from the database
                        Client.RemoveClient(clientId);

                        MessageBox.Show("Client removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the DataGridView
                        RefreshClientData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error removing client: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void addClientTab_Load(object sender, EventArgs e)
        {

        }
    }
}

    
