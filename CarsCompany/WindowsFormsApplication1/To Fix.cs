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
    public partial class ToFix : Form
    {
        public ToFix()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int yCoord = dataGridView1.CurrentCellAddress.Y;
            string I1 = dataGridView1[0, yCoord].Value.ToString();
            FixPayments G = new FixPayments();
            G.GetFixID(I1);
            G.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ans = true;
            string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

            try
            {
                DAL DL1 = new DAL("CarCompany.accdb");

                DataTable y1 = new DataTable();

                y1 = DL1.getDataTable("select * from Fixes where Car_Num ='" + textBox1.Text + "' AND Stats='" + "בתהליך" + "'", y1);

                if (!y1.Rows[0].Equals(null))
                {
                    c1 += "";
                }
            }
            catch
            {
                ans = false;
                c1 += "רכב זה אינו נמצא בתיקון";
            }

            if (ans == true)
            {
                textBox1.ReadOnly = true;
                button4.Visible = true;
                label5.Visible = true;
                button3.Visible = true;
                

                DAL DL3 = new DAL("CarCompany.accdb");

                DataTable y3 = new DataTable();

                y3 = DL3.getDataTable("select * from Fixes where Car_Num ='" + textBox1.Text + "'", y3);


                DAL DL3x = new DAL("CarCompany.accdb");

                DataTable y3x = new DataTable();

                y3x = DL3x.getDataTable("select * from Cars where Car_Num ='" + textBox1.Text + "'", y3x);


                textBox2.Text = y3.Rows[0][4].ToString();
                textBox3.Text = y3x.Rows[0][0].ToString();
                textBox4.Text = y3x.Rows[0][1].ToString();

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Fixes where Car_Num='" + textBox1.Text + "'", y);

                dataGridView1.DataSource = y;

            }
            else
            {
                MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            button3.Visible = false;
            dataGridView1.Columns.Clear();
            label5.Visible = false;

        }

    }
}
