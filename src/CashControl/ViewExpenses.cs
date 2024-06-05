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

        private void label4_Click(object sender, EventArgs e)
        {
            ViewIncome ViewIncomee = new ViewIncome();
            ViewIncomee.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard dashboardd = new Dashboard();
            dashboardd.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Income incomeForm = new Income();
            incomeForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Expenses expensess = new Expenses();
            expensess.Show();
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
    }
}
