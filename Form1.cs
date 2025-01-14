using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clientManagementApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DatabaseHelper.InitializeDatabase();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "user" && txtUserPassword.Text == "2001")
            {
                new Form2().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or password in incorrect");
                txtUserName.Clear();
                txtUserPassword.Clear();
                txtUserName.Focus();
            }
        }
    }
}
