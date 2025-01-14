using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace clientManagementApp
{
    public partial class clientTab : UserControl
    {
        private bool isSortAscending = true;

        public clientTab()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            LoadClients();
            dataGridViewClients.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
            searchBox.TextChanged += searchBox_TextChanged_1;
            dataGridViewClients.CellContentClick += DataGridViewClients_CellContentClick;


        }

        public void LoadClients()
        {
            var clients = Client.LoadAllClients();
            clientBindingSource.DataSource = clients;
            dataGridViewClients.DataSource = clientBindingSource;

            
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            string columnName = grid.Columns[e.ColumnIndex].Name;

            if (columnName == "Name") // Only allow sorting on the "Name" column
            {
                // Toggle the sort direction
                isSortAscending = !isSortAscending;

                // Sort the BindingSource
                if (isSortAscending)
                {
                    clientBindingSource.Sort = "Name ASC";
                }
                else
                {
                    clientBindingSource.Sort = "Name DESC";
                }
            }
        }


        private void clientBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewClients.Columns["Print"].Index)
            {
                // Get the selected client (based on the row index)
                var selectedClient = clientBindingSource.List[e.RowIndex] as Client;
                if (selectedClient != null)
                {
                    // Call the method to print the selected client's details
                    PrintClientDetails(selectedClient);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();
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
        private void ExportToExcel()
        {
            // Set the license context for EPPlus (required for versions 5.x and above)
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Or Commercial for commercial use

            // Check if there is any data in the BindingSource
            var clients = Client.LoadAllClients();
            clientBindingSource.DataSource = clients;
            if (clients == null || clients.Count == 0)
            {
                MessageBox.Show("No data to export.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a SaveFileDialog to let the user choose where to save the file
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save Excel File";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Create a new Excel package
                        using (var package = new ExcelPackage())
                        {
                            // Add a new worksheet to the Excel package
                            var worksheet = package.Workbook.Worksheets.Add("Clients");

                            // Add headers (column names)
                            worksheet.Cells[1, 1].Value = "ID";
                            worksheet.Cells[1, 2].Value = "Name";
                            worksheet.Cells[1, 3].Value = "Address";
                            worksheet.Cells[1, 4].Value = "Phone";
                            worksheet.Cells[1, 5].Value = "Email";
                            worksheet.Cells[1, 6].Value = "Categories";

                            // Add the rows of data to the Excel worksheet
                            for (int row = 0; row < clients.Count; row++)
                            {
                                var client = clients[row];
                                worksheet.Cells[row + 2, 1].Value = client.Id;
                                worksheet.Cells[row + 2, 2].Value = client.Name;
                                worksheet.Cells[row + 2, 3].Value = client.Address;
                                worksheet.Cells[row + 2, 4].Value = client.Phone;
                                worksheet.Cells[row + 2, 5].Value = client.Email;
                                worksheet.Cells[row + 2, 6].Value = client.Categories;
                            }

                            // Save the Excel file to the chosen path
                            FileInfo fileInfo = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(fileInfo);
                        }

                        MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error exporting data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DataGridViewClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewClients.Columns["Print"].Index)
            {
                // Get the selected client (based on the row index)
                var selectedClient = clientBindingSource.List[e.RowIndex] as Client;
                if (selectedClient != null)
                {
                    // Call the method to print the selected client's details
                    PrintClientDetails(selectedClient);
                }
            }
        }
        private void PrintClientDetails(Client client)
        {
            // Create a PrintDocument instance
            PrintDocument printDoc = new PrintDocument();

            // Set the event handler for the PrintPage event
            printDoc.PrintPage += (sender, e) =>
            {
                // Print client details
                e.Graphics.DrawString("Client Details", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, 100, 100);
                e.Graphics.DrawString($"ID: {client.Id}", new Font("Arial", 12), Brushes.Black, 100, 140);
                e.Graphics.DrawString($"Name: {client.Name}", new Font("Arial", 12), Brushes.Black, 100, 180);
                e.Graphics.DrawString($"Address: {client.Address}", new Font("Arial", 12), Brushes.Black, 100, 220);
                e.Graphics.DrawString($"Phone: {client.Phone}", new Font("Arial", 12), Brushes.Black, 100, 260);
                e.Graphics.DrawString($"Email: {client.Email}", new Font("Arial", 12), Brushes.Black, 100, 300);
                e.Graphics.DrawString($"Categories: {client.Categories}", new Font("Arial", 12), Brushes.Black, 100, 340);
            };

            // Show the print dialog to the user
            PrintDialog printDialog = new PrintDialog
            {
                Document = printDoc
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Print the document (this triggers the PrintPage event)
                printDoc.Print();

                // Show success message after printing
                MessageBox.Show("Client details printed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
