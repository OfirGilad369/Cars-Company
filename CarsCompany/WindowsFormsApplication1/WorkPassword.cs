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
    public partial class WorkPassword : Form
    {
        public WorkPassword()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                try
                {
                    DAL DL1 = new DAL("CarCompany.accdb");

                    DataTable y1 = new DataTable();

                    y1 = DL1.getDataTable("select * from Workers where WorkID ='" + textBox1.Text + "'", y1);

                    if (!y1.Rows[0].Equals(null))
                    {
                        try
                        {
                            DAL DL1x = new DAL("CarCompany.accdb");
                            string sql1x = "INSERT INTO WorkersAccess (WorkID, WPassword) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                            DL1x.Insert(sql1x);

                            //

                            DAL DL = new DAL("CarCompany.accdb");

                            DataTable y = new DataTable();

                            y = DL.getDataTable("select * from WorkersAccess where WorkID LIKE '%' ", y);

                            dataGridView1.DataSource = y;
                        }
                        catch
                        {
                            MessageBox.Show("לעובד זה יש כבר סיסמא למערכת", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("העובד לא קיים במערכת", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void WorkPassword_Load(object sender, EventArgs e)
        {
            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from WorkersAccess where WorkID LIKE '%' ", y);

            dataGridView1.DataSource = y;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int yCoord = dataGridView1.CurrentCellAddress.Y;
            string I1 = dataGridView1[0, yCoord].Value.ToString();
            string I2 = dataGridView1[1, yCoord].Value.ToString();
            textBox3.Text = I1;
            textBox4.Text = I2;
            textBox4.ReadOnly = false;
            button2.Visible = true;
            button4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DAL x = new DAL("CarCompany.accdb");
            string sql = "UPDATE WorkersAccess SET WPassword='" + textBox4.Text + "' WHERE WorkID= '" + textBox3.Text + "'";
            x.Update(sql);

            //

            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from WorkersAccess where WorkID LIKE '%' ", y);

            dataGridView1.DataSource = y;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox4.Text = "";
            button2.Visible = false;
            button4.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WorkersSearch WS = new WorkersSearch();
            WS.ShowDialog();
        }
    }
}
