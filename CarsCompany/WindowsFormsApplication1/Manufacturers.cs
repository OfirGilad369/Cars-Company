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
    public partial class Manufactorers : Form
    {
        public Manufactorers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL x = new DAL("CarCompany.accdb");

                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || maskedTextBox1.Text == "" || textBox7.Text == "" || textBox14.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    try
                    {
                        string sql = "UPDATE Manufacturers SET ManuID='" + textBox2.Text + "', Company='" + textBox3.Text + "', FirstName='" + textBox4.Text + "', LastName='" + textBox5.Text + "', Cell='" + maskedTextBox1.Text + "', Street='" + textBox7.Text + "', ManuCity='" + textBox14.Text + "' WHERE ManuID= '" + textBox2.Text + "'";
                        x.Update(sql);
                        MessageBox.Show("העדכון התבצע בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("העדכון נכשל", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (comboBox1.Text == "ת.ז.")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Manufacturers where ManuID LIKE '" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                /*ds = DL.GetDataSet("SELECT * FROM Manufacturers WHERE ManuID='" + textBox1.Text + "'");
                textBox2.Text = ds.Tables[0].Rows[0]["ManuID"].ToString();
                textBox3.Text = ds.Tables[0].Rows[0]["Company"].ToString();
                textBox4.Text = ds.Tables[0].Rows[0]["FirstName"].ToString();
                textBox5.Text = ds.Tables[0].Rows[0]["LastName"].ToString();
                textBox6.Text = ds.Tables[0].Rows[0]["Cell"].ToString();
                textBox7.Text = ds.Tables[0].Rows[0]["Street"].ToString();*/

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;
            }

            if (comboBox1.Text != "ת.ז.") MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            maskedTextBox1.Text = "";
            textBox7.Text = "";
            textBox14.Text = "";
            button4.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button7.Visible = false;
            label14.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1[0, 0].Value != null)
            {
                // textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                maskedTextBox1.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox14.ReadOnly = false;

                int yCoord = dataGridView1.CurrentCellAddress.Y;
                string I1 = dataGridView1[0, yCoord].Value.ToString();
                string I2 = dataGridView1[1, yCoord].Value.ToString();
                string I3 = dataGridView1[2, yCoord].Value.ToString();
                string I4 = dataGridView1[3, yCoord].Value.ToString();
                string I5 = dataGridView1[4, yCoord].Value.ToString();
                string I6 = dataGridView1[5, yCoord].Value.ToString();
                string I7 = dataGridView1[6, yCoord].Value.ToString();

                textBox2.Text = I1;
                textBox3.Text = I2;
                textBox4.Text = I3;
                textBox5.Text = I4;
                maskedTextBox1.Text = I5;
                textBox7.Text = I6;
                textBox14.Text = I7;

                button4.Visible = true;
                label14.Visible = false;
            }
            else MessageBox.Show("השורה שנבחרה אינה קיימת", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox14.ReadOnly = true;

            label14.Visible = true;
            button4.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL DL = new DAL("CarCompany.accdb");

                if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || maskedTextBox2.Text == "" || textBox13.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                    try
                    {
                        if ((int.Parse(textBox8.Text) <= 9999) && (int.Parse(textBox8.Text) > 999))
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "קוד יבואן קצר מדי" + "\n";
                            ans = false;
                        }

                    }
                    catch
                    {
                        c1 += "קוד יבואן שגוי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Manufacturers where ManuID ='" + textBox8.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "קוד יבואן כבר תפוס" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "";

                    }

                    if (ans == true)
                    {
                        //try
                        //{
                        string sql = "INSERT INTO Manufacturers (ManuID,Company,FirstName,LastName,Cell,Street,ManuCity) VALUES ('" + textBox8.Text + "', '" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + maskedTextBox2.Text + "','" + textBox13.Text + "','" + textBox15.Text + "')";
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
