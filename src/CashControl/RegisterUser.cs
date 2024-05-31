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
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
        }

        private void RegisterUser_Load(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True");

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Loginn LoginForm = new Loginn();
            LoginForm.Show();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = textBox1.Text;
            string loginPassword = textBox5.Text;
            string nomeApelido = textBox3.Text;
            string numeroTLF = textBox2.Text;
            string userEmail = textBox5.Text;

            // Verificar se todos os campos estão preenchidos
            if (string.IsNullOrEmpty(loginUser) || string.IsNullOrEmpty(loginPassword) ||
                string.IsNullOrEmpty(nomeApelido) || string.IsNullOrEmpty(numeroTLF) ||
                string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Definir a string de conexão
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Inserir na tabela Loginn
                    string insertLoginQuery = "INSERT INTO Loginn (LoginUser, LoginPassword) VALUES (@LoginUser, @LoginPassword)";
                    using (SqlCommand cmd = new SqlCommand(insertLoginQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@LoginUser", loginUser);
                        cmd.Parameters.AddWithValue("@LoginPassword", loginPassword);
                        cmd.ExecuteNonQuery();
                    }

                    // Inserir na tabela Account
                    string insertAccountQuery = "INSERT INTO Account (LoginUser, NomeApelido, NumeroTLF, UserEmail) VALUES (@LoginUser, @NomeApelido, @NumeroTLF, @UserEmail)";
                    using (SqlCommand cmd = new SqlCommand(insertAccountQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@LoginUser", loginUser);
                        cmd.Parameters.AddWithValue("@NomeApelido", nomeApelido);
                        cmd.Parameters.AddWithValue("@NumeroTLF", numeroTLF);
                        cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                        cmd.ExecuteNonQuery();
                    }

                    // Commitar a transação
                    transaction.Commit();
                    MessageBox.Show("Registro efetuado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback em caso de erro
                    transaction.Rollback();
                    MessageBox.Show($"Erro ao registar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
