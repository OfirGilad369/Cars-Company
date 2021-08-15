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
    public partial class ShowOrder : Form
    {
        public ShowOrder()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            groupBox2.Visible = false;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "מספר הזמנה")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

              //y = DL.getDataTable("select * from Orders where Num='" + textBox1.Text + "'", y);

                y = DL.getDataTable("SELECT Orders.OrderDate, Orders.Code, Orders.ID, Orders.WorkID, Orders.Num, OrderInfo.Info, OrderInfo.Curr_Cost FROM Orders INNER JOIN OrderInfo ON Orders.Num = OrderInfo.Num WHERE (((OrderInfo.Info)<>'" + "בוטלה" + "' And (OrderInfo.Info)<>'" + "סופקה" + "' And (Orders.Num) ='" + textBox1.Text + "'))", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;

                if (dataGridView1[0, 0].Value != null)
                {
                    groupBox2.Visible = true;
                }
                else groupBox2.Visible = false; 
            }

            if (comboBox1.Text == "ת.ז. של הלקוח")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

              //y = DL.getDataTable("select * from Orders where ID='" + textBox1.Text + "'", y);

                y = DL.getDataTable("SELECT Orders.Num, Orders.OrderDate, Orders.Code, Orders.ID, Orders.WorkID, OrderInfo.Info, OrderInfo.Curr_Cost FROM Orders INNER JOIN OrderInfo ON Orders.Num = OrderInfo.Num WHERE (((OrderInfo.Info)<>'" + "בוטלה" + "' And (OrderInfo.Info)<>'" + "סופקה" + "' And (Orders.ID) ='" + textBox1.Text + "'))", y);


                dataGridView1.DataSource = y;

                button2.Visible = true;

                if (dataGridView1[0, 0].Value != null)
                {
                    groupBox2.Visible = true;
                }
                else groupBox2.Visible = false;
            }

            if ((comboBox1.Text != "מספר הזמנה") && (comboBox1.Text != "ת.ז. של הלקוח"))
            {
                MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            if (dataGridView1[0, 0].Value != null)
            {
                int yCoord = dataGridView1.CurrentCellAddress.Y;
                string I1 = dataGridView1[0, yCoord].Value.ToString();
                y = DL.getDataTable("select * from OrderInfo where Num='" + I1 + "'", y);

                if (!y.Rows[0][1].Equals("סופקה"))
                {
                    AccessoriesOrders AO = new AccessoriesOrders();
                    AO.GetNum(y.Rows[0][0].ToString());
                    AO.ShowDialog();
                }
                else
                {
                    MessageBox.Show("הזמנה זו נמצאת בתהליך ולכן לא ניתן להוסיף אביזרים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else MessageBox.Show("השורה שנבחרה אינה קיימת", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int yCoord = dataGridView1.CurrentCellAddress.Y;

            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from OrderInfo where Num='" + dataGridView1[0, yCoord].Value.ToString() + "'", y);

            if (y.Rows[0][1].Equals("בוטלה"))
            {
                MessageBox.Show("הזמנה זו כבר בוטלה", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (y.Rows[0][1].Equals("סופקה"))
                {
                    MessageBox.Show("הזמנה זו כבר סופקה", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string sql = "UPDATE OrderInfo SET Info='" + "בוטלה" + "' WHERE Num= '" + dataGridView1[0, yCoord].Value.ToString() + "'";
                    DL.Update(sql);
                }
            }
        }
    }
}

