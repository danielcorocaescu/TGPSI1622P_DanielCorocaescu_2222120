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
    public partial class ViewExpenses : Form
    {
        public ViewExpenses()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewIncome ViewIncomee = new ViewIncome();
            ViewIncomee.Show();
            this.Hide();
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

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses expensess = new Expenses();
            expensess.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadExpenses()
        {
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewExpenses_Load(object sender, EventArgs e)
        {

        }
    }
}
