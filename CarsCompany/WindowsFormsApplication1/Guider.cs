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
    public partial class Guider : Form
    {
        public Guider()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manufactorers G = new Manufactorers();
            G.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Models G = new Models();
            G.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fixes G = new Fixes();
            G.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Orders G = new Orders();
            G.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Customers G = new Customers();
            G.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Accessories G = new Accessories();
            G.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AccessoriesOrders G = new AccessoriesOrders();
            G.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TypesOfFaults G = new TypesOfFaults();
            G.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Models G = new Models();
            G.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Manufactorers G = new Manufactorers();
            G.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Fixes G = new Fixes();
            G.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SearchOrder G = new SearchOrder();
            G.ShowDialog();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Customers G = new Customers();
            G.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Accessories G = new Accessories();
            G.ShowDialog();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            AccessoriesOrders G = new AccessoriesOrders();
            G.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            TypesOfFaults G = new TypesOfFaults();
            G.ShowDialog();
        }

        private void toolStripSeparator8_Click(object sender, EventArgs e)
        {

        }

        private string x;

        public void GetID(string x1)
        {
            this.x = x1;
        }

        private void Guider_Load(object sender, EventArgs e)
        { 
            toolStripLabel2.Text += x;

            DAL DL1 = new DAL("CarCompany.accdb");

            DataTable y1 = new DataTable();

            y1 = DL1.getDataTable("select * from Workers where WorkID='" + x + "'", y1);

            toolStripLabel1.Text += y1.Rows[0][1].ToString();


        }

    }
}
