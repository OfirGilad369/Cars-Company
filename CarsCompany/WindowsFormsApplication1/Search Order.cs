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
    public partial class SearchOrder : Form
    {
        public SearchOrder()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ans = true;
            string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

            try
            {
                DAL DL1 = new DAL("CarCompany.accdb");

                DataTable y1 = new DataTable();

                y1 = DL1.getDataTable("select * from OrderInfo where Num ='" + textBox2.Text + "'", y1);

                if (!y1.Rows[0].Equals(null))
                {
                    c1 += "";
                }

                if (y1.Rows[0][1].Equals("בוטלה"))
                {
                    ans = false;
                    c1 += "ההזמנה בוטלה";
                }
                if (y1.Rows[0][1].Equals("סופקה"))
                {
                    ans = false;
                    c1 += "ההזמנה סופקה";
                }

            }
            catch
            {
                ans = false;
                c1 += "מספר הזמנה לא קיים";

            }

            if (ans == true)
            {
                DAL DL3 = new DAL("CarCompany.accdb");

                DataTable y3 = new DataTable();

                y3 = DL3.getDataTable("select * from OrderInfo where Num ='" + textBox2.Text + "'", y3);

                groupBox2.Visible = true;
                textBox3.Text = y3.Rows[0][0].ToString();
                textBox4.Text = y3.Rows[0][1].ToString();
            }
            else
            {
                MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "מקדמה")
            {
                Mikdama M = new Mikdama();
                M.GetNum(textBox3.Text);
                M.ShowDialog();
            }
            if (textBox4.Text == "תשלומים")
            {
                Payments P = new Payments();
                P.GetNum(textBox3.Text);
                P.ShowDialog();
            }
            if (textBox4.Text == "הספקה")
            {
                Supply S = new Supply();
                S.GetNum(textBox3.Text);
                S.ShowDialog();

                if (S.DialogResult == DialogResult.OK)
                {
                    Close();
                }
                else
                {
                    //
                } 

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Orders O = new Orders();
            O.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowOrder SO = new ShowOrder();
            SO.ShowDialog();
        }
    }
}
