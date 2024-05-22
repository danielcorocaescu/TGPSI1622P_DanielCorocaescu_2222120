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
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Income incomeForm = new Income();
            incomeForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ViewIncome ViewIncomee = new ViewIncome();
            ViewIncomee.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ViewExpenses ViewExpensess = new ViewExpenses();
            ViewExpensess.Show();
        }
    }
}
