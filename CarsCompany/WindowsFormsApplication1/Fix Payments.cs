using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WindowsFormsApplication1
{
    public partial class FixPayments : Form
    {
        public FixPayments()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ans = true;
            string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

            if ((comboBox1.Text != "אשראי") && (comboBox1.Text != "צ'ק") && (comboBox1.Text != "מזומן"))
            {
                ans = false;
                c1 += "אמצעי תשלום זה אינו קיים במערכת" + "\n";
            }

            DateTime Test;
            if (DateTime.TryParseExact(maskedTextBox1.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) != true)
            {
                ans = false;
                c1 += "התאריך שגוי" + "\n";
            }

            if (ans == true)
            {
                DAL DL1x = new DAL("CarCompany.accdb");

                DataTable y1x = new DataTable();

                y1x = DL1x.getDataTable("select * from Fixes where FixID ='" + textBox3.Text + "'", y1x);


                DAL DL = new DAL("CarCompany.accdb");
                string sql = "INSERT INTO FixesPayments (FixID,FaultCode,FixDate,Kind,Total) VALUES ('" + textBox3.Text + "','" + y1x.Rows[0][2].ToString() + "', '" + maskedTextBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "')";
                DL.Insert(sql);

                DAL DL1xx = new DAL("CarCompany.accdb");
                string sql1 = "UPDATE Fixes SET Stats='" + "שולם" + "' WHERE FixID='" + textBox3.Text + "'";
                DL1xx.Insert(sql1);

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

                    T.AddCell(new Phrase("תשלום עבור תיקון", f));
                    T.AddCell(new Phrase(" ", f));
                    T.AddCell(new Phrase("התשלום עבור התיקון בוצע בהצלחה", f));
                    T.AddCell(new Phrase(" ", f));
                    T.AddCell(new Phrase("פרטי התיקון", f));
                    T.AddCell(new Phrase("מספר רכב " + textBox1.Text + "", f));
                    T.AddCell(new Phrase("סה'כ שולם " + textBox2.Text + "" + b + "", f));
                    T.AddCell(new Phrase("סוג תשלום " + comboBox1.Text, f));
                    T.AddCell(new Phrase("מספר תיקון " + "" + textBox3.Text + "" + " ל " + "" + b + "", f));
                    T.AddCell(new Phrase("תאריך " + maskedTextBox1.Text, f));
                    T.AddCell(new Phrase(" ", f));
                    T.AddCell(new Phrase("בכבוד רב", f));
                    T.AddCell(new Phrase("חברת UniFord", f));


                    Doc.Add(T);
                    Doc.Close();

                }

                //

                Close();

            }
            else
            {
                MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void FixPayments_Load(object sender, EventArgs e)
        {
            textBox3.Text = a;

            DAL DL1 = new DAL("CarCompany.accdb");

            DataTable y1 = new DataTable();

            y1 = DL1.getDataTable("select * from Fixes where FixID ='" + a + "'", y1);

            textBox1.Text = y1.Rows[0][3].ToString();

            DAL DL1x = new DAL("CarCompany.accdb");

            DataTable y1x = new DataTable();

            y1x = DL1x.getDataTable("select * from TypesOfFaults where FaultCode ='" + y1.Rows[0][2].ToString() + "'", y1x);

            textBox2.Text = y1x.Rows[0][2].ToString();

        }

        private string a;

        public void GetFixID(string a1)
        {
            this.a = a1;
        }
    }
}
