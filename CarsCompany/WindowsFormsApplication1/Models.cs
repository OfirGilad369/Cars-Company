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
    public partial class Models : Form
    {
        public Models()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1[0, 0].Value != null)
            {
                // textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                // textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox18.ReadOnly = false;
                button4.Visible = true;
                label20.Visible = false;

                int yCoord = dataGridView1.CurrentCellAddress.Y;
                string Code = dataGridView1[0, yCoord].Value.ToString();
                string ModelName = dataGridView1[1, yCoord].Value.ToString();
                string Price = dataGridView1[2, yCoord].Value.ToString();
                string Engine = dataGridView1[3, yCoord].Value.ToString();
                string Auto = dataGridView1[4, yCoord].Value.ToString();
                string Trunk = dataGridView1[5, yCoord].Value.ToString();
                string Cylinders = dataGridView1[6, yCoord].Value.ToString();
                string ManuID = dataGridView1[7, yCoord].Value.ToString();
                string Stock = dataGridView1[8, yCoord].Value.ToString();
                textBox2.Text = Code;
                textBox3.Text = ModelName;
                textBox4.Text = Price;
                textBox5.Text = Engine;
                textBox7.Text = Auto;
                if (Auto == "True")
                {
                    checkBox1.Checked = true;
                }
                else checkBox1.Checked = false;
                textBox7.Text = Trunk;
                textBox8.Text = Cylinders;
                textBox9.Text = ManuID;
                textBox18.Text = Stock;
            }
            else MessageBox.Show("השורה שנבחרה אינה קיימת", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
    
            if (comboBox1.Text == "קוד")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Models where Code LIKE '" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                /*ds = DL.GetDataSet("SELECT * FROM Models WHERE Code='" + textBox1.Text + "'");
                textBox2.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                textBox3.Text = ds.Tables[0].Rows[0]["ModelName"].ToString();
                textBox4.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                textBox5.Text = ds.Tables[0].Rows[0]["Engine"].ToString();
                string Auto = ds.Tables[0].Rows[0]["Automat"].ToString();
                if (Auto == "True")
                {
                    checkBox1.Checked = true;
                }
                else checkBox1.Checked = false;
                textBox7.Text = ds.Tables[0].Rows[0]["Trunk"].ToString();
                textBox8.Text = ds.Tables[0].Rows[0]["Cylinders"].ToString();
                textBox9.Text = ds.Tables[0].Rows[0]["ManuID"].ToString();
                textBox18.Text = ds.Tables[0].Rows[0]["Stock"].ToString(); */
                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;
            }

            if (comboBox1.Text == "שם מודל")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Models where ModelName LIKE '" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                /*ds = DL.GetDataSet("SELECT * FROM Models WHERE Code='" + textBox1.Text + "'");
                textBox2.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                textBox3.Text = ds.Tables[0].Rows[0]["ModelName"].ToString();
                textBox4.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                textBox5.Text = ds.Tables[0].Rows[0]["Engine"].ToString();
                string Auto = ds.Tables[0].Rows[0]["Automat"].ToString();
                if (Auto == "True")
                {
                    checkBox1.Checked = true;
                }
                else checkBox1.Checked = false;
                textBox7.Text = ds.Tables[0].Rows[0]["Trunk"].ToString();
                textBox8.Text = ds.Tables[0].Rows[0]["Cylinders"].ToString();
                textBox9.Text = ds.Tables[0].Rows[0]["ManuID"].ToString();
                textBox18.Text = ds.Tables[0].Rows[0]["Stock"].ToString();*/
                button2.Visible = true;
                button3.Visible = true;
                button7.Visible = true;
            }

            if ((comboBox1.Text != "קוד") && (comboBox1.Text != "שם מודל"))
            {
                MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox18.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";


                    /*try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Models where ModelName ='" + textBox3.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "שם מודל כבר תפוס" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "";
                        
                    }*/

                    try
                    {
                        if (int.Parse(textBox4.Text) >= 10000)
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

                    try
                    {
                        if (int.Parse(textBox5.Text) >= 1)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "נפח מנוע לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "נפח מנוע לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        if (int.Parse(textBox7.Text) >= 0)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "נפח תא מטען לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "נפח תא מטען לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        if (int.Parse(textBox8.Text) >= 1)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "מספר צילינדרים לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "מספר צילינדרים לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Manufacturers where ManuID ='" + textBox9.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }
                    }
                    catch
                    {
                        c1 += "קוד יבואן שגוי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        if (int.Parse(textBox9.Text) >= 0)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "מספר מלאי לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "מספר מלאי לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    if (ans == true)
                    {

                        //try
                        //{
                        DAL x = new DAL("CarCompany.accdb");
                        if (checkBox1.Checked == true)
                        {
                            string sql1 = "UPDATE Models SET Automat = 1 WHERE Code= '" + textBox2.Text + "'";
                            x.Update(sql1);
                        }
                        else
                        {
                            string sql2 = "UPDATE Models SET Automat = 0 WHERE Code= '" + textBox2.Text + "'";
                            x.Update(sql2);
                        }

                        string sql = "UPDATE Models SET Code='" + textBox2.Text + "', ModelName='" + textBox3.Text + "', Price='" + int.Parse(textBox4.Text) + "', Engine='" + int.Parse(textBox5.Text) + "', Trunk='" + int.Parse(textBox7.Text) + "', Cylinders='" + int.Parse(textBox8.Text) + "', ManuID='" + textBox9.Text + "', Stock='" + int.Parse(textBox18.Text) + "' WHERE Code= '" + textBox2.Text + "'";
                        x.Update(sql);
                        MessageBox.Show("העדכון התבצע בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox18.ReadOnly = true;
            label20.Visible = true;
            button4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            checkBox1.Checked = false;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox18.ReadOnly = true;
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox18.Text = "";
            button4.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button7.Visible = false;
            label20.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL DL = new DAL("CarCompany.accdb");

                if (textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "" || textBox19.Text == "")
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
                            c1 += "קוד רכב שגוי" + "\n";
                            ans = false;
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

                        y1 = DL1.getDataTable("select * from Models where Code ='" + textBox10.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "קוד מודל כבר תפוס" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "";

                    }

                    try
                    {
                        if (int.Parse(textBox12.Text) >= 10000)
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

                    try
                    {
                        if (int.Parse(textBox13.Text) >= 1)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "נפח מנוע לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "נפח מנוע לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        if (int.Parse(textBox15.Text) >= 0)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "נפח תא מטען לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "נפח תא מטען לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        if (int.Parse(textBox16.Text) >= 1)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "מספר צילינדרים לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "מספר צילינדרים לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Manufacturers where ManuID ='" + textBox17.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }
                    }
                    catch
                    {
                        c1 += "קוד יבואן שגוי" + "\n";
                        ans = false;
                    }

                    try
                    {
                        if (int.Parse(textBox19.Text) >= 0)
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "מספר מלאי לא הגיוני או שהוא נמוך מדי" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "מספר מלאי לא הגיוני או שהוא נמוך מדי" + "\n";
                        ans = false;
                    }

                    if (ans == true)
                    {
                        //try
                        //{
                        string sql = "INSERT INTO Models (Code,ModelName,Price,Engine,Trunk,Cylinders,ManuID, Stock) VALUES ('" + textBox10.Text + "', '" + textBox11.Text + "','" + int.Parse(textBox12.Text) + "','" + int.Parse(textBox13.Text) + "','" + int.Parse(textBox15.Text) + "','" + int.Parse(textBox16.Text) + "','" + textBox17.Text + "','" + int.Parse(textBox19.Text) + "')";
                        DL.Insert(sql);
                        if (checkBox2.Checked == true)
                        {
                            string sql1 = "UPDATE Models SET Automat = 1 WHERE Code= '" + textBox10.Text + "'";
                            DL.Update(sql1);
                        }
                        else
                        {
                            string sql2 = "UPDATE Models SET Automat = 0 WHERE Code= '" + textBox10.Text + "'";
                            DL.Update(sql2);
                        }
                        MessageBox.Show("ההוספה התבצעה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    //catch
                    {
                        MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManufacturersSearch MS = new ManufacturersSearch();
            MS.ShowDialog();
        }
    }
}
