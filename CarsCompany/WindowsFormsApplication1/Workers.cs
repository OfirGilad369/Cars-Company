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
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || maskedTextBox1.Text == "" || textBox6.Text == "" || textBox13.Text == "" || textBox14.Text == "" || comboBox2.Text == "" || maskedTextBox3.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                    try
                    {
                        if (maskedTextBox1.Text.Length == 14)
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

                    DAL DL1 = new DAL("CarCompany.accdb");

                    DataTable y1 = new DataTable();

                    y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox2.Text + "'", y1);

                    bool ansJ = false;

                    if (comboBox2.Text != y1.Rows[0][7].ToString())
                    {
                        ansJ = true;
                    }

                    if (ansJ == true)
                    {
                        DialogResult dr1 = MessageBox.Show("יתכן כי ימחקו המשמרות של העובד כתוצאה משינוי תפקידו. האם ברצונך בכל זאת לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (dr1 == DialogResult.OK)
                        {

                            if (ans == true)
                            {
                                //try
                                //{

                                DAL DL = new DAL("CarCompany.accdb");

                                DataTable y = new DataTable();

                                y = DL.getDataTable("select * from Workers where WorkID ='" + textBox2.Text + "'", y);

                                if (y.Rows[0][7].ToString() != comboBox2.Text)
                                {
                                    DAL DL1z = new DAL("CarCompany.accdb");
                                    string sql1z = "DELETE from TimeList WHERE WorkID='" + textBox2.Text + "'";
                                    DL1z.Delete(sql1z);
                                }



                                DAL x = new DAL("CarCompany.accdb");

                                string sql = "UPDATE Workers SET WorkID='" + textBox2.Text + "', W_FN='" + textBox3.Text + "', W_LN='" + textBox4.Text + "', W_Cell='" + maskedTextBox1.Text + "', W_Email='" + textBox6.Text + "', W_Street='" + textBox13.Text + "', W_City='" + textBox14.Text + "', Job='" + comboBox2.Text + "', W_Start='" + maskedTextBox3.Text + "' WHERE WorkID= '" + textBox2.Text + "'";
                                x.Update(sql);
                                MessageBox.Show("העדכון התבצע בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}
                                try
                                {
                                    string sql0 = "DELETE from TimeList WHERE WorkID='" + textBox2.Text + "'";
                                    x.Delete(sql0);
                                }
                                catch
                                {
                                    //
                                }

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
                    else
                    {
                        if (ans == true)
                        {
                            //try
                            //{
                            DAL x = new DAL("CarCompany.accdb");

                            string sql = "UPDATE Workers SET WorkID='" + textBox2.Text + "', W_FN='" + textBox3.Text + "', W_LN='" + textBox4.Text + "', W_Cell='" + maskedTextBox1.Text + "', W_Email='" + textBox6.Text + "', W_Street='" + textBox13.Text + "', W_City='" + textBox14.Text + "', Job='" + comboBox2.Text + "', W_Start='" + maskedTextBox3.Text + "' WHERE WorkID= '" + textBox2.Text + "'";
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            if (comboBox1.Text == "ת.ז.")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Workers where WorkID LIKE '" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;
            }

            if (comboBox1.Text == "שם משפחה")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Workers where W_LN LIKE '" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;
            }

            if (comboBox1.Text == "עיר")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Workers where W_City LIKE '" + textBox1.Text + "%'", y);

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
                maskedTextBox3.ReadOnly = false;

                button4.Visible = true;
                button5.Visible = true;
                label7.Visible = false;

                int yCoord = dataGridView1.CurrentCellAddress.Y;
                string I1 = dataGridView1[0, yCoord].Value.ToString();
                string I2 = dataGridView1[1, yCoord].Value.ToString();
                string I3 = dataGridView1[2, yCoord].Value.ToString();
                string I4 = dataGridView1[3, yCoord].Value.ToString();
                string I5 = dataGridView1[4, yCoord].Value.ToString();
                string I6 = dataGridView1[5, yCoord].Value.ToString();
                string I7 = dataGridView1[6, yCoord].Value.ToString();
                string I8 = dataGridView1[7, yCoord].Value.ToString();
                string I9 = dataGridView1[8, yCoord].Value.ToString();

                textBox2.Text = I1;
                textBox3.Text = I2;
                textBox4.Text = I3;
                maskedTextBox1.Text = I4;
                textBox6.Text = I5;
                textBox13.Text = I6;
                textBox14.Text = I7;
                comboBox2.Text = I8;
                maskedTextBox3.Text = I9;
            }
        } 

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            //textBox5.ReadOnly = true;
            maskedTextBox3.ReadOnly = true;

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            maskedTextBox1.Text = "";
            textBox6.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            comboBox2.Text = "";
            maskedTextBox3.Text = "";

            button4.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button7.Visible = false;
            button5.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox3.ReadOnly = true;

            textBox6.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            //textBox5.ReadOnly = true;

            label7.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL DL = new DAL("CarCompany.accdb");

                if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || maskedTextBox2.Text == "" || textBox12.Text == "" || textBox7.Text == "" || textBox15.Text == "" || comboBox3.Text == "" || maskedTextBox4.Text == "")
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
                            c1 += "תעודת הזהות של העובד קצרה מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "תעודת הזהות של העובד אינה הגיונית" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Workers where WorkID ='" + textBox8.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "תעודת הזהות של העובד כבר תפוסה" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "";

                    }

                    try
                    {
                        if (maskedTextBox2.Text.Length == 14)
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


                        string sql = "INSERT INTO Workers (WorkID,W_FN,W_LN,W_Cell,W_Email,W_Street,W_City,Job,W_Start,W_Stats) VALUES ('" + textBox8.Text + "','" + textBox9.Text + "', '" + textBox10.Text + "','" + maskedTextBox2.Text + "','" + textBox12.Text + "','" + textBox7.Text + "','" + textBox15.Text + "','" + comboBox3.Text + "','" + maskedTextBox4.Text + "','" + "רגיל" + "')";
                        DL.Insert(sql);

                        MessageBox.Show("ההוספה התבצעה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        MessageBox.Show("עובד זה אומנם הוכנבס למערכת אך אין לא גישה לתוכנה מאחר ולא נבנתה לו סיסמא למערכת. נא כנס לטופס סיסמאות העובדים כדי ליצור לעובד סיסמא לאפשרות גישה למערכת", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void button5_Click(object sender, EventArgs e)
        {
            FireWorker G = new FireWorker();
            G.GetWorkID(textBox2.Text);
            G.ShowDialog();
        }
    }
}
