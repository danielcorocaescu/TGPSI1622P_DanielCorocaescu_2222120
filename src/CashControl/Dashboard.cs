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
using Microsoft.Data.SqlClient;

namespace CashControl
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Income IncomeForm = new Income();
            IncomeForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses ExpensesForm = new Expenses();
            ExpensesForm.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewIncome ViewIncomeForm = new ViewIncome();
            ViewIncomeForm.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses viewExpenses = new ViewExpenses();
            viewExpenses.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string git = "https://github.com/danielcorocaescu";
            Process.Start(new ProcessStartInfo { FileName = git, UseShellExecute = true });
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string rev = "https://revolut.me/iulianwn4y";
            Process.Start(new ProcessStartInfo { FileName = rev, UseShellExecute = true });
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string paypal = "https://paypal.me/Jxckdc";
            Process.Start(new ProcessStartInfo { FileName = paypal, UseShellExecute = true });
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

        private void DisplayTotalIncome()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT SUM(IncomeAmount) FROM Income WHERE IncomeUser = @IncomeUser";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@IncomeUser", Loginn.loginUser);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalIncome = Convert.ToDecimal(result);
                        label8.Text = $"{totalIncome:F2}€";
                    }
                    else
                    {
                        label8.Text = "0€";
                    }
                }
                catch (Exception ex)
                {
                    label9.Text = "Error retrieving income";
                    MessageBox.Show("Error retrieving total income: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void DisplayTotalExpenses()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT SUM(ExpenseAmount) FROM Expenses WHERE ExpenseUser = @ExpenseUser";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@ExpenseUser", Loginn.loginUser);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalExpense = Convert.ToDecimal(result);
                        label11.Text = $"{totalExpense:F2}€";
                    }
                    else
                    {
                        label11.Text = "0€";
                    }
                }
                catch (Exception ex)
                {
                    label11.Text = "Error retrieving expenses";
                    MessageBox.Show("Error retrieving total expenses: " + ex.Message);
                }
            }
        }

        private void DisplayTransactionCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Income WHERE IncomeUser = @IncomeUser";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@IncomeUser", Loginn.loginUser);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int transactionCount = Convert.ToInt32(result);
                        label9.Text = $"{transactionCount}";
                    }
                    else
                    {
                        label9.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    label8.Text = "Error retrieving transactions";
                    MessageBox.Show("Error retrieving total transactions: " + ex.Message);
                }
            }
        }

        private void DisplayTransactionExpenseCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Expenses WHERE ExpenseUser = @ExpenseUser";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@ExpenseUser", Loginn.loginUser);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int transactionCountExpense = Convert.ToInt32(result);
                        label10.Text = $"{transactionCountExpense}";
                    }
                    else
                    {
                        label10.Text = "0";
                    }
                }
                catch (Exception ex)
                {
                    label10.Text = "Error retrieving transactions";
                    MessageBox.Show("Error retrieving total transactions: " + ex.Message);
                }
            }
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            DisplayTotalIncome();
            DisplayTotalExpenses();
            DisplayTransactionCount();
            DisplayTransactionExpenseCount();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
        }
    }
}
