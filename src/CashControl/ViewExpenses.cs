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
    public partial class ViewExpenses : Form
    {
        public ViewExpenses()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            string expenseNameToDelete = dataGridView1.SelectedRows[0].Cells["ExpenseName"].Value.ToString();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Expenses WHERE ExpenseUser = @LoginUser AND ExpenseName = @ExpenseName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LoginUser", Loginn.loginUser);
                        cmd.Parameters.AddWithValue("@ExpenseName", expenseNameToDelete);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Expense deleted successfully.");
                            LoadExpenseData(); // Atualiza os dados após a exclusão
                        }
                        else
                        {
                            MessageBox.Show("Error deleting expense.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting expense: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";



        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            string oldExpenseName = dataGridView1.SelectedRows[0].Cells["ExpenseName"].Value.ToString();
            string newExpenseName = textBox2.Text;
            string newExpenseCategory = comboBoxEdit1.Text;
            string newExpenseAmount = textBox4.Text;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Expenses SET ExpenseName = @ExpenseName, ExpenseCategory = @ExpenseCategory, ExpenseAmount = @ExpenseAmount WHERE ExpenseUser = @LoginUser AND ExpenseName = @OldExpenseName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ExpenseName", newExpenseName);
                        cmd.Parameters.AddWithValue("@ExpenseCategory", newExpenseCategory);
                        cmd.Parameters.AddWithValue("@ExpenseAmount", newExpenseAmount);
                        cmd.Parameters.AddWithValue("@LoginUser", Loginn.loginUser);
                        cmd.Parameters.AddWithValue("@OldExpenseName", oldExpenseName);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Expense updated successfully.");
                            LoadExpenseData(); // Atualiza os dados após a atualização
                        }
                        else
                        {
                            MessageBox.Show("Error updating expense.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating expense: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void LoadExpenseData()
        {
            // Definir a string de conexão
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT ExpenseName, ExpenseAmount, ExpenseCategory, ExpenseDate FROM Expenses WHERE ExpenseUser = @LoginUser";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LoginUser", Loginn.loginUser);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewExpenses_Load(object sender, EventArgs e)
        {
            LoadExpenseData();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Income income = new Income();
            income.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses expenses = new Expenses();
            expenses.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewIncome incomeVIEW = new ViewIncome();
            incomeVIEW.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();

        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
