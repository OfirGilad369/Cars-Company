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
    public partial class TypesOfFaults : Form
    {
        public TypesOfFaults()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (comboBox1.Text == "קוד תקלה")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from TypesOfFaults where FaultCode LIKE '" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;

            }
            if (comboBox1.Text != "קוד תקלה") MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            button4.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button7.Visible = false;
            label20.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1[0, 0].Value != null)
            {
                // textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;

                button4.Visible = true;
                label20.Visible = false;

                int yCoord = dataGridView1.CurrentCellAddress.Y;
                string I1 = dataGridView1[0, yCoord].Value.ToString();
                string I2 = dataGridView1[1, yCoord].Value.ToString();
                string I3 = dataGridView1[2, yCoord].Value.ToString();


                textBox2.Text = I1;
                textBox3.Text = I2;
                textBox4.Text = I3;


                button4.Visible = true;




            }
            else MessageBox.Show("השורה שנבחרה אינה קיימת", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;


            label20.Visible = true;
            button4.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL x = new DAL("CarCompany.accdb");

                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                    try
                    {
                        if (int.Parse(textBox4.Text) >= 100)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "המחיר לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "המחיר לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    if (ans == true)
                    {
                        //try
                        //{
                        string sql = "UPDATE TypesOfFaults SET FaultCode='" + textBox2.Text + "', FaultName='" + textBox3.Text + "', Cost='" + textBox4.Text + "' WHERE FaultCode= '" + textBox2.Text + "'";
                        x.Update(sql);
                        MessageBox.Show("העדכון התבצע בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }

                    else
                    {
                        //catch
                        //{
                        MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL DL = new DAL("CarCompany.accdb");

                if (textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                    try
                    {
                        if ((int.Parse(textBox10.Text) <= 9999) && (int.Parse(textBox10.Text) > 999))
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "קוד תקלה קצר מדי" + "\n";
                            ans = false;
                        }

                    }
                    catch
                    {
                        c1 += "קוד תקלה שגוי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Models where Code ='" + textBox10.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "קוד תקלה כבר תפוס" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "";

                    }

                    try
                    {
                        if (int.Parse(textBox12.Text) >= 100)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "המחיר לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "המחיר לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    if (ans == true)
                    {
                        //try
                        //{
                        DataSet ds = new DataSet();


                        string sql = "INSERT INTO TypesOfFaults (FaultCode,FaultName,Cost) VALUES ('" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "')";
                        DL.Insert(sql);

                        MessageBox.Show("ההוספה התבצעה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                    }

                    else
                    {
                        //catch
                        //{
                        MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
            }
        }
    }
}
