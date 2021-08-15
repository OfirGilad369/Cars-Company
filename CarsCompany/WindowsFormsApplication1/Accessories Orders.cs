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
    public partial class AccessoriesOrders : Form
    {
        public AccessoriesOrders()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from AccessoriesOrders where Num ='" + textBox1.Text + "'", y);

            dataGridView1.DataSource = y;

            button2.Visible = true;

            if (dataGridView1[0, 0].Value != null)
            {
                groupBox2.Visible = true;
            }
           
        }

        
        
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            groupBox2.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL DL = new DAL("CarCompany.accdb");

                if (textBox8.Text == "" || textBox9.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {

                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Accessories where AccessCode ='" + textBox9.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";

                        }
                    }
                    catch
                    {
                        c1 += "קוד אביזר אינו קיים" + "\n";
                        ans = false;
                    }

                    try
                    {
                        DAL DL2 = new DAL("CarCompany.accdb");

                        DataTable y2 = new DataTable();

                        y2 = DL2.getDataTable("select * from AccessoriesOrders where AccessCode ='" + textBox9.Text + "' AND Num ='" + textBox1.Text + "'", y2);

                        if (!y2.Rows[0].Equals(null))
                        {
                            ans = false;
                            c1 += "קוד אביזר זה כבר קיים בהזמנה זו" + "\n";
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
                        


                        string sql = "INSERT INTO AccessoriesOrders (Num,AccessCode) VALUES ('" + textBox8.Text + "','" + textBox9.Text  + "')";
                        DL.Insert(sql);

                        MessageBox.Show("ההוספה התבצעה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                        DataSet ds = new DataSet();

                        DAL DL1x = new DAL("CarCompany.accdb");

                        DataTable y1x = new DataTable();

                        y1x = DL1x.getDataTable("select * from AccessoriesOrders where Num ='" + textBox1.Text + "'", y1x);

                        dataGridView1.DataSource = y1x;

                        button2.Visible = true;

                        if (dataGridView1[0, 0].Value != null)
                        {
                            groupBox2.Visible = true;
                        }
                    }

                    else
                    {
                        //catch
                        //{
                        MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Accessories A = new Accessories();
            A.ShowDialog();
        }

        private string w;

        public void GetNum(string w1)
        {
            this.w = w1;
        }

        private void AccessoriesOrders_Load(object sender, EventArgs e)
        {
            textBox1.Text = w;
            textBox8.Text = w;

            DataSet ds = new DataSet();

            DAL DL1x = new DAL("CarCompany.accdb");

            DataTable y1x = new DataTable();

            y1x = DL1x.getDataTable("select * from AccessoriesOrders where Num ='" + textBox1.Text + "'", y1x);

            dataGridView1.DataSource = y1x;

            button2.Visible = true;

            if (dataGridView1[0, 0].Value != null)
            {
                groupBox2.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DAL DL1 = new DAL("CarCompany.accdb");
            int yCoord = dataGridView1.CurrentCellAddress.Y;
            string I1 = dataGridView1[0, yCoord].Value.ToString();
            string I2 = dataGridView1[1, yCoord].Value.ToString();

            string sql1 = "DELETE from AccessoriesOrders WHERE Num='" + I1 + "'AND AccessCode='" + I2 + "'";
            DL1.Delete(sql1);

            DataSet ds = new DataSet();

            DAL DL1x = new DAL("CarCompany.accdb");

            DataTable y1x = new DataTable();

            y1x = DL1x.getDataTable("select * from AccessoriesOrders where Num ='" + textBox1.Text + "'", y1x);

            dataGridView1.DataSource = y1x;

            button2.Visible = true;

            if (dataGridView1[0, 0].Value != null)
            {
                groupBox2.Visible = true;
            }

        }



    }
}

