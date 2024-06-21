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
    }
}
