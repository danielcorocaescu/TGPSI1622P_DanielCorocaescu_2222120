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
    public partial class ViewIncome : Form
    {
        public ViewIncome()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.ViewIncome_Load); // Associar o evento Load do formulário
        }

        private void ViewIncome_Load(object sender, EventArgs e)
        {
            LoadIncomeData();
        }


        private void LoadIncomeData()
        {
            // Definir a string de conexão
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT IncomeName, IncomeAmount, IncomeCategory, IncomeDate FROM Income WHERE IncomeUser = @LoginUser";

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

        private void label2_Click(object sender, EventArgs e)
        {
            Income incomeform = new Income();
            incomeform.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboardd = new Dashboard();
            dashboardd.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses expensess = new Expenses();
            expensess.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses ViewExpensess = new ViewExpenses();
            ViewExpensess.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void ViewIncome_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            string oldIncomeName = dataGridView1.SelectedRows[0].Cells["IncomeName"].Value.ToString();
            string newIncomeName = textBox2.Text;
            string newIncomeCategory = comboBoxEdit1.Text;
            string newIncomeAmount = textBox4.Text;

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Income SET IncomeName = @IncomeName, IncomeCategory = @IncomeCategory, IncomeAmount = @IncomeAmount WHERE IncomeUser = @LoginUser AND IncomeName = @OldIncomeName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IncomeName", newIncomeName);
                        cmd.Parameters.AddWithValue("@IncomeCategory", newIncomeCategory);
                        cmd.Parameters.AddWithValue("@IncomeAmount", newIncomeAmount);
                        cmd.Parameters.AddWithValue("@LoginUser", Loginn.loginUser);
                        cmd.Parameters.AddWithValue("@OldIncomeName", oldIncomeName);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Income updated successfully.");
                            LoadIncomeData(); // Atualiza os dados após a atualização
                        }
                        else
                        {
                            MessageBox.Show("Error updating income.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating income: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            string IncomeNameToDelete = dataGridView1.SelectedRows[0].Cells["IncomeName"].Value.ToString();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CashControl;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Income WHERE IncomeUser = @LoginUser AND IncomeName = @IncomeName";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@LoginUser", Loginn.loginUser);
                        cmd.Parameters.AddWithValue("@IncomeName", IncomeNameToDelete);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Income deleted successfully.");
                            LoadIncomeData(); // Atualiza os dados após a exclusão
                        }
                        else
                        {
                            MessageBox.Show("Error deleting income.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting income: " + ex.Message + "\n" + ex.StackTrace);
                }
            }
        }
    }
}
