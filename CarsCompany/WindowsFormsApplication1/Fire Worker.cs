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
    public partial class FireWorker : Form
    {
        public FireWorker()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Document Doc = new Document(PageSize.LETTER);

            DateTime saveNow = DateTime.Now;
            string a = saveNow.ToLongTimeString().ToString();
            string b = saveNow.ToShortDateString().ToString();
            string pro_name1 = a+ "_" + b ;
            string pro_name = pro_name1.Replace("/", ".");
            pro_name = pro_name.Replace(":", ".");

            using (FileStream fs = new FileStream(@"C:\Users\tihonist\Desktop\'"+pro_name+"'.pdf", FileMode.Create, FileAccess.Write, FileShare.Read))

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

                T.AddCell(new Phrase("לכבוד: ", f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("" + textBox9.Text + " " + textBox10.Text + "", f));
                T.AddCell(new Phrase("תעודת זהות: " + "" + textBox8.Text + "", f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("הרנו להודיעך על סיום עבודתך בחברה", f));
                T.AddCell(new Phrase("החל מתאריך " + "" + b + "", f));
                T.AddCell(new Phrase("הנהלת החברה מודה לך על עבודתך", f));
                T.AddCell(new Phrase("בחברתנו בין השנים " + "" + maskedTextBox4.Text + "" + " ל " + "" + b + "", f));
                T.AddCell(new Phrase("בהצלחה בהמשך הדרך", f));
                T.AddCell(new Phrase(" ", f));
                T.AddCell(new Phrase("בכבוד רב", f));
                T.AddCell(new Phrase("חברת UniFord", f));
                

                Doc.Add(T);
                Doc.Close();

            }

            DAL x = new DAL("CarCompany.accdb");
            string sql = "UPDATE Workers SET W_Stats='" + "פוטר" + "' WHERE WorkID= '" + textBox8.Text + "'";
            x.Update(sql);

            //

            DAL DL1z = new DAL("CarCompany.accdb");
            string sql1z = "DELETE from TimeList WHERE WorkID='" + textBox8.Text + "'";
            DL1z.Delete(sql1z);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from Workers where WorkID='" + textBox8.Text + "'", y);

            textBox8.Text = y.Rows[0][0].ToString();
            textBox9.Text = y.Rows[0][1].ToString();
            textBox10.Text = y.Rows[0][2].ToString();
            maskedTextBox2.Text = y.Rows[0][3].ToString();
            textBox12.Text = y.Rows[0][4].ToString();
            textBox7.Text = y.Rows[0][5].ToString();
            textBox15.Text = y.Rows[0][6].ToString();
            textBox1.Text = y.Rows[0][7].ToString();
            maskedTextBox4.Text = y.Rows[0][8].ToString();
        }

        private void FireWorker_Load(object sender, EventArgs e)
        {
            textBox8.Text = WI;

            DAL DL = new DAL("CarCompany.accdb");

            DataTable y = new DataTable();

            y = DL.getDataTable("select * from Workers where WorkID='" + textBox8.Text + "'", y);

            textBox8.Text = y.Rows[0][0].ToString();
            textBox9.Text = y.Rows[0][1].ToString();
            textBox10.Text = y.Rows[0][2].ToString();
            maskedTextBox2.Text = y.Rows[0][3].ToString();
            textBox12.Text = y.Rows[0][4].ToString();
            textBox7.Text = y.Rows[0][5].ToString();
            textBox15.Text = y.Rows[0][6].ToString();
            textBox1.Text = y.Rows[0][7].ToString();
            maskedTextBox4.Text = y.Rows[0][8].ToString();
        }

        private string WI;

        public void GetWorkID(string WI1)
        {
            this.WI = WI1;
        }
    }
}
