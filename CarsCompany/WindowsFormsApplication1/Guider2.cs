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
    public partial class Guider2 : Form
    {
        public Guider2()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Guider2_Load(object sender, EventArgs e)
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
            TimeListII TL = new TimeListII();
            TL.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Workers TL = new Workers();
            TL.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FixesSearch TL = new FixesSearch();
            TL.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            OrdersSearch TL = new OrdersSearch();
            TL.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Manufactorers TL = new Manufactorers();
            TL.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Customers TL = new Customers();
            TL.ShowDialog();
        }
    }
}
