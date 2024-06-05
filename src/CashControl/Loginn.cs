using Microsoft.Data.SqlClient;
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
    public partial class Loginn : Form
    {
        public Loginn()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterUser Register = new RegisterUser();
            Register.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Loginn_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = textBox1.Text;
            string loginPassword = textBox5.Text;

            // Verificar se todos os campos estão preenchidos
            if (string.IsNullOrEmpty(loginUser) || string.IsNullOrEmpty(loginPassword))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Definir a string de conexão
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Loginn WHERE LoginUser = @LoginUser AND LoginPassword = @LoginPassword";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LoginUser", loginUser);
                    cmd.Parameters.AddWithValue("@LoginPassword", loginPassword);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        // Login bem-sucedido, abre o dashboard
                        MessageBox.Show("Login bem-sucedido!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Dashboard dashboard = new Dashboard(); 
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Login falhou
                        MessageBox.Show("Usuário ou senha incorretos. Por favor, tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}