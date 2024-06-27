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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Account_Load(object sender, EventArgs e)
        {
            DisplayUserDetails();


        }

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

        private void DisplayUserDetails()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT NomeApelido, LoginUser, UserEmail, NumeroTLF FROM Account WHERE LoginUser = @LoginUser";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@LoginUser", Loginn.loginUser);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            label1.Text = reader["NomeApelido"].ToString();
                            label2.Text = reader["LoginUser"].ToString();
                            label3.Text = reader["UserEmail"].ToString();
                            label4.Text = reader["NumeroTLF"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("User details not found.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error retrieving user details: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void UpdateUserDetails()
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    Loginn Loginnn = new Loginn();
                    conn.Open();
                    string query = "UPDATE Account SET UserEmail = @UserEmail, NumeroTLF = @NumeroTLF WHERE LoginUser = @LoginUser";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@UserEmail", textBox1.Text);
                    command.Parameters.AddWithValue("@NumeroTLF", textBox2.Text);
                    command.Parameters.AddWithValue("@LoginUser", Loginn.loginUser);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User details updated successfully.");
                        DisplayUserDetails(); // Atualiza os detalhes do usuário na interface
                    }
                    else
                    {
                        MessageBox.Show("Error updating user details.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating user details: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
