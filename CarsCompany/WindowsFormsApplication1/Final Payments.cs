using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class FinalPayments : Form
    {
        public FinalPayments()
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
                groupBox6.Visible = true;
            }
            else
            {
                MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "מזומן")
            {
                groupBox5.Visible = true;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                textBox5.Text = textBox16.Text;
            }
            if (comboBox1.Text == "אשראי")
            {
                groupBox3.Visible = true;
                groupBox5.Visible = false;
                groupBox4.Visible = false;
                textBox7.Text = textBox16.Text;
            }
            if (comboBox1.Text == "צ'ק")
            {
                groupBox4.Visible = true;
                groupBox3.Visible = false;
                groupBox5.Visible = false;
                textBox10.Text = textBox16.Text;
            }
            if ((comboBox1.Text != "מזומן") && (comboBox1.Text != "אשראי") && (comboBox1.Text != "צ'ק"))
            {
                MessageBox.Show("השדה שהוכנס באמצעי תשלום לא קיים במערכת", "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DAL DL = new DAL("CarCompany.accdb");

            if ((maskedTextBox5.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                bool ans = true;
                string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";


                maskedTextBox5.Text = DateTime.Now.ToString();
                //DateTime Test;
                //if (DateTime.TryParseExact(maskedTextBox5.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) != true)
                //{
                //    ans = false;
                //    c1 += "התאריך שגוי" + "\n";
                //}

                try
                {
                    if (int.Parse(textBox5.Text) > 0)
                    {
                        c1 += "";
                    }
                    else
                    {
                        c1 += "הסכום לתשלום לא תקין" + "\n";
                        ans = false;
                    }
                }
                catch
                {
                    c1 += "הסכום לתשלום לא תקין" + "\n";
                    ans = false;
                }

                if (ans == true)
                {
                    string kind = "תשלום סופי";
                    string sql = "INSERT INTO CashPayment (Num,P_Date,T_Paid,P_Kind) VALUES ('" + textBox1.Text + "', '" + maskedTextBox5.Text + "', '" + textBox5.Text + "','" + kind + "')";
                    DL.Insert(sql);

                    Supply S = new Supply();
                    S.GetNum(textBox1.Text);
                    S.ShowDialog();

                }
                else
                {
                    MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DAL DL = new DAL("CarCompany.accdb");

            if ((textBox15.Text == "") || (textBox12.Text == "") || (textBox7.Text == "") || (maskedTextBox6.Text == "") || (maskedTextBox2.Text == ""))
            {
                MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                bool ans = true;
                string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                DateTime Test;
                if (DateTime.TryParseExact(maskedTextBox6.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) != true)
                {
                    ans = false;
                    c1 += "תוקף הכרטיס שגוי" + "\n";
                }
                if (DateTime.TryParseExact(maskedTextBox2.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) != true)
                {
                    ans = false;
                    c1 += "התאריך שגוי" + "\n";
                }

                if (textBox15.Text.Length != 5)
                {

                    ans = false;
                    c1 += "מספר הכרטיס קצר מדי" + "\n";
                }

                try
                {
                    if (int.Parse(textBox15.Text) > 0)
                    {
                        c1 += "";
                    }
                    else
                    {
                        c1 += "מספר הכרטיס לא תקין" + "\n";
                        ans = false;
                    }
                }
                catch
                {
                    c1 += "מספר הכרטיס לא תקין" + "\n";
                    ans = false;
                }

                if (textBox12.Text.Length != 5)
                {

                    ans = false;
                    c1 += "קוד הביקורת קצר מדי" + "\n";
                }

                try
                {
                    if (int.Parse(textBox12.Text) > 0)
                    {
                        c1 += "";
                    }
                    else
                    {
                        c1 += "קוד בנקורת לא תקין" + "\n";
                        ans = false;
                    }
                }
                catch
                {
                    c1 += "קוד ביקורת לא תקין" + "\n";
                    ans = false;
                }

                try
                {
                    if (int.Parse(textBox7.Text) > 0)
                    {
                        c1 += "";
                    }
                    else
                    {
                        c1 += "הסכום לתשלום לא תקין" + "\n";
                        ans = false;
                    }
                }
                catch
                {
                    c1 += "הסכום לתשלום לא תקין" + "\n";
                    ans = false;
                }

                if (ans == true)
                {
                    string kind = "תשלום סופי";
                    string sql = "INSERT INTO CreditPayment (Num,Card_Num,Card_Date,Card_Code,P_Date,T_Paid,P_Kind) VALUES ('" + textBox2.Text + "', '" + textBox15.Text + "', '" + maskedTextBox6.Text + "','" + textBox12.Text + "','" + maskedTextBox2.Text + "','" + textBox7.Text + "','" + kind + "')";
                    DL.Insert(sql);

                    Supply S = new Supply();
                    S.GetNum(textBox1.Text);
                    S.ShowDialog();
                }
                else
                {
                    MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DAL DL = new DAL("CarCompany.accdb");

            if ((textBox8.Text == "") || (textBox9.Text == "") || (textBox10.Text == "") || (maskedTextBox3.Text == "") || (maskedTextBox4.Text == ""))
            {
                MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                bool ans = true;
                string c1 = "הפעולה נכשלה בגלל הסיבות הבאות" + "\n";

                DateTime Test;
                if (DateTime.TryParseExact(maskedTextBox3.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) != true)
                {
                    ans = false;
                    c1 += "זמן פריון הצ'ק שגוי" + "\n";
                }

                if (DateTime.TryParseExact(maskedTextBox4.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out Test) != true)
                {
                    ans = false;
                    c1 += "זמן פריון הצ'ק שגוי" + "\n";
                }

                try
                {
                    if ((int.Parse(textBox8.Text) > 0) && (int.Parse(textBox8.Text) < 11))
                    {
                        c1 += "";
                    }
                    else
                    {
                        c1 += "מספר צ'קים לא תקין התווך הוא בין 1 עד 10" + "\n";
                        ans = false;
                    }
                }
                catch
                {
                    c1 += "מספר צ'קים לא תקין התווך הוא בין 1 עד 10" + "\n";
                    ans = false;
                }

                if (textBox9.Text.Length != 5)
                {

                    ans = false;
                    c1 += "מספר סניף קצר מדי" + "\n";
                }

                try
                {
                    if (int.Parse(textBox5.Text) > 0)
                    {
                        c1 += "";
                    }
                    else
                    {
                        c1 += "מספר סניף לא תקין" + "\n";
                        ans = false;
                    }
                }
                catch
                {
                    c1 += "מספר סניף לא תקין" + "\n";
                    ans = false;
                }

                try
                {
                    if (int.Parse(textBox10.Text) > 0)
                    {
                        c1 += "";
                    }
                    else
                    {
                        c1 += "הסכום לתשלום לא תקין" + "\n";
                        ans = false;
                    }
                }
                catch
                {
                    c1 += "הסכום לתשלום לא תקין" + "\n";
                    ans = false;
                }

                if (ans == true)
                {
                    string kind = "תשלום סופי";
                    string sql = "INSERT INTO CheckPayment (Num,Check_Num,Place_Num,Active_Time,P_Date,T_Paid,P_Kind) VALUES ('" + textBox2.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "','" + maskedTextBox3.Text + "','" + maskedTextBox4.Text + "','" + textBox10.Text + "','" + kind + "')";
                    DL.Insert(sql);

                    Supply S = new Supply();
                    S.GetNum(textBox1.Text);
                    S.ShowDialog();
                }
                else
                {
                    MessageBox.Show(c1, "בעיה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FinalPayments_Load(object sender, EventArgs e)
        {
            textBox1.Text = f;
            textBox16.Text = fx;
        }

        private string f;

        public void GetNum(string f1)
        {
            this.f = f1;
        }

        private string fx;

        public void GetItra(string fx1)
        {
            this.fx = fx1;
        }
        
    }
}
