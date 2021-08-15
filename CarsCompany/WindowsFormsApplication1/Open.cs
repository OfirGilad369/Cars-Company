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
    public partial class Open : Form
    {
        public Open()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DAL DL1 = new DAL("CarCompany.accdb");

                DAL DL2 = new DAL("CarCompany.accdb");

                DataTable y1 = new DataTable();

                DataTable y2 = new DataTable();

                y1 = DL1.getDataTable("select * from Workers where WorkID ='" + textBox1.Text + "' AND Job ='" + comboBox1.Text + "'", y1);

                y2 = DL2.getDataTable("select * from WorkersAccess where WorkID ='" + textBox1.Text + "' AND WPassword ='" + textBox2.Text + "'", y2);

                if (y1.Rows[0][0].ToString() != null)
                {
                    if (y2.Rows[0][0].ToString() != null)
                    {
                        DAL DL1x = new DAL("CarCompany.accdb");

                        DataTable y1x = new DataTable();

                        y1x = DL1.getDataTable("select * from Workers where WorkID ='" + textBox1.Text + "' AND Job ='" + comboBox1.Text + "' AND W_Stats='" + "רגיל" + "'", y1x);

                        try
                        {

                            if (y1x.Rows[0][0].ToString() != null)
                            {

                                MessageBox.Show("Welcome To UniFord Company", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Visible = false;

                                //

                                if (comboBox1.Text == "מנהל")
                                {
                                    Guider2 G = new Guider2();
                                    G.GetID(textBox1.Text);
                                    G.ShowDialog();
                                    this.Close();
                                }

                                //

                                if (comboBox1.Text == "מוכר")
                                {
                                    Guider1 G = new Guider1();
                                    G.GetID(textBox1.Text);
                                    G.ShowDialog();
                                    this.Close();
                                }

                                //

                                if (comboBox1.Text == "טכנאי")
                                {
                                    Guider3 G = new Guider3();
                                    G.GetID(textBox1.Text);
                                    G.ShowDialog();
                                    this.Close();
                                }

                                //

                                if (comboBox1.Text == "מזכירות")
                                {
                                    Guider4 G = new Guider4();
                                    G.GetID(textBox1.Text);
                                    G.ShowDialog();
                                    this.Close();
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("עובד זה פוטר מן המערכת", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("השם משתמש או הסיסמא שגויה", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("הקוד משתמש אינו מנהל", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("השם משתמש או הסיסמא שגויים", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
              
        }
    }
}
