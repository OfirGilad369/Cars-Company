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
    public partial class FixesSearch : Form
    {
        public FixesSearch()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from Fixes where FixID LIKE '%' ", y);

            dataGridView1.DataSource = y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FixesPaymentSearch F1 = new FixesPaymentSearch();
            F1.ShowDialog();
        }
    }
}
