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
using System.Diagnostics;

namespace CashControl
{
    public partial class Income : Form
    {

        public Income()
        {
            InitializeComponent();
        }

        private void Income_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboardd = new Dashboard();
            dashboardd.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses expense = new Expenses();
            expense.Show();
            this.Hide();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            ViewIncome ViewIncomee = new ViewIncome();
            ViewIncomee.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses ViewExpensess = new ViewExpenses();
            ViewExpensess.Show();
            this.Hide();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Loginn Login = new Loginn();
            string incomeName = textBox1.Text; // Nome do campo correspondente ao nome do rendimento
            decimal incomeAmount;
            string incomeCategory = comboBox1.SelectedItem?.ToString(); // Combobox para a categoria do rendimento
            DateTime incomeDate = dateTimePicker1.Value; // DateTimePicker para a data do rendimento

            // Verificar se todos os campos estão preenchidos e se os valores são válidos
            if (string.IsNullOrEmpty(incomeName) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                !decimal.TryParse(textBox2.Text, out incomeAmount) ||
                string.IsNullOrEmpty(incomeCategory))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos corretamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // Inserir na tabela Income

                    string insertIncomeQuery = "INSERT INTO Income (IncomeName, IncomeAmount, IncomeCategory, IncomeDate, IncomeUser) VALUES (@IncomeName, @IncomeAmount, @IncomeCategory, @IncomeDate, @IncomeUser)";

                    using (SqlCommand cmd = new SqlCommand(insertIncomeQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@IncomeName", incomeName);
                        cmd.Parameters.AddWithValue("@IncomeAmount", incomeAmount);
                        cmd.Parameters.AddWithValue("@IncomeCategory", incomeCategory);
                        cmd.Parameters.AddWithValue("@IncomeDate", incomeDate);
                        cmd.Parameters.AddWithValue("@IncomeUser", Loginn.loginUser);

                        cmd.ExecuteNonQuery();
                    }

                    // Commitar a transação
                    transaction.Commit();
                    MessageBox.Show("Income registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback em caso de erro
                    transaction.Rollback();
                    MessageBox.Show($"Erro ao registrar o income: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
        }
    }
}
