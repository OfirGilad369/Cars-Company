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
    public partial class TimeListI : Form
    {
        public TimeListI()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                if ((comboBox2.Text == "") || (comboBox1.Text == "") || (int.Parse(comboBox2.Text) < 0) || (int.Parse(comboBox2.Text) > 54))
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים או שמספר השבוע אינו תקין", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    try
                    {

                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Days where Day_Name='" + comboBox1.Text + "'", y1);


                        DAL DL = new DAL("CarCompany.accdb");

                        DataTable y = new DataTable();

                        y = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "'", y);

                        try
                        {

                            if (!y.Rows[0][0].Equals(null))
                            {
                                DAL DL2 = new DAL("CarCompany.accdb");

                                DataTable y2 = new DataTable();

                                y2 = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "' AND Job='" + "מוכר" + "'", y2);

                                dataGridView1.DataSource = y2;

                                DAL DL3 = new DAL("CarCompany.accdb");

                                DataTable y3 = new DataTable();

                                y3 = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "' AND Job='" + "טכנאי" + "'", y3);

                                dataGridView2.DataSource = y3;

                                DAL DL4 = new DAL("CarCompany.accdb");

                                DataTable y4 = new DataTable();

                                y4 = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "' AND Job='" + "מזכירות" + "'", y4);

                                dataGridView3.DataSource = y4;

                                button2.Visible = true;
                                button3.Visible = true;
                                button4.Visible = true;
                                button10.Visible = true;
                                button11.Visible = true;
                                button12.Visible = true;
                                groupBox8.Visible = true;

                            }
                        }
                        catch
                        {
                            MessageBox.Show("לשדה זה אין מערכת משמרות בנויה", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("יתכן וכי מספר היום שהוכנס אינו תקין", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            int yCoord = dataGridView1.CurrentCellAddress.Y;
            textBox1.Text = dataGridView1[0, yCoord].Value.ToString();
            textBox2.Text = dataGridView1[1, yCoord].Value.ToString();
            textBox3.Text = dataGridView1[2, yCoord].Value.ToString();
            textBox4.Text = dataGridView1[3, yCoord].Value.ToString();
            button5.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button17.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            button5.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button17.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            int yCoord = dataGridView2.CurrentCellAddress.Y;
            textBox1.Text = dataGridView2[0, yCoord].Value.ToString();
            textBox2.Text = dataGridView2[1, yCoord].Value.ToString();
            textBox3.Text = dataGridView2[2, yCoord].Value.ToString();
            textBox4.Text = dataGridView2[3, yCoord].Value.ToString();
            button6.Visible = true;
            button2.Visible = false;
            button4.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button17.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            button6.Visible = false;
            button2.Visible = true;
            button4.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button17.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = true;
            int yCoord = dataGridView3.CurrentCellAddress.Y;
            textBox1.Text = dataGridView3[0, yCoord].Value.ToString();
            textBox2.Text = dataGridView3[1, yCoord].Value.ToString();
            textBox3.Text = dataGridView3[2, yCoord].Value.ToString();
            textBox4.Text = dataGridView3[3, yCoord].Value.ToString();
            button7.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button17.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox5.Visible = false;
            button7.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button17.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
            int yCoord = dataGridView1.CurrentCellAddress.Y;
            textBox5.Text = dataGridView1[0, yCoord].Value.ToString();
            textBox6.Text = dataGridView1[1, yCoord].Value.ToString();
            textBox7.Text = dataGridView1[2, yCoord].Value.ToString();
            textBox8.Text = dataGridView1[3, yCoord].Value.ToString();
            button13.Visible = true;
            button11.Visible = false;
            button12.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button17.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
            button13.Visible = false;
            button11.Visible = true;
            button12.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button17.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
            int yCoord = dataGridView2.CurrentCellAddress.Y;
            textBox5.Text = dataGridView2[0, yCoord].Value.ToString();
            textBox6.Text = dataGridView2[1, yCoord].Value.ToString();
            textBox7.Text = dataGridView2[2, yCoord].Value.ToString();
            textBox8.Text = dataGridView2[3, yCoord].Value.ToString();
            button14.Visible = true;
            button10.Visible = false;
            button12.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button17.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
            button14.Visible = false;
            button10.Visible = true;
            button12.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button17.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = true;
            int yCoord = dataGridView3.CurrentCellAddress.Y;
            textBox5.Text = dataGridView3[0, yCoord].Value.ToString();
            textBox6.Text = dataGridView3[1, yCoord].Value.ToString();
            textBox7.Text = dataGridView3[2, yCoord].Value.ToString();
            textBox8.Text = dataGridView3[3, yCoord].Value.ToString();
            button15.Visible = true;
            button10.Visible = false;
            button11.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button17.Visible = false;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            groupBox6.Visible = false;
            button15.Visible = false;
            button10.Visible = true;
            button11.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button17.Visible = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            groupBox7.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button18.Visible = true;
            textBox11.Text = dataGridView1[0, 1].Value.ToString();
            textBox12.Text = dataGridView1[0, 2].Value.ToString();


        }

        private void button18_Click(object sender, EventArgs e)
        {
            groupBox7.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button18.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from Workers where WorkID='" + textBox9.Text + "' AND Job='" + textBox4.Text + "'", y);

            try
            {

                if (!y.Rows[0][0].Equals(null))
                {
                    DAL x = new DAL("CarCompany.accdb");
                    string sql = "UPDATE TimeList SET WorkID='" + textBox9.Text + "'WHERE D_Num='" + textBox2.Text + "'AND TL_Week='" + textBox3.Text + "'AND Job='" + textBox4.Text + "'AND WorkID= '" + textBox1.Text + "'";
                    x.Update(sql);

                    MessageBox.Show("העדכון התבצע בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox5.Visible = false;

                    //

                    DAL DL1 = new DAL("CarCompany.accdb");

                    DataTable y1 = new DataTable();

                    y1 = DL1.getDataTable("select * from Days where Day_Name='" + comboBox1.Text + "'", y1);


                    DAL DLx = new DAL("CarCompany.accdb");

                    DataTable yx = new DataTable();

                    yx = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "'", yx);



                    if (!y.Rows[0][0].Equals(null))
                    {
                        DAL DL2 = new DAL("CarCompany.accdb");

                        DataTable y2 = new DataTable();

                        y2 = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "' AND Job='" + "מוכר" + "'", y2);

                        dataGridView1.DataSource = y2;

                        DAL DL3 = new DAL("CarCompany.accdb");

                        DataTable y3 = new DataTable();

                        y3 = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "' AND Job='" + "טכנאי" + "'", y3);

                        dataGridView2.DataSource = y3;

                        DAL DL4 = new DAL("CarCompany.accdb");

                        DataTable y4 = new DataTable();

                        y4 = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "' AND Job='" + "מזכירות" + "'", y4);

                        dataGridView3.DataSource = y4;

                        button2.Visible = true;
                        button3.Visible = true;
                        button4.Visible = true;
                        button5.Visible = false;
                        button6.Visible = false;
                        button7.Visible = false;
                        button10.Visible = true;
                        button11.Visible = true;
                        button12.Visible = true;
                        groupBox8.Visible = true;

                    }
                }
            }
            catch
            {
                MessageBox.Show("העדכון נכשל עקב ת.ז. שגוייה של העובד החדש. יתכן כי עובד חדש זה אינו קיים במערכת, אינו תואם לעבודה שתחתיה הוא מוכנס או כי הוא כבר עובד ביום זה", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bool ans = false;

            if (button10.Visible == true)
            {
                if (dataGridView1[1, 1].Value != null)
                {
                    ans = true;
                }
            }

            if (button11.Visible == true)
            {
                if (dataGridView2[1, 1].Value != null)
                {
                    ans = true;
                }
            }

            if (button12.Visible == true)
            {
                if (dataGridView3[1, 1].Value != null)
                {
                    ans = true;
                }
            }

            if (ans == true)
            {
                DAL DL1z = new DAL("CarCompany.accdb");
                string sql1z = "DELETE from TimeList WHERE WorkID='" + textBox5.Text + "'AND D_Num='" + textBox6.Text + "'AND TL_Week='" + textBox7.Text + "'AND Job='" + textBox8.Text + "'";
                DL1z.Delete(sql1z);

                //

                DAL DL1 = new DAL("CarCompany.accdb");

                DataTable y1 = new DataTable();

                y1 = DL1.getDataTable("select * from Days where Day_Name='" + comboBox1.Text + "'", y1);


                DAL DLx = new DAL("CarCompany.accdb");

                DataTable yx = new DataTable();

                yx = DLx.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "'", yx);

                DAL DL2 = new DAL("CarCompany.accdb");

                DataTable y2 = new DataTable();

                y2 = DL2.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "' AND Job='" + "מוכר" + "'", y2);

                dataGridView1.DataSource = y2;

                DAL DL3 = new DAL("CarCompany.accdb");

                DataTable y3 = new DataTable();

                y3 = DL3.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "' AND Job='" + "טכנאי" + "'", y3);

                dataGridView2.DataSource = y3;

                DAL DL4 = new DAL("CarCompany.accdb");

                DataTable y4 = new DataTable();

                y4 = DL4.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox2.Text + "' AND Job='" + "מזכירות" + "'", y4);

                dataGridView3.DataSource = y4;

                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button13.Visible = false;
                button14.Visible = false;
                button15.Visible = false;
                button10.Visible = true;
                button11.Visible = true;
                button12.Visible = true;

                groupBox6.Visible = false;
            }
            else
            {
                MessageBox.Show("המחיקה נכשלה כי יתכן ואם עובד זה ימחק למערכת אין אפשרות להשאיר שדה כלשהו של עובדים ריק", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            WorkersSearch WS = new WorkersSearch();
            WS.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                DAL DL = new DAL("CarCompany.accdb");
                string sql = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox10.Text + "', '" + textBox11.Text + "','" + textBox12.Text + "','" + comboBox3.Text + "')";
                DL.Insert(sql);
                MessageBox.Show("ההוספה בוצעה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("הנתונים שהוכנסו בשדה: ת.ז. ועבודה אינם תואמים", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
