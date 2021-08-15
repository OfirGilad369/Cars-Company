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
    public partial class OrderInfoSearch : Form
    {
        public OrderInfoSearch()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from OrderInfo where Num LIKE '%' ", y);

            dataGridView1.DataSource = y;
        }
    }
}
