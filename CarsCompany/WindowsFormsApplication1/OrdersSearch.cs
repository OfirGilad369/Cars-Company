using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class OrdersSearch : Form
    {
        public OrdersSearch()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void OrdersSearch_Load(object sender, EventArgs e)
        {
            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from Orders where Num LIKE '%' ", y);

            dataGridView1.DataSource = y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreditPaymentSearch F1 = new CreditPaymentSearch();
            F1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckPaymentSearch F1 = new CheckPaymentSearch();
            F1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CashPaymentSearch F1 = new CashPaymentSearch();
            F1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OrderInfoSearch F1 = new OrderInfoSearch();
            F1.ShowDialog();
        }
    }
}
