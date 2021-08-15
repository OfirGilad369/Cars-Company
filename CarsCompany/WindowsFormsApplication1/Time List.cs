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
    public partial class TimeList : Form
    {
        public TimeList()
        {
            InitializeComponent();
        }

        /*private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;

            button3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text == "") || (textBox10.Text == ""))
            {
                MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool ansX = false;
                bool ans = true;
                string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                try
                {
                    DAL DL1 = new DAL("CarCompany.accdb");

                    DataTable y1 = new DataTable();

                    y1 = DL1.getDataTable("select * from TimeList where D_Num ='" + comboBox1.Text + "' AND TL_Week ='" + textBox10.Text + "'", y1);

                    if (!y1.Rows[0].Equals(null))
                    {
                        c1 += "";
                    }
                }
                catch
                {
                    c1 += "לא קיימת מערכת שעות עבור יום זה" + "\n";
                    ans = false;
                    ansX = true;
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }*/
    }
}
