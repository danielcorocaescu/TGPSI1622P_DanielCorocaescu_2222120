using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashControl
{
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Loginn LoginForm = new Loginn();
            LoginForm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string username;
            username = Console.ReadLine();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string password;
            password = Console.ReadLine();
        }
    }
}
