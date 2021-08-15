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
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class Orders : Form
    {
        public Orders()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            
            DataSet ds = new DataSet();

            if (comboBox1.Text == "קוד הזמנה")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Orders where Num LIKE'" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
            }

            if (comboBox1.Text == "קוד רכב")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Orders where Code LIKE'" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
            }

            if (comboBox1.Text == "ת.ז.")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Orders where ID LIKE'" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                
            }

            if (comboBox1.Text == "קוד עובד")
            {

                DAL DL = new DAL("CarCompany.accdb");

                DataTable y = new DataTable();

                y = DL.getDataTable("select * from Orders where WorkID LIKE'" + textBox1.Text + "%'", y);

                dataGridView1.DataSource = y;

                button2.Visible = true;
                
            }
            if ((comboBox1.Text != "קוד הזמנה") && (comboBox1.Text != "קוד רכב") && (comboBox1.Text != "ת.ז.") && (comboBox1.Text != "קוד עובד")) MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool Nans = false;
            DialogResult dr = MessageBox.Show("האם ברצונך לבצע פעולה זו", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                DAL DL = new DAL("CarCompany.accdb");

                if (textBox10.Text == "" || maskedTextBox1.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox15.Text == "")
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //try
                    //{
                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                    //if (textBox10.Text[5] != null)
                    //{
                    //    c1 += "קוד ההזמנה חייב להיות בעל 4 תווים" + "\n";
                    //    ans = false;
                    //}

                    try
                    {
                        if ((int.Parse(textBox10.Text) <= 9999) && (int.Parse(textBox10.Text) > 999))
                        {
                            c1 += "";
                        }
                        else
                        {
                            c1 += "קוד הזמנה שגוי" + "\n";
                            ans = false;
                        }

                    }
                    catch
                    {
                        c1 += "קוד הזמנה שגוי" + "\n";
                        ans = false;
                    }

                    /*try
                    {
                        DAL DL0 = new DAL("CarCompany.accdb");

                        DataTable y0 = new DataTable();

                        y0 = DL0.getDataTable("select * from Orders where Num ='" + textBox10.Text + "'", y0);

                        if (!y0.Rows[0].Equals(null))
                        {
                            c1 += "קוד הזמנה תפוס" + "\n";
                            ans = false;
                        }

                    }
                    catch
                    {
                        c1 += "";

                    }*/

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Models where Code ='" + textBox12.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }
                    }
                    catch
                    {
                        c1 += "קוד הרכב שגוי" + "\n";
                        ans = false;
                    }

                    DateTime Test;
                    if (DateTime.TryParseExact(maskedTextBox1.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) != true)
                    {
                        ans = false;
                        c1 += "התאריך שגוי" + "\n";
                    }
                    else
                    {
                        DateTime d1 = DateTime.Now;
                        string d2x = maskedTextBox1.Text;
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
                        DAL DL2 = new DAL("CarCompany.accdb");

                        DataTable y2 = new DataTable();

                        y2 = DL2.getDataTable("select * from Customers where ID ='" + textBox13.Text + "'", y2);

                        if (!y2.Rows[0].Equals(null))
                        {
                            c1 += "";
                        }
                    }
                    catch
                    {
                        c1 += "ת.ז. של הלקוח שגויה" + "\n";
                        ans = false;
                    }


                    try
                    {

                        DAL DL3 = new DAL("CarCompany.accdb");

                        DataTable y3 = new DataTable();

                        y3 = DL3.getDataTable("select * from Workers where WorkID ='" + textBox15.Text + "' AND Job ='מוכר' AND W_Stats='רגיל'", y3);


                        if (!y3.Rows[0].Equals(null))
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

                        string t = DateTime.Now.ToLongTimeString().ToString();
                        string t1 = t.Replace(":", "");
                        textBox10.Text = textBox10.Text + "-" + t1;

                        string sql = "INSERT INTO Orders (Num,OrderDate,Code,ID,WorkID) VALUES ('" + textBox10.Text + "', '" + maskedTextBox1.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox15.Text + "')";
                        DL.Insert(sql);


                        DAL DLxx = new DAL("CarCompany.accdb");
                        DataTable yxx = new DataTable();
                        yxx = DLxx.getDataTable("select * from Models where Code ='" + textBox12.Text + "'", yxx);


                        DAL DL1x = new DAL("CarCompany.accdb");
                        string sql1x = "INSERT INTO OrderInfo (Num, Info, Curr_Cost) VALUES ('" + textBox10.Text + "', '" + "מקדמה" + "', '" + int.Parse(yxx.Rows[0][2].ToString()) + "')";
                        DL1x.Insert(sql1x);


                        MessageBox.Show("ההוספה התבצעה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Nans = true;  
                    }

                    else
                    {
                        MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }

                if (Nans == true)
                {
                    DialogResult dr1 = MessageBox.Show("האם ברצונך להוסיף אביזרים לקנייה", "הערה", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dr1 == DialogResult.OK)
                    {
                        AccessoriesOrders Log1 = new AccessoriesOrders();
                        Log1.StartPosition = FormStartPosition.CenterScreen;
                        Log1.GetNum(textBox10.Text);
                        Log1.ShowDialog();
                    }

                    //PDF

                    string t = DateTime.Now.ToLongTimeString().ToString();
            string t1 = t.Replace(":", "");
            string CarNum = t1;

            DAL DL0 = new DAL("CarCompany.accdb");
            DataTable y0 = new DataTable();
            y0 = DL0.getDataTable("select * from Orders where Num ='" + textBox10.Text + "'", y0);

            //DAL DL1xx = new DAL("CarCompany.accdb");
            //string sql1xx = "INSERT INTO Cars (ID,Code,CarNum) VALUES ('" + y0.Rows[0][3].ToString() + "', '" + y0.Rows[0][2].ToString() + "','" + textBox10.Text + "')";            
            //DL1xx.Insert(sql1xx);

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



            DAL DL0xx = new DAL("CarCompany.accdb");
            DataTable y0xx = new DataTable();
            y0xx = DL0x.getDataTable("select * from Customers where ID ='" + textBox13.Text + "'", y0xx);


            using (FileStream fs = new FileStream(@"C:\Users\tihonist\Desktop\'" + pro_name + "'.pdf", FileMode.Create, FileAccess.Write, FileShare.Read))

            //using (FileStream fs1 = new FileStream(@"C:\Users\אמיר\Desktop\'" + pro_name + "'.pdf", FileMode.Create, FileAccess.Write, FileShare.Read))
            {

                PdfWriter writer = PdfWriter.GetInstance(Doc, fs);


                Doc.Open();


                Doc.NewPage();


                string ARIALUNI_TFF = Path.Combine(@"C:\Users\tihonist\Desktop\Cars Company 71\CarsCompany\WindowsFormsApplication1\bin\Debug", "arial.ttf");

                // string ARIALUNI_TFF1 = Path.Combine(@"C:\Users\אמיר\Desktop\Cars Company 71\CarsCompany\WindowsFormsApplication1\bin\Debug", "arial.ttf");

                BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);


                iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 12);

                PdfPTable T = new PdfPTable(1);

                T.DefaultCell.BorderWidth = 0;

                T.RunDirection = PdfWriter.RUN_DIRECTION_RTL;



                T.AddCell(new Phrase("אישור הזמנה", f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("מספר הזמנה " + textBox10.Text, f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("פרטים אישיים", f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("ת.ז. " + y0xx.Rows[0][0].ToString(), f));
                T.AddCell(new Phrase("שם פרטי " + y0xx.Rows[0][1].ToString(), f));
                T.AddCell(new Phrase("שם משפחה " + y0xx.Rows[0][2].ToString(), f));
                T.AddCell(new Phrase("נייד " + y0xx.Rows[0][3].ToString(), f));
                T.AddCell(new Phrase("דוא'ל " + y0xx.Rows[0][4].ToString(), f));
                T.AddCell(new Phrase("רחוב " + y0xx.Rows[0][5].ToString(), f));
                T.AddCell(new Phrase("עיר " + y0xx.Rows[0][6].ToString(), f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("תאריך הזמנה " + maskedTextBox1.Text, f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("אביזרים", f));
                T.AddCell(new Phrase(" ", f));

                DAL DL0w = new DAL("CarCompany.accdb");
                DataTable y0w = new DataTable();
                y0w = DL0w.getDataTable("select * from AccessoriesOrders where Num ='" + textBox10.Text + "'", y0w);

                int i = 0;

                int access = 0;

                try
                {

                    while (!y0w.Rows[i][0].Equals(null))
                    {

                        DAL DL0w1 = new DAL("CarCompany.accdb");
                        DataTable y0w1 = new DataTable();
                        y0w1 = DL0w.getDataTable("select * from Accessories where AccessCode ='" + y0w.Rows[i][1].ToString() + "'", y0w1);

                        access += int.Parse(y0w1.Rows[0][2].ToString());

                        T.AddCell(new Phrase(y0w1.Rows[0][1].ToString(), f));

                        i++;
                    }
                }
                catch
                {
                    //
                }

                DAL DL0w2 = new DAL("CarCompany.accdb");
                DataTable y0w2 = new DataTable();
                y0w2 = DL0w2.getDataTable("select * from OrderInfo where Num ='" + textBox10.Text + "'", y0w2);

                access += int.Parse(y0w2.Rows[0][2].ToString());

                T.AddCell(new Phrase("", f));
                T.AddCell(new Phrase("סך הכל להזמנה " + access.ToString() + "ש'ח", f));


                Doc.Add(T);
                Doc.Close();
            }

                    MessageBox.Show("המערכת עוברת לתשלום המקדמה", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Mikdama P = new Mikdama();
                    P.GetNum(textBox10.Text);
                    P.ShowDialog();
                    
                }

            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*DateTime Test;
            if (DateTime.TryParseExact(maskedTextBox1.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) == true)
            {
                string c1 = "התאריך שגוי" + "\n" + "ok";
                MessageBox.Show(c1, "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("ההוספה נכשלה", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
             

            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from Workers where WorkID ='" + textBox15.Text + "'", y);

            try
            {

                if (!y.Rows[0].Equals(null))
                {
                    MessageBox.Show("ההוספה הצליחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("ההוספה נכשלה", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            DAL DL1 = new DAL("CarCompany.accdb");

            DataTable y1 = new DataTable();

            y1 = DL1.getDataTable("select * from Workers where WorkID ='" + textBox15.Text + "' AND Job ='מוכר'", y1);

            try
            {

                if (!y1.Rows[0].Equals(null))
                {
                    MessageBox.Show("ההוספה הצליחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch
            {
                MessageBox.Show("ההוספה נכשלה", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomersSearch C = new CustomersSearch();
            C.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModelsSearch M = new ModelsSearch();
            M.ShowDialog();
        }
       
    }
}
