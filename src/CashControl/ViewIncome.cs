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
                try
                {
                    conn.Open();

                    // Selecionar todos os dados da tabela Income
                    string selectIncomeQuery = "SELECT IncomeName, IncomeAmount, IncomeCategory, IncomeDate FROM Income";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(selectIncomeQuery, conn);

                    // Criar um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Atribuir o DataTable ao DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar os dados do income: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Income incomeform = new Income();
            incomeform.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboardd = new Dashboard();
            dashboardd.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses expensess = new Expenses();
            expensess.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses ViewExpensess = new ViewExpenses();
            ViewExpensess.Show();
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
    }
}
