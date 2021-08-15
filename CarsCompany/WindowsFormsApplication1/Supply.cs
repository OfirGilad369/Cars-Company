using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApplication1
{
    public partial class Supply : Form
    {
        public Supply()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ans = true;
            string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

            try
            {
                DAL DL1 = new DAL("CarCompany.accdb");

                DataTable y1 = new DataTable();

                y1 = DL1.getDataTable("select * from Orders where Num ='" + textBox1.Text + "'", y1);

                if (!y1.Rows[0].Equals(null))
                {
                    c1 += "";
                }
            }
            catch
            {
                ans = false;
                c1 += "מספר הזמנה לא קיים";

            }

            if (ans == true)
            {

                DAL DL2 = new DAL("CarCompany.accdb");

                DataTable y2 = new DataTable();

                y2 = DL2.getDataTable("select * from Orders where Num ='" + textBox1.Text + "'", y2);

                textBox2.Text = y2.Rows[0][3].ToString();

                DAL DL3 = new DAL("CarCompany.accdb");

                DataTable y3 = new DataTable();

                y3 = DL3.getDataTable("select * from Customers where ID ='" + textBox2.Text + "'", y3);

                textBox3.Text = y3.Rows[0][1].ToString();
                textBox4.Text = y3.Rows[0][2].ToString();
                maskedTextBox1.Text = y3.Rows[0][3].ToString();
                textBox6.Text = y3.Rows[0][4].ToString();
                textBox13.Text = y3.Rows[0][5].ToString();
                textBox14.Text = y3.Rows[0][6].ToString();

                DAL DL4 = new DAL("CarCompany.accdb");

                DataTable y4 = new DataTable();

                y4 = DL4.getDataTable("select * from AccessoriesOrders where Num ='" + textBox1.Text + "'", y4);

                bool scan = true;
                int i = 0;

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;

                while (scan == true)
                {

                    try
                    {
                        if (!y4.Rows[i][0].Equals(null))
                        {
                            textBox8.Text = y4.Rows[i][1].ToString();

                            DAL DL5 = new DAL("CarCompany.accdb");

                            DataTable y5 = new DataTable();

                            y5 = DL5.getDataTable("select * from Accessories where AccessCode ='" + textBox8.Text + "'", y5);

                            if (y5.Rows[0][1].ToString() == checkBox1.Text)
                            {
                                checkBox1.Checked = true;
                            }

                            if (y5.Rows[0][1].ToString() == checkBox2.Text)
                            {
                                checkBox2.Checked = true;
                            }

                            if (y5.Rows[0][1].ToString() == checkBox3.Text)
                            {
                                checkBox3.Checked = true;
                            }

                            if (y5.Rows[0][1].ToString() == checkBox4.Text)
                            {
                                checkBox4.Checked = true;
                            }

                            if (y5.Rows[0][1].ToString() == checkBox5.Text)
                            {
                                checkBox5.Checked = true;
                            }

                            if (y5.Rows[0][1].ToString() == checkBox6.Text)
                            {
                                checkBox6.Checked = true;
                            }

                            if (y5.Rows[0][1].ToString() == checkBox7.Text)
                            {
                                checkBox7.Checked = true;
                            }

                            if (y5.Rows[0][1].ToString() == checkBox8.Text)
                            {
                                checkBox8.Checked = true;
                            }

                            i++;
                            //MessageBox.Show("OK", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch
                    {
                        scan = false;
                        //MessageBox.Show("End", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                textBox7.Text = y2.Rows[0][2].ToString();
                maskedTextBox2.Text = y2.Rows[0][1].ToString();
                DAL DL6 = new DAL("CarCompany.accdb");

                DataTable y6 = new DataTable();

                y6 = DL6.getDataTable("select * from OrderInfo where Num ='" + textBox1.Text + "'", y6);

                textBox5.Text = y6.Rows[0][2].ToString();

                int itra = int.Parse(textBox5.Text);

                int access = 0;

                if (checkBox1.Checked == true)
                {
                    DAL DL8 = new DAL("CarCompany.accdb");
                    DataTable y8 = new DataTable();
                    y8 = DL8.getDataTable("select * from Accessories where AccessName ='" + checkBox1.Text + "'", y8);
                    access += int.Parse(y8.Rows[0][2].ToString());
                }
                if (checkBox2.Checked == true)
                {
                    DAL DL8 = new DAL("CarCompany.accdb");
                    DataTable y8 = new DataTable();
                    y8 = DL8.getDataTable("select * from Accessories where AccessName ='" + checkBox2.Text + "'", y8);
                    access += int.Parse(y8.Rows[0][2].ToString());
                }
                if (checkBox3.Checked == true)
                {
                    DAL DL8 = new DAL("CarCompany.accdb");
                    DataTable y8 = new DataTable();
                    y8 = DL8.getDataTable("select * from Accessories where AccessName ='" + checkBox3.Text + "'", y8);
                    access += int.Parse(y8.Rows[0][2].ToString());
                }
                if (checkBox4.Checked == true)
                {
                    DAL DL8 = new DAL("CarCompany.accdb");
                    DataTable y8 = new DataTable();
                    y8 = DL8.getDataTable("select * from Accessories where AccessName ='" + checkBox4.Text + "'", y8);
                    access += int.Parse(y8.Rows[0][2].ToString());
                }
                if (checkBox5.Checked == true)
                {
                    DAL DL8 = new DAL("CarCompany.accdb");
                    DataTable y8 = new DataTable();
                    y8 = DL8.getDataTable("select * from Accessories where AccessName ='" + checkBox5.Text + "'", y8);
                    access += int.Parse(y8.Rows[0][2].ToString());
                }
                if (checkBox6.Checked == true)
                {
                    DAL DL8 = new DAL("CarCompany.accdb");
                    DataTable y8 = new DataTable();
                    y8 = DL8.getDataTable("select * from Accessories where AccessName ='" + checkBox6.Text + "'", y8);
                    access += int.Parse(y8.Rows[0][2].ToString());
                }
                if (checkBox7.Checked == true)
                {
                    DAL DL8 = new DAL("CarCompany.accdb");
                    DataTable y8 = new DataTable();
                    y8 = DL8.getDataTable("select * from Accessories where AccessName ='" + checkBox7.Text + "'", y8);
                    access += int.Parse(y8.Rows[0][2].ToString());
                }
                if (checkBox8.Checked == true)
                {
                    DAL DL8 = new DAL("CarCompany.accdb");
                    DataTable y8 = new DataTable();
                    y8 = DL8.getDataTable("select * from Accessories where AccessName ='" + checkBox8.Text + "'", y8);
                    access += int.Parse(y8.Rows[0][2].ToString());
                }

                textBox9.Text = access.ToString();

                int paid = 0;

                try
                {
                    DAL DL0 = new DAL("CarCompany.accdb");
                    DataTable y0 = new DataTable();
                    y0 = DL0.getDataTable("select * from CashPayment where Num ='" + textBox1.Text + "'", y0);
                    bool ans1 = true;
                    int i1 = 0;
                    while (ans1 == true)
                    {
                        if (!y0.Rows[i1].Equals(null))
                        {
                            paid += int.Parse(y0.Rows[i1][2].ToString());
                        }
                        else
                        {
                            ans1 = false;
                        }
                        i1++;
                    }

                }
                catch
                {
                    c1 += "";
                }

                try
                {
                    DAL DL0 = new DAL("CarCompany.accdb");
                    DataTable y0 = new DataTable();
                    y0 = DL0.getDataTable("select * from CheckPayment where Num ='" + textBox1.Text + "'", y0);
                    bool ans2 = true;
                    int i1 = 0;
                    while (ans2 == true)
                    {
                        if (!y0.Rows[i1].Equals(null))
                        {
                            paid += int.Parse(y0.Rows[i1][5].ToString());
                        }
                        else
                        {
                            ans2 = false;
                        }
                        i1++;
                    }

                }
                catch
                {
                    c1 += "";
                }

                try
                {
                    DAL DL0 = new DAL("CarCompany.accdb");
                    DataTable y0 = new DataTable();
                    y0 = DL0.getDataTable("select * from CreditPayment where Num ='" + textBox1.Text + "'", y0);
                    bool ans3 = true;
                    int i1 = 0;
                    while (ans3 == true)
                    {
                        if (!y0.Rows[i1].Equals(null))
                        {
                            paid += int.Parse(y0.Rows[i1][5].ToString());
                        }
                        else
                        {
                            ans3 = false;
                        }
                        i1++;
                    }

                }
                catch
                {
                    c1 += "";
                }

                int final = int.Parse(textBox5.Text) + int.Parse(textBox9.Text);

                int total = final - paid;

                textBox10.Text = total.ToString();

                textBox12.Text = paid.ToString();

                if (textBox10.Text == "0")
                {
                    button3.Visible = true;
                }
                else
                {
                    button2.Visible = true;
                }

            }
            else
            {
                MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FinalPayments Log = new FinalPayments();
            Log.GetNum(textBox1.Text);
            Log.GetItra(textBox10.Text);
            Log.ShowDialog();
        }
        
        private void Supply_X_Load(object sender, EventArgs e)
        {
            textBox1.Text = j;
            if (progress == true)
            {
                Close();
            }
        }

        private string j;

        public void GetNum(string j1)
        {
            this.j = j1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FinalSupply FS = new FinalSupply();
            FS.StartPosition = FormStartPosition.CenterScreen;
            FS.GetNum(textBox1.Text);
            FS.ShowDialog();
            if (FS.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
               //
            } 



            /*

            DAL DL1x = new DAL("CarCompany.accdb");
            string sql1x = "UPDATE OrderInfo SET Num='" + textBox1.Text + "', Info='" + "סופקה" + "' WHERE Num= '" + textBox1.Text + "'";
            DL1x.Insert(sql1x);

            //

            string t = DateTime.Now.ToLongTimeString().ToString();
            string t1 = t.Replace(":", "");
            string CarNum = t1;

            DAL DL0 = new DAL("CarCompany.accdb");
            DataTable y0 = new DataTable();
            y0 = DL0.getDataTable("select * from Orders where Num ='" + textBox1.Text + "'", y0);

            DAL DL1xx = new DAL("CarCompany.accdb");
            string sql1xx = "INSERT INTO Cars (ID,Code,CarNum) VALUES ('" + y0.Rows[0][3].ToString() + "', '" + y0.Rows[0][2].ToString() + "','" + CarNum + "')";            
            DL1xx.Insert(sql1xx);

            DAL DL0x = new DAL("CarCompany.accdb");
            DataTable y0x = new DataTable();
            y0x = DL0x.getDataTable("select * from Customers where ID ='" + y0.Rows[0][3].ToString() + "'", y0x);


            
            //

            Document Doc = new Document(PageSize.LETTER);

            DateTime saveNow = DateTime.Now;
            string a = saveNow.ToLongTimeString().ToString();
            string b = saveNow.ToShortDateString().ToString();
            string pro_name1 = a + "_" + b;
            string pro_name = pro_name1.Replace("/", ".");
            pro_name = pro_name.Replace(":", ".");

            using (FileStream fs = new FileStream(@"C:\Users\tihonist\Desktop\'" + pro_name + "'.pdf", FileMode.Create, FileAccess.Write, FileShare.Read))

            //using (FileStream fs1 = new FileStream(@"C:\Users\אמיר\Desktop\'" + pro_name + "'.pdf", FileMode.Create, FileAccess.Write, FileShare.Read))
            {

                PdfWriter writer = PdfWriter.GetInstance(Doc, fs);


                Doc.Open();


                Doc.NewPage();


                string ARIALUNI_TFF = Path.Combine(@"C:\Users\tihonist\Desktop\Cars Company 46\CarsCompany\WindowsFormsApplication1\bin\Debug", "arial.ttf");

                // string ARIALUNI_TFF1 = Path.Combine(@"C:\Users\אמיר\Desktop\Cars Company 46\CarsCompany\WindowsFormsApplication1\bin\Debug", "arial.ttf");

                BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);


                iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 12);

                PdfPTable T = new PdfPTable(1);

                T.DefaultCell.BorderWidth = 0;

                T.RunDirection = PdfWriter.RUN_DIRECTION_RTL;

                T.AddCell(new Phrase("אישור הספקה", f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("תאריך הספקה " + DateTime.Now + "", f));
                T.AddCell(new Phrase("מספר הזמנה " + textBox1.Text + "", f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("פרטים אישיים", f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("ת.ז. " + y0x.Rows[0][0].ToString(), f));
                T.AddCell(new Phrase("שם פרטי" + y0x.Rows[0][1].ToString() , f));
                T.AddCell(new Phrase("שם משפחה " + y0x.Rows[0][2].ToString() , f));
                T.AddCell(new Phrase("נייד " + y0x.Rows[0][3].ToString() , f));
                T.AddCell(new Phrase("דוא'ל " + y0x.Rows[0][4].ToString() , f));
                T.AddCell(new Phrase("רחוב " + y0x.Rows[0][5].ToString() , f));
                T.AddCell(new Phrase("עיר " + y0x.Rows[0][6].ToString() , f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("הרכב התקבל במשרדי החברה ", f));
                T.AddCell(new Phrase("לשביעות רצונו של הקונה מר " + y0x.Rows[0][1].ToString() + "ת.ז. " + y0x.Rows[0][0].ToString() , f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("מספר רכב " + CarNum, f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("חתימה ________", f));

                Doc.Add(T);
                Doc.Close();


                //
                
               */
            

            //}

        }

        private bool progress = false;

        public void GetResult(bool pro)
        {
            this.progress = pro;
        }

        public static int closr_or_not=0;

    }
}
