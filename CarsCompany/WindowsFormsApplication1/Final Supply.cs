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
    public partial class FinalSupply : Form
    {
        public FinalSupply()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if ((maskedTextBox2.Text != "") && (textBox4.Text != "") && (int.Parse(textBox4.Text) > 0))
                {

                    //

                    //string t = DateTime.Now.ToLongTimeString().ToString();
                    //string t1 = t.Replace(":", "");
                    string CarNum = textBox4.Text;

                    //

                    bool ans = true;
                    string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

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
                    //

                    try
                    {
                        DAL DL1 = new DAL("CarCompany.accdb");

                        DataTable y1 = new DataTable();

                        y1 = DL1.getDataTable("select * from Cars where Car_Num ='" + textBox4.Text + "'", y1);

                        if (!y1.Rows[0].Equals(null))
                        {
                            c1 += "מספר הרכב תפוס" + "\n";
                            ans = false;
                        }
                    }
                    catch
                    {
                        c1 += "";
                    }

                    //

                    if (ans == true)
                    {

                        DAL DL1x = new DAL("CarCompany.accdb");
                        string sql1x = "UPDATE OrderInfo SET Num='" + textBox1.Text + "', Info='" + "סופקה" + "' WHERE Num= '" + textBox1.Text + "'";
                        DL1x.Insert(sql1x);

                        DAL DL0 = new DAL("CarCompany.accdb");
                        DataTable y0 = new DataTable();
                        y0 = DL0.getDataTable("select * from Orders where Num ='" + textBox1.Text + "'", y0);

                        DAL DL1xx = new DAL("CarCompany.accdb");
                        string sql1xx = "INSERT INTO Cars (ID,Code,Car_Num,Test) VALUES ('" + y0.Rows[0][3].ToString() + "', '" + y0.Rows[0][2].ToString() + "','" + CarNum.ToString() + "','" + maskedTextBox2.Text + "')";
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

                        //using (FileStream fs = new FileStream(@"C:\Users\אמיר\Desktop\'" + pro_name + "'.pdf", FileMode.Create, FileAccess.Write, FileShare.Read))
                        {

                            PdfWriter writer = PdfWriter.GetInstance(Doc, fs);


                            Doc.Open();


                            Doc.NewPage();


                            string ARIALUNI_TFF = Path.Combine(@"C:\Users\tihonist\Desktop\Cars Company 71\CarsCompany\WindowsFormsApplication1\bin\Debug", "arial.ttf");

                            //string ARIALUNI_TFF = Path.Combine(@"C:\Users\אמיר\Desktop\Cars Company 71\CarsCompany\WindowsFormsApplication1\bin\Debug", "arial.ttf");

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
                            T.AddCell(new Phrase("שם פרטי " + y0x.Rows[0][1].ToString(), f));
                            T.AddCell(new Phrase("שם משפחה " + y0x.Rows[0][2].ToString(), f));
                            T.AddCell(new Phrase("נייד " + y0x.Rows[0][3].ToString(), f));
                            T.AddCell(new Phrase("דוא'ל " + y0x.Rows[0][4].ToString(), f));
                            T.AddCell(new Phrase("רחוב " + y0x.Rows[0][5].ToString(), f));
                            T.AddCell(new Phrase("עיר " + y0x.Rows[0][6].ToString(), f));
                            T.AddCell(new Phrase(" ", f));
                            T.AddCell(new Phrase("הרכב התקבל במשרדי החברה ", f));
                            T.AddCell(new Phrase("לשביעות רצונו של הקונה מר " + y0x.Rows[0][1].ToString() + " ת.ז. " + y0x.Rows[0][0].ToString(), f));
                            T.AddCell(new Phrase(" ", f));
                            T.AddCell(new Phrase("מספר רכב " + CarNum, f));
                            T.AddCell(new Phrase("תאריך טסט אחרון " + maskedTextBox2.Text, f));
                            T.AddCell(new Phrase(" ", f));
                            T.AddCell(new Phrase("חתימה ________", f));

                            Doc.Add(T);
                            Doc.Close();
                        }

                        this.DialogResult = DialogResult.OK;

                        MessageBox.Show("ההזמנה סופקה בהצלחה", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();

                    }
                    else
                    {
                        MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("הפעולה נכשלה עקב נתונים שגויים", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("הפעולה נכשלה עקב נתונים שגויים", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FinalSupply_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = DateTime.Now.ToString();
            textBox1.Text = k;
            DAL DL0 = new DAL("CarCompany.accdb");
            DataTable y0 = new DataTable();
            y0 = DL0.getDataTable("select * from Orders where Num ='" + textBox1.Text + "'", y0);
            textBox2.Text = y0.Rows[0][2].ToString();
            textBox3.Text = y0.Rows[0][3].ToString();
            DAL DL0x = new DAL("CarCompany.accdb");
            DataTable y0x = new DataTable();
            y0x = DL0x.getDataTable("select * from Customers where ID ='" + textBox3.Text + "'", y0x);
            textBox5.Text = y0x.Rows[0][1].ToString();

        }

        private string k;

        public void GetNum(string k1)
        {
            this.k = k1;
        }

    }
}
