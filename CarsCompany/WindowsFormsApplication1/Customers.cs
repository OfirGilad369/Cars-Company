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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || maskedTextBox1.Text == "" || textBox6.Text == "" || textBox13.Text == "" || textBox14.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                    try
                    {
                        if ((maskedTextBox1.Text.Length == 10) && (long.Parse(maskedTextBox1.Text) > 0))
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "המספר לא תקין" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "המספר לא תקין" + "\n";
                        ans = false;
                    }

                    if (ans == true)
                    {
                        //try
                        //{
                        DAL x = new DAL("CarCompany.accdb");

                        string sql = "UPDATE Customers SET ID='" + textBox2.Text + "', FirstName='" + textBox3.Text + "', LastName='" + textBox4.Text + "', Cell='" + maskedTextBox1.Text + "', Email='" + textBox6.Text + "', Street='" + textBox13.Text + "', City='" + textBox14.Text + "' WHERE ID= '" + textBox2.Text + "'";
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (comboBox1.Text == "ת.ז.")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Customers where ID LIKE '" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;
            }

            if (comboBox1.Text == "שם משפחה")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Customers where LastName LIKE '" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;
            }

            if (comboBox1.Text == "עיר")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Customers where City LIKE '" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;
            }
            if ((comboBox1.Text != "ת.ז.") && (comboBox1.Text != "שם משפחה") && (comboBox1.Text != "עיר")) MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1[0, 0].Value != null)
            {
                //textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                maskedTextBox1.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox13.ReadOnly = false;
                textBox14.ReadOnly = false;


                button4.Visible = true;
                label7.Visible = false;

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
                maskedTextBox1.Text = I4;
                textBox6.Text = I5;
                textBox13.Text = I6;
                textBox14.Text = I7;
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Text = "";
            textBox6.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            
            button4.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button7.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;

            textBox6.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            
            label7.Visible = true;
            button4.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL DL = new DAL("CarCompany.accdb");

                if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || maskedTextBox2.Text == "" || textBox12.Text == "" || textBox7.Text == "" || textBox15.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {

                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                    try
                    {
                        if (int.Parse(textBox8.Text) > 999)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "תעודת הזהות של הלקוח קצרה מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "תעודת הזהות של הלקוח אינה הגיונית" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Customers where ID ='" + textBox8.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "תעודת הזהות של הלקוח כבר תפוסה" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "";

                    }

                    try
                    {
                        if ((maskedTextBox2.Text.Length == 10) && (long.Parse(maskedTextBox2.Text) > 0))
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "המספר לא תקין" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "המספר לא תקין" + "\n";
                        ans = false;
                    }

                    if (ans == true)
                    {
                        //try
                        //{
                        DataSet ds = new DataSet();


                        string sql = "INSERT INTO Customers (ID,FirstName,LastName,Cell,Email,Street,City) VALUES ('" + textBox8.Text + "','" + textBox9.Text + "', '" + textBox10.Text + "','" + maskedTextBox2.Text + "','" + textBox12.Text + "','" + textBox7.Text + "','" + textBox15.Text + "')";
                        DL.Insert(sql);

                        MessageBox.Show("ההוספה התבצעה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        //}
                        //catch
                        //{
                        MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }
    }
}
