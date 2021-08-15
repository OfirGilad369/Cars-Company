using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class Fixes : Form
    {
        public Fixes()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();

            if (comboBox1.Text == "מספר תיקון")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Fixes where FixID LIKE '" + textBox1.Text + "%' AND Stats='" + "בתהליך" + "'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;

            }

            if (comboBox1.Text == "קוד תקלה")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Fixes where FaultCode LIKE '" + textBox1.Text + "%' AND Stats='" + "בתהליך" + "'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;

            }

            if (comboBox1.Text == "קוד רכב")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Fixes where Code LIKE '" + textBox1.Text + "%' AND Stats='" + "בתהליך" + "'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;

            }

            if (comboBox1.Text == "ת.ז.")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Fixes where ID LIKE '" + textBox1.Text + "%' AND Stats='" + "בתהליך" + "'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;

            }

            if ((comboBox1.Text != "מספר תיקון") && (comboBox1.Text != "קוד תקלה") && (comboBox1.Text != "קוד רכב") && (comboBox1.Text != "ת.ז.")) MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            if (dataGridView1[0, 0].Value != null)
            {
                // textBox2.ReadOnly = false;
                maskedTextBox1.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox3.ReadOnly = false;

                int yCoord = dataGridView1.CurrentCellAddress.Y;
                string I1 = dataGridView1[0, yCoord].Value.ToString();
                string I2 = dataGridView1[1, yCoord].Value.ToString();
                string I3 = dataGridView1[2, yCoord].Value.ToString();
                string I4 = dataGridView1[3, yCoord].Value.ToString();
                string I5 = dataGridView1[4, yCoord].Value.ToString();
                string I6 = dataGridView1[5, yCoord].Value.ToString();

                textBox2.Text = I1;
                maskedTextBox1.Text = I2;
                textBox4.Text = I3;
                textBox5.Text = I4;
                textBox6.Text = I5;
                textBox3.Text = I6;

                button4.Visible = true;
                label7.Visible = false;

                

            }
            else MessageBox.Show("השורה שנבחרה אינה קיימת", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL x = new DAL("CarCompany.accdb");

                if (textBox2.Text == "" || maskedTextBox1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                    DateTime Test;
                    if (DateTime.TryParseExact(maskedTextBox1.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) != true)
                    {
                        ans = false;
                        c1 += "התאריך שגוי" + "\n";
                    }
                    else
                    {
                        DateTime d1 = DateTime.Now;
                        string d2x = maskedTextBox2.Text;
                        string d2D = d2x[0].ToString() + d2x[1].ToString();
                        string d2M = d2x[3].ToString() + d2x[4].ToString();
                        string d2Y = d2x[6].ToString() + d2x[7].ToString() + d2x[8].ToString() + d2x[9].ToString();

                        DateTime d2 = new DateTime(int.Parse(d2Y), int.Parse(d2M), int.Parse(d2D));
                        double x1 = (d2 - d1).TotalDays;

                        if (x1 >= 0)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "התאריך שהוזן צריך להיות או היום הוא עתידי ולא תאריך מוקדם יותר" + "\n";
                        }
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from TypesOfFaults where FaultCode ='" + textBox4.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
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

                        y1 = DL1.getDataTable("select * from Cars where Car_Num ='" + textBox5.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }

                    }
                    catch
                    {
                        c1 += "קוד רכב שגוי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Customers where ID ='" + textBox6.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }

                    }
                    catch
                    {
                        c1 += "תעודת הזהות של הבעלים שגויה" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Workers where WorkID ='" + textBox3.Text + "' AND Job ='טכנאי'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }

                    }
                    catch
                    {
                        c1 += "קוד עובד אינו קיים או ייתכן כי עובד זה אינו מוכר" + "\n";
                        ans = false;
                    }

                    if (ans == true)
                    {
                        //try
                        //{
                        string sql = "UPDATE Fixes SET FixID='" + textBox2.Text + "', FixDate='" + maskedTextBox1.Text + "', FaultCode='" + textBox4.Text + "', Car_Num='" + textBox5.Text + "', ID='" + textBox6.Text + "', WorkID='" + textBox3.Text + "' WHERE FixID= '" + textBox2.Text + "'";
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

                if (maskedTextBox2.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "")
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
                            c1 += "מספר תיקון קצר מדי" + "\n";
                            ans = false;
                        }

                    }
                    catch
                    {
                        c1 += "מספר תיקון שגוי" + "\n";
                        ans = false;
                    }

                    /*try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Fixes where FixID ='" + textBox8.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "מספר תיקון כבר תפוס" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "";

                    }*/

                    DateTime Test;
                    if (DateTime.TryParseExact(maskedTextBox2.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) != true)
                    {
                        ans = false;
                        c1 += "התאריך שגוי" + "\n";
                    }
                    else
                    {
                        DateTime d1 = DateTime.Now;
                        string d2x = maskedTextBox2.Text;
                        string d2D = d2x[0].ToString() + d2x[1].ToString();
                        string d2M = d2x[3].ToString() + d2x[4].ToString();
                        string d2Y = d2x[6].ToString() + d2x[7].ToString() + d2x[8].ToString() + d2x[9].ToString();

                        DateTime d2 = new DateTime(int.Parse(d2Y), int.Parse(d2M), int.Parse(d2D));
                        double x = (d2 - d1).TotalDays;

                        if (x >= 0)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "התאריך שהוזן צריך להיות או היום הוא עתידי ולא תאריך מוקדם יותר" + "\n";
                        }
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from TypesOfFaults where FaultCode ='" + textBox10.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
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

                        y1 = DL1.getDataTable("select * from Cars where Car_Num ='" + textBox11.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }

                    }
                    catch
                    {
                        c1 += "מספר רכב שגוי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Customers where ID ='" + textBox12.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }

                    }
                    catch
                    {
                        c1 += "תעודת הזהות של הבעלים שגויה" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Workers where WorkID ='" + textBox7.Text + "' AND Job ='טכנאי' AND W_Stats='רגיל'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }

                    }
                    catch
                    {
                        c1 += "קוד עובד אינו קיים או ייתכן כי עובד זה אינו מוכר" + "\n";
                        ans = false;
                    }

                    if (ans == true)
                    {
                        //try
                        //{
                        DataSet ds = new DataSet();

                        string t = DateTime.Now.ToLongTimeString().ToString();
                        string t1 = t.Replace(":", "-");
                        textBox8.Text = textBox8.Text + "_" + t1;

                        string sql = "INSERT INTO Fixes (FixID,FixDate,FaultCode,Car_Num,ID,WorkID) VALUES ('" + textBox8.Text + "','" + maskedTextBox2.Text + "', '" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox7.Text + "')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            textBox2.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox3.ReadOnly = false;

            textBox2.Text = "";
            maskedTextBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox3.Text = "";
            
            button4.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button7.Visible = false;
            
            label7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox3.ReadOnly = true;
            

            label7.Visible = true;
            button4.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
