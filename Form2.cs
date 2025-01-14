using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace clientManagementApp
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
            clientTab1.Visible = true;
            addClientTab1.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
            clientTab1.Visible = true;
            addClientTab1.Visible = false;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            clientTab1.Visible = false;
            addClientTab1.Visible = true;
        }
        private void Logout()
        {
            
            var confirmResult = MessageBox.Show("Are you sure you want to log out?",
                                                "Confirm Logout",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {

                    
                    Form1 loginForm = new Form1();
                    loginForm.Show();

                   
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during logout: {ex.Message}",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}
