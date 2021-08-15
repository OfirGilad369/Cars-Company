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
    public partial class Guider3 : Form
    {
        public Guider3()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Guider3_Load(object sender, EventArgs e)
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
            Fixes F = new Fixes();
            F.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TypesOfFaults F = new TypesOfFaults();
            F.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Customers F = new Customers();
            F.ShowDialog();
        }
    }
}
