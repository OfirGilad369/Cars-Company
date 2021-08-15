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
    public partial class Guider1 : Form
    {
        public Guider1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Guider1_Load(object sender, EventArgs e)
        {
            toolStripLabel2.Text += x;

            DAL DL1 = new DAL("CarCompany.accdb");

            DataTable y1 = new DataTable();

            y1 = DL1.getDataTable("select * from Workers where WorkID='" + x + "'", y1);

            toolStripLabel1.Text += y1.Rows[0][1].ToString();
        }

        private string x;

        public void GetID(string x1)
        {
            this.x = x1;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Models M = new Models();
            M.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Manufactorers M = new Manufactorers();
            M.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Orders M = new Orders();
            M.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SearchOrder M = new SearchOrder();
            M.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Accessories M = new Accessories();
            M.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Customers M = new Customers();
            M.ShowDialog();
        }
    }
}
