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
    public partial class Expenses : Form
    {

        public Expenses()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboardd = new Dashboard();
            dashboardd.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Income incomeForm = new Income();
            incomeForm.Show();
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ExpenseName = textBox1.Text;
            decimal ExpenseAmount;
            string ExpenseCategory = comboBox1.SelectedItem?.ToString();
            DateTime ExpenseDate = dateTimePicker1.Value;

            if (string.IsNullOrEmpty(ExpenseName) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                !decimal.TryParse(textBox2.Text, out ExpenseAmount) ||
                string.IsNullOrEmpty(ExpenseCategory))
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
                    // Inserir na tabela Expenses
                    string insertExpensesQuery = "INSERT INTO Expenses (ExpenseName, ExpenseAmount, ExpenseCategory, ExpenseDate, ExpenseUser) VALUES (@ExpenseName, @ExpenseAmount, @ExpenseCategory, @ExpenseDate, @ExpenseUser)";
                    using (SqlCommand cmd = new SqlCommand(insertExpensesQuery, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ExpenseName", ExpenseName);
                        cmd.Parameters.AddWithValue("@ExpenseAmount", ExpenseAmount);
                        cmd.Parameters.AddWithValue("@ExpenseCategory", ExpenseCategory);
                        cmd.Parameters.AddWithValue("@ExpenseDate", ExpenseDate);
                        cmd.Parameters.AddWithValue("@ExpenseUser", Loginn.loginUser);
                        cmd.ExecuteNonQuery();
                    }

                    // Commitar a transação
                    transaction.Commit();
                    MessageBox.Show("Expense registrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Rollback em caso de erro
                    transaction.Rollback();
                    MessageBox.Show($"Erro ao registrar o Expense: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Expenses_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
        }
    }
}
