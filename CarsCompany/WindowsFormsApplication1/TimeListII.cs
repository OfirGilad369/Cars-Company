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
    public partial class TimeListII : Form
    {
        public TimeListII()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void TimeListII_Load(object sender, EventArgs e)
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool AnsTotal = true, Break = false;


            if ((comboBox1.Text != "") && (comboBox2.Text != "") && (int.Parse(comboBox1.Text) < 55) && (int.Parse(comboBox1.Text) > 0))
            {

                try
                {

                    DAL DL1 = new DAL("CarCompany.accdb");

                    DataTable y1 = new DataTable();

                    y1 = DL1.getDataTable("select * from Days where Day_Name='" + comboBox2.Text + "'", y1);


                    DAL DL = new DAL("CarCompany.accdb");

                    DataTable y = new DataTable();

                    y = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox1.Text + "'", y);

                    try
                    {
                        if (!y.Rows[0][0].Equals(null))
                        {
                            AnsTotal = false;
                        }
                    }

                    catch
                    {
                        //
                    }
                }

                catch
                {
                    AnsTotal = false;
                }
            }
            else
            {
                AnsTotal = false;
            }

            //
            //

            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                DAL DL1 = new DAL("CarCompany.accdb");

                DataTable y1 = new DataTable();

                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox1.Text + "'AND Job='" + "מוכר" + "'", y1);

                //

                DAL DL1x = new DAL("CarCompany.accdb");

                DataTable y1x = new DataTable();

                y1x = DL1x.getDataTable("select * from Workers where WorkID='" + textBox2.Text + "'AND Job='" + "מוכר" + "'", y1x);

                //

                DAL DL1xx = new DAL("CarCompany.accdb");

                DataTable y1xx = new DataTable();

                y1xx = DL1xx.getDataTable("select * from Workers where WorkID='" + textBox3.Text + "'AND Job='" + "מוכר" + "'", y1xx);

                bool ans = true;
                string c1 = "העובדים הללו אינם מוכרים" + "\n";

                try
                {
                    if (!y1.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 1" + "\n";
                }

                try
                {
                    if (!y1x.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 2" + "\n";
                }

                try
                {
                    if (!y1xx.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 3" + "\n";
                }

                bool ans1 = true;

                if ((textBox1.Text == textBox2.Text) || (textBox2.Text == textBox3.Text) || (textBox1.Text == textBox3.Text))
                {
                    ans1 = false;
                }

                if (ans == true)
                {
                    if (ans1 == false)
                    {
                        AnsTotal = false;
                    }
                    else
                    {
                        //
                    }
                }
                else
                {
                    if (ans1 == false)
                    {
                        AnsTotal = false;
                    }
                    AnsTotal = false;
                }
            }

            else
            {
                if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == ""))
                {
                    AnsTotal = false;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("לא כל שדות המוכרים מלאות. האם אתה בטוח שברצונך להוסיף פחות משלושה מוכרים לאותו היום? (יש אפשרות להוסיף עובדים נוספים בטופס העריכה)", "הערה", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dr == DialogResult.No)
                    {
                        Break = true;
                    }

                    if (dr == DialogResult.Yes)
                    {
                        bool ans = true, ans1 = false, ans2 = false, ans3 = false;
                        string c1 = "העובדים הללו אינם מוכרים" + "\n";

                        if (textBox1.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox1.Text + "'AND Job='" + "מוכר" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans1 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 1" + "\n";
                            }
                        }

                        if (textBox2.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox2.Text + "'AND Job='" + "מוכר" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans2 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 2" + "\n";
                            }

                        }
                        if (textBox3.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox3.Text + "'AND Job='" + "מוכר" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans3 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 3" + "\n";
                            }
                        }

                        if (ans == true)
                        {
                            if ((ans1 == true) && (ans2 == true))
                            {
                                if (textBox1.Text == textBox2.Text)
                                {
                                    AnsTotal = false;
                                }
                                else
                                {
                                    //
                                }
                            }

                            //

                            if ((ans1 == true) && (ans3 == true))
                            {
                                if (textBox1.Text == textBox3.Text)
                                {
                                    AnsTotal = false;
                                }
                                else
                                {
                                    //
                                }
                            }

                            //

                            if ((ans2 == true) && (ans3 == true))
                            {
                                if (textBox2.Text == textBox3.Text)
                                {
                                    AnsTotal = false;
                                }
                                else
                                {
                                    //
                                }
                            }

                            if ((ans1 == true) && (ans2 != true) && (ans3 != true))
                            {
                                //
                            }
                            if ((ans1 != true) && (ans2 == true) && (ans3 != true))
                            {
                                //
                            }
                            if ((ans1 != true) && (ans2 != true) && (ans3 == true))
                            {
                                //
                            }


                        }
                        else
                        {
                            AnsTotal = false;
                        }

                    }

                }
            }

            //
            //

            if (Break != true)
            {

                if ((textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != ""))
                {
                    DAL DL1 = new DAL("CarCompany.accdb");

                    DataTable y1 = new DataTable();

                    y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox4.Text + "'AND Job='" + "טכנאי" + "'", y1);

                    //

                    DAL DL1x = new DAL("CarCompany.accdb");

                    DataTable y1x = new DataTable();

                    y1x = DL1x.getDataTable("select * from Workers where WorkID='" + textBox5.Text + "'AND Job='" + "טכנאי" + "'", y1x);

                    //

                    DAL DL1xx = new DAL("CarCompany.accdb");

                    DataTable y1xx = new DataTable();

                    y1xx = DL1xx.getDataTable("select * from Workers where WorkID='" + textBox6.Text + "'AND Job='" + "טכנאי" + "'", y1xx);

                    bool ans = true;
                    string c1 = "העובדים הללו אינם טכנאיים" + "\n";

                    try
                    {
                        if (!y1.Rows[0][0].Equals(null))
                        {
                            //
                        }
                    }
                    catch
                    {
                        ans = false;
                        c1 += "עובד 1" + "\n";
                    }

                    try
                    {
                        if (!y1x.Rows[0][0].Equals(null))
                        {
                            //
                        }
                    }
                    catch
                    {
                        ans = false;
                        c1 += "עובד 2" + "\n";
                    }

                    try
                    {
                        if (!y1xx.Rows[0][0].Equals(null))
                        {
                            //
                        }
                    }
                    catch
                    {
                        ans = false;
                        c1 += "עובד 3" + "\n";
                    }

                    bool ans1 = true;

                    if ((textBox4.Text == textBox5.Text) || (textBox5.Text == textBox6.Text) || (textBox4.Text == textBox6.Text))
                    {
                        ans1 = false;
                    }

                    if (ans == true)
                    {
                        if (ans1 == false)
                        {
                            AnsTotal = false;
                        }
                        else
                        {
                            //
                        }
                    }
                    else
                    {
                        if (ans1 == false)
                        {
                            AnsTotal = false;
                        }
                        AnsTotal = false;
                    }
                }

                else
                {
                    if ((textBox4.Text == "") && (textBox5.Text == "") && (textBox6.Text == ""))
                    {
                        AnsTotal = false;
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("לא כל שדות הטכנאיים מלאות. האם אתה בטוח שברצונך להוסיף פחות משלושה טכנאיים לאותו היום? (יש אפשרות להוסיף עובדים נוספים בטופס העריכה)", "הערה", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                        if (dr == DialogResult.No)
                        {
                            Break = true;
                        }
                        
                        if (dr == DialogResult.Yes)
                        {
                            bool ans = true, ans1 = false, ans2 = false, ans3 = false;
                            string c1 = "העובדים הללו אינם טכנאיים" + "\n";

                            if (textBox4.Text != "")
                            {
                                DAL DL1 = new DAL("CarCompany.accdb");

                                DataTable y1 = new DataTable();

                                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox4.Text + "'AND Job='" + "טכנאי" + "'", y1);

                                try
                                {
                                    if (!y1.Rows[0][0].Equals(null))
                                    {
                                        ans1 = true;
                                    }
                                }
                                catch
                                {
                                    ans = false;
                                    c1 += "עובד 1" + "\n";
                                }
                            }

                            if (textBox5.Text != "")
                            {
                                DAL DL1 = new DAL("CarCompany.accdb");

                                DataTable y1 = new DataTable();

                                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox5.Text + "'AND Job='" + "טכנאי" + "'", y1);

                                try
                                {
                                    if (!y1.Rows[0][0].Equals(null))
                                    {
                                        ans2 = true;
                                    }
                                }
                                catch
                                {
                                    ans = false;
                                    c1 += "עובד 2" + "\n";
                                }

                            }
                            if (textBox6.Text != "")
                            {
                                DAL DL1 = new DAL("CarCompany.accdb");

                                DataTable y1 = new DataTable();

                                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox6.Text + "'AND Job='" + "טכנאי" + "'", y1);

                                try
                                {
                                    if (!y1.Rows[0][0].Equals(null))
                                    {
                                        ans3 = true;
                                    }
                                }
                                catch
                                {
                                    ans = false;
                                    c1 += "עובד 3" + "\n";
                                }
                            }

                            if (ans == true)
                            {
                                if ((ans1 == true) && (ans2 == true))
                                {
                                    if (textBox4.Text == textBox5.Text)
                                    {
                                        AnsTotal = false;
                                    }
                                    else
                                    {
                                        //
                                    }
                                }

                                //

                                if ((ans1 == true) && (ans3 == true))
                                {
                                    if (textBox4.Text == textBox6.Text)
                                    {
                                        AnsTotal = false;
                                    }
                                    else
                                    {
                                        //
                                    }
                                }

                                //

                                if ((ans2 == true) && (ans3 == true))
                                {
                                    if (textBox5.Text == textBox6.Text)
                                    {
                                        AnsTotal = false;
                                    }
                                    else
                                    {
                                        //
                                    }
                                }

                                if ((ans1 == true) && (ans2 != true) && (ans3 != true))
                                {
                                    //
                                }
                                if ((ans1 != true) && (ans2 == true) && (ans3 != true))
                                {
                                    //
                                }
                                if ((ans1 != true) && (ans2 != true) && (ans3 == true))
                                {
                                    //
                                }


                            }
                            else
                            {
                                AnsTotal = false;
                            }

                        }

                    }
                }
            }

            //
            //

            if (Break != true)
            {

                if ((textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != ""))
                {
                    DAL DL1 = new DAL("CarCompany.accdb");

                    DataTable y1 = new DataTable();

                    y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox7.Text + "'AND Job='" + "מזכירות" + "'", y1);

                    //

                    DAL DL1x = new DAL("CarCompany.accdb");

                    DataTable y1x = new DataTable();

                    y1x = DL1x.getDataTable("select * from Workers where WorkID='" + textBox8.Text + "'AND Job='" + "מזכירות" + "'", y1x);

                    //

                    DAL DL1xx = new DAL("CarCompany.accdb");

                    DataTable y1xx = new DataTable();

                    y1xx = DL1xx.getDataTable("select * from Workers where WorkID='" + textBox9.Text + "'AND Job='" + "מזכירות" + "'", y1xx);

                    bool ans = true;
                    string c1 = "העובדים הללו אינם במזכירות" + "\n";

                    try
                    {
                        if (!y1.Rows[0][0].Equals(null))
                        {
                            //
                        }
                    }
                    catch
                    {
                        ans = false;
                        c1 += "עובד 1" + "\n";
                    }

                    try
                    {
                        if (!y1x.Rows[0][0].Equals(null))
                        {
                            //
                        }
                    }
                    catch
                    {
                        ans = false;
                        c1 += "עובד 2" + "\n";
                    }

                    try
                    {
                        if (!y1xx.Rows[0][0].Equals(null))
                        {
                            //
                        }
                    }
                    catch
                    {
                        ans = false;
                        c1 += "עובד 3" + "\n";
                    }

                    bool ans1 = true;

                    if ((textBox7.Text == textBox8.Text) || (textBox8.Text == textBox9.Text) || (textBox7.Text == textBox9.Text))
                    {
                        ans1 = false;
                    }

                    if (ans == true)
                    {
                        if (ans1 == false)
                        {
                            AnsTotal = false;
                        }
                        else
                        {
                            //
                        }
                    }
                    else
                    {
                        if (ans1 == false)
                        {
                            AnsTotal = false;
                        }
                        AnsTotal = false;
                    }
                }

                else
                {
                    if ((textBox7.Text == "") && (textBox8.Text == "") && (textBox9.Text == ""))
                    {
                        AnsTotal = false;
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("לא כל שדות עובדי המזכירות מלאות. האם אתה בטוח שברצונך להוסיף פחות משלושה עובדי מזכירות לאותו היום? (יש אפשרות להוסיף עובדים נוספים בטופס העריכה)", "הערה", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                        if (dr == DialogResult.No)
                        {
                            Break = true;
                        }

                        if (dr == DialogResult.Yes)
                        {
                            bool ans = true, ans1 = false, ans2 = false, ans3 = false;
                            string c1 = "העובדים הללו אינם עובדי מזכירות" + "\n";

                            if (textBox7.Text != "")
                            {
                                DAL DL1 = new DAL("CarCompany.accdb");

                                DataTable y1 = new DataTable();

                                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox7.Text + "'AND Job='" + "מזכירות" + "'", y1);

                                try
                                {
                                    if (!y1.Rows[0][0].Equals(null))
                                    {
                                        ans1 = true;
                                    }
                                }
                                catch
                                {
                                    ans = false;
                                    c1 += "עובד 1" + "\n";
                                }
                            }

                            if (textBox8.Text != "")
                            {
                                DAL DL1 = new DAL("CarCompany.accdb");

                                DataTable y1 = new DataTable();

                                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox8.Text + "'AND Job='" + "מזכירות" + "'", y1);

                                try
                                {
                                    if (!y1.Rows[0][0].Equals(null))
                                    {
                                        ans2 = true;
                                    }
                                }
                                catch
                                {
                                    ans = false;
                                    c1 += "עובד 2" + "\n";
                                }

                            }
                            if (textBox9.Text != "")
                            {
                                DAL DL1 = new DAL("CarCompany.accdb");

                                DataTable y1 = new DataTable();

                                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox9.Text + "'AND Job='" + "מזכירות" + "'", y1);

                                try
                                {
                                    if (!y1.Rows[0][0].Equals(null))
                                    {
                                        ans3 = true;
                                    }
                                }
                                catch
                                {
                                    ans = false;
                                    c1 += "עובד 3" + "\n";
                                }
                            }

                            if (ans == true)
                            {
                                if ((ans1 == true) && (ans2 == true))
                                {
                                    if (textBox7.Text == textBox8.Text)
                                    {
                                        AnsTotal = false;
                                    }
                                    else
                                    {
                                        //
                                    }
                                }

                                //

                                if ((ans1 == true) && (ans3 == true))
                                {
                                    if (textBox7.Text == textBox9.Text)
                                    {
                                        AnsTotal = false;
                                    }
                                    else
                                    {
                                        //
                                    }
                                }

                                //

                                if ((ans2 == true) && (ans3 == true))
                                {
                                    if (textBox8.Text == textBox9.Text)
                                    {
                                        AnsTotal = false;
                                    }
                                    else
                                    {
                                        //
                                    }
                                }

                                if ((ans1 == true) && (ans2 != true) && (ans3 != true))
                                {
                                    //
                                }
                                if ((ans1 != true) && (ans2 == true) && (ans3 != true))
                                {
                                    //
                                }
                                if ((ans1 != true) && (ans2 != true) && (ans3 == true))
                                {
                                    //
                                }


                            }
                            else
                            {
                                AnsTotal = false;
                            }

                        }

                    }
                }

            }

            //
            //

            if (Break != true)
            {

                if (AnsTotal == false)
                {
                    MessageBox.Show("הנתונים שהוכנסו באחד או יותר מן השדות שגויים. בדוק בעזרת כפתורי הבדיקה איכן הטעות או הטעויות", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("מערכת המשמרות הוכנסה למערכת בהצלחה", "הפעולה הצליחה", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DAL DL1 = new DAL("CarCompany.accdb");

                    DataTable y1 = new DataTable();

                    y1 = DL1.getDataTable("select * from Days where Day_Name='" + comboBox2.Text + "'", y1);

                    if (textBox1.Text != "")
                    {
                        DAL DL = new DAL("CarCompany.accdb");
                        string sql = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox1.Text + "', '" + y1.Rows[0][0].ToString() + "','" + comboBox1.Text + "','" + "מוכר" + "')";
                        DL.Insert(sql);
                    }

                    if (textBox2.Text != "")
                    {
                        DAL DL2 = new DAL("CarCompany.accdb");
                        string sql2 = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox2.Text + "', '" + y1.Rows[0][0].ToString() + "','" + comboBox1.Text + "','" + "מוכר" + "')";
                        DL2.Insert(sql2);
                    }

                    if (textBox3.Text != "")
                    {
                        DAL DL3 = new DAL("CarCompany.accdb");
                        string sql3 = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox3.Text + "', '" + y1.Rows[0][0].ToString() + "','" + comboBox1.Text + "','" + "מוכר" + "')";
                        DL3.Insert(sql3);
                    }

                    if (textBox4.Text != "")
                    {
                        DAL DL4 = new DAL("CarCompany.accdb");
                        string sql4 = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox4.Text + "', '" + y1.Rows[0][0].ToString() + "','" + comboBox1.Text + "','" + "טכנאי" + "')";
                        DL4.Insert(sql4);
                    }

                    if (textBox5.Text != "")
                    {
                        DAL DL5 = new DAL("CarCompany.accdb");
                        string sql5 = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox5.Text + "', '" + y1.Rows[0][0].ToString() + "','" + comboBox1.Text + "','" + "טבנאי" + "')";
                        DL5.Insert(sql5);
                    }

                    if (textBox6.Text != "")
                    {
                        DAL DL6 = new DAL("CarCompany.accdb");
                        string sql6 = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox6.Text + "', '" + y1.Rows[0][0].ToString() + "','" + comboBox1.Text + "','" + "טכנאי" + "')";
                        DL6.Insert(sql6);
                    }

                    if (textBox7.Text != "")
                    {
                        DAL DL7 = new DAL("CarCompany.accdb");
                        string sql7 = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox7.Text + "', '" + y1.Rows[0][0].ToString() + "','" + comboBox1.Text + "','" + "מזכירות" + "')";
                        DL7.Insert(sql7);
                    }

                    if (textBox8.Text != "")
                    {
                        DAL DL8 = new DAL("CarCompany.accdb");
                        string sql8 = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox8.Text + "', '" + y1.Rows[0][0].ToString() + "','" + comboBox1.Text + "','" + "מזכירות" + "')";
                        DL8.Insert(sql8);
                    }

                    if (textBox9.Text != "")
                    {
                        DAL DL9 = new DAL("CarCompany.accdb");
                        string sql9 = "INSERT INTO TimeList (WorkID,D_Num,TL_Week,Job) VALUES ('" + textBox9.Text + "', '" + y1.Rows[0][0].ToString() + "','" + comboBox1.Text + "','" + "מזכירות" + "')";
                        DL9.Insert(sql9);
                    }
                }
            }
            else
            {
                MessageBox.Show("הפעולה הופסקה", "הפעולה נחסמה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeListI TL = new TimeListI();
            TL.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WorkersSearch WS = new WorkersSearch();
            WS.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if ((comboBox1.Text != "") && (comboBox2.Text != "") && (int.Parse(comboBox1.Text) < 55) && (int.Parse(comboBox1.Text) > 0))
            {

                try
                {

                    DAL DL1 = new DAL("CarCompany.accdb");

                    DataTable y1 = new DataTable();

                    y1 = DL1.getDataTable("select * from Days where Day_Name='" + comboBox2.Text + "'", y1);


                    DAL DL = new DAL("CarCompany.accdb");

                    DataTable y = new DataTable();

                    y = DL.getDataTable("select * from TimeList where D_Num='" + y1.Rows[0][1].ToString() + "' AND TL_Week='" + comboBox1.Text + "'", y);

                    try
                    {
                        if (!y.Rows[0][0].Equals(null))
                        {
                            MessageBox.Show("לשדה זה יש מערכת משמרות בנויה", "הערה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    catch
                    {
                        MessageBox.Show("לשדה זה אין מערכת משמרות בנויה", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                catch
                {
                    MessageBox.Show("יתכן וכי מספר היום שהוכנס אינו תקין", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים או שהם שגויים", "הפעולה נכשלה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                DAL DL1 = new DAL("CarCompany.accdb");

                DataTable y1 = new DataTable();

                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox1.Text + "'AND Job='" + "מוכר" + "'", y1);

                //

                DAL DL1x = new DAL("CarCompany.accdb");

                DataTable y1x = new DataTable();

                y1x = DL1x.getDataTable("select * from Workers where WorkID='" + textBox2.Text + "'AND Job='" + "מוכר" + "'", y1x);

                //

                DAL DL1xx = new DAL("CarCompany.accdb");

                DataTable y1xx = new DataTable();

                y1xx = DL1xx.getDataTable("select * from Workers where WorkID='" + textBox3.Text + "'AND Job='" + "מוכר" + "'", y1xx);

                bool ans = true;
                string c1 = "העובדים הללו אינם מוכרים" + "\n";

                try
                {
                    if (!y1.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 1" + "\n";
                }

                try
                {
                    if (!y1x.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 2" + "\n";
                }

                try
                {
                    if (!y1xx.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 3" + "\n";
                }

                bool ans1 = true;

                if ((textBox1.Text == textBox2.Text) || (textBox2.Text == textBox3.Text) || (textBox1.Text == textBox3.Text))
                {
                    ans1 = false;
                }

                if (ans == true)
                {
                    if (ans1 == false)
                    {
                        MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("השדות שהוכנסו תחת מוכרים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (ans1 == false)
                    {
                        MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show(c1, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                if ((textBox1.Text == "") && (textBox2.Text == "") && (textBox3.Text == ""))
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("לא כל שדות המוכרים מלאות. האם אתה בטוח שברצונך לבדוק פחות משלושה מוכרים לאותו היום? (יש אפשרות להוסיף עובדים נוספים בטופס העריכה)", "הערה", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dr == DialogResult.Yes)
                    {
                        bool ans = true, ans1 = false, ans2 = false, ans3 = false;
                        string c1 = "העובדים הללו אינם מוכרים" + "\n";

                        if (textBox1.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox1.Text + "'AND Job='" + "מוכר" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans1 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 1" + "\n";
                            }
                        }

                        if (textBox2.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox2.Text + "'AND Job='" + "מוכר" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans2 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 2" + "\n";
                            }

                        }
                        if (textBox3.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox3.Text + "'AND Job='" + "מוכר" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans3 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 3" + "\n";
                            }
                        }

                        if (ans == true)
                        {
                            if ((ans1 == true) && (ans2 == true))
                            {
                                if (textBox1.Text == textBox2.Text)
                                {
                                    MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("השדות שהוכנסו תחת מוכרים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            //

                            if ((ans1 == true) && (ans3 == true))
                            {
                                if (textBox1.Text == textBox3.Text)
                                {
                                    MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("השדות שהוכנסו תחת מוכרים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            //

                            if ((ans2 == true) && (ans3 == true))
                            {
                                if (textBox2.Text == textBox3.Text)
                                {
                                    MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("השדות שהוכנסו תחת מוכרים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            if ((ans1 == true) && (ans2 != true) && (ans3 != true))
                            {
                                MessageBox.Show("השדות שהוכנסו תחת מוכרים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if ((ans1 != true) && (ans2 == true) && (ans3 != true))
                            {
                                MessageBox.Show("השדות שהוכנסו תחת מוכרים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if ((ans1 != true) && (ans2 != true) && (ans3 == true))
                            {
                                MessageBox.Show("השדות שהוכנסו תחת מוכרים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }
                        else
                        {
                            MessageBox.Show(c1, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != ""))
            {
                DAL DL1 = new DAL("CarCompany.accdb");

                DataTable y1 = new DataTable();

                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox4.Text + "'AND Job='" + "טכנאי" + "'", y1);

                //

                DAL DL1x = new DAL("CarCompany.accdb");

                DataTable y1x = new DataTable();

                y1x = DL1x.getDataTable("select * from Workers where WorkID='" + textBox5.Text + "'AND Job='" + "טכנאי" + "'", y1x);

                //

                DAL DL1xx = new DAL("CarCompany.accdb");

                DataTable y1xx = new DataTable();

                y1xx = DL1xx.getDataTable("select * from Workers where WorkID='" + textBox6.Text + "'AND Job='" + "טכנאי" + "'", y1xx);

                bool ans = true;
                string c1 = "העובדים הללו אינם טכנאיים" + "\n";

                try
                {
                    if (!y1.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 1" + "\n";
                }

                try
                {
                    if (!y1x.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 2" + "\n";
                }

                try
                {
                    if (!y1xx.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 3" + "\n";
                }

                bool ans1 = true;

                if ((textBox4.Text == textBox5.Text) || (textBox5.Text == textBox6.Text) || (textBox4.Text == textBox6.Text))
                {
                    ans1 = false;
                }

                if (ans == true)
                {
                    if (ans1 == false)
                    {
                        MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("השדות שהוכנסו תחת טכנאיים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (ans1 == false)
                    {
                        MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show(c1, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                if ((textBox4.Text == "") && (textBox5.Text == "") && (textBox6.Text == ""))
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("לא כל שדות הטכנאיים מלאות. האם אתה בטוח שברצונך לבדוק פחות משלושה טכנאיים לאותו היום? (יש אפשרות להוסיף עובדים נוספים בטופס העריכה)", "הערה", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dr == DialogResult.Yes)
                    {
                        bool ans = true, ans1 = false, ans2 = false, ans3 = false;
                        string c1 = "העובדים הללו אינם טכנאיים" + "\n";

                        if (textBox4.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox4.Text + "'AND Job='" + "טכנאי" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans1 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 1" + "\n";
                            }
                        }

                        if (textBox5.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox5.Text + "'AND Job='" + "טכנאי" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans2 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 2" + "\n";
                            }

                        }
                        if (textBox6.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox6.Text + "'AND Job='" + "טכנאי" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans3 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 3" + "\n";
                            }
                        }

                        if (ans == true)
                        {
                            if ((ans1 == true) && (ans2 == true))
                            {
                                if (textBox4.Text == textBox5.Text)
                                {
                                    MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("השדות שהוכנסו תחת טכנאיים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            //

                            if ((ans1 == true) && (ans3 == true))
                            {
                                if (textBox4.Text == textBox6.Text)
                                {
                                    MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("השדות שהוכנסו תחת טכנאיים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            //

                            if ((ans2 == true) && (ans3 == true))
                            {
                                if (textBox5.Text == textBox6.Text)
                                {
                                    MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("השדות שהוכנסו תחת טכנאיים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            if ((ans1 == true) && (ans2 != true) && (ans3 != true))
                            {
                                MessageBox.Show("השדות שהוכנסו תחת טכנאיים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if ((ans1 != true) && (ans2 == true) && (ans3 != true))
                            {
                                MessageBox.Show("השדות שהוכנסו תחת טכנאיים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if ((ans1 != true) && (ans2 != true) && (ans3 == true))
                            {
                                MessageBox.Show("השדות שהוכנסו תחת טכנאיים תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }
                        else
                        {
                            MessageBox.Show(c1, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if ((textBox7.Text != "") && (textBox8.Text != "") && (textBox9.Text != ""))
            {
                DAL DL1 = new DAL("CarCompany.accdb");

                DataTable y1 = new DataTable();

                y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox7.Text + "'AND Job='" + "מזכירות" + "'", y1);

                //

                DAL DL1x = new DAL("CarCompany.accdb");

                DataTable y1x = new DataTable();

                y1x = DL1x.getDataTable("select * from Workers where WorkID='" + textBox8.Text + "'AND Job='" + "מזכירות" + "'", y1x);

                //

                DAL DL1xx = new DAL("CarCompany.accdb");

                DataTable y1xx = new DataTable();

                y1xx = DL1xx.getDataTable("select * from Workers where WorkID='" + textBox9.Text + "'AND Job='" + "מזכירות" + "'", y1xx);

                bool ans = true;
                string c1 = "העובדים הללו אינם במזכירות" + "\n";

                try
                {
                    if (!y1.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 1" + "\n";
                }

                try
                {
                    if (!y1x.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 2" + "\n";
                }

                try
                {
                    if (!y1xx.Rows[0][0].Equals(null))
                    {
                        //
                    }
                }
                catch
                {
                    ans = false;
                    c1 += "עובד 3" + "\n";
                }

                bool ans1 = true;

                if ((textBox7.Text == textBox8.Text) || (textBox8.Text == textBox9.Text) || (textBox7.Text == textBox9.Text))
                {
                    ans1 = false;
                }

                if (ans == true)
                {
                    if (ans1 == false)
                    {
                        MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("השדות שהוכנסו תחת מזכירות תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (ans1 == false)
                    {
                        MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    MessageBox.Show(c1, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                if ((textBox7.Text == "") && (textBox8.Text == "") && (textBox9.Text == ""))
                {
                    MessageBox.Show("יתכן וכי לא מילאת את כל השדות המבוקשים", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult dr = MessageBox.Show("לא כל שדות עובדי המזכירות מלאות. האם אתה בטוח שברצונך לבדוק פחות משלושה עובדי מזכירות לאותו היום? (יש אפשרות להוסיף עובדים נוספים בטופס העריכה)", "הערה", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dr == DialogResult.Yes)
                    {
                        bool ans = true, ans1 = false, ans2 = false, ans3 = false;
                        string c1 = "העובדים הללו אינם עובדי מזכירות" + "\n";

                        if (textBox7.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox7.Text + "'AND Job='" + "מזכירות" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans1 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 1" + "\n";
                            }
                        }

                        if (textBox8.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox8.Text + "'AND Job='" + "מזכירות" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans2 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 2" + "\n";
                            }

                        }
                        if (textBox9.Text != "")
                        {
                            DAL DL1 = new DAL("CarCompany.accdb");

                            DataTable y1 = new DataTable();

                            y1 = DL1.getDataTable("select * from Workers where WorkID='" + textBox9.Text + "'AND Job='" + "מזכירות" + "'", y1);

                            try
                            {
                                if (!y1.Rows[0][0].Equals(null))
                                {
                                    ans3 = true;
                                }
                            }
                            catch
                            {
                                ans = false;
                                c1 += "עובד 3" + "\n";
                            }
                        }

                        if (ans == true)
                        {
                            if ((ans1 == true) && (ans2 == true))
                            {
                                if (textBox7.Text == textBox8.Text)
                                {
                                    MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("השדות שהוכנסו תחת מזכירות תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            //

                            if ((ans1 == true) && (ans3 == true))
                            {
                                if (textBox7.Text == textBox9.Text)
                                {
                                    MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("השדות שהוכנסו תחת מזכירות תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            //

                            if ((ans2 == true) && (ans3 == true))
                            {
                                if (textBox8.Text == textBox9.Text)
                                {
                                    MessageBox.Show("המערכת אינה יכולה לקלוט אותו עובד לשתי משמרות או יותר באותו היום", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("השדות שהוכנסו תחת מזכירות תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            if ((ans1 == true) && (ans2 != true) && (ans3 != true))
                            {
                                MessageBox.Show("השדות שהוכנסו תחת מזכירות תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if ((ans1 != true) && (ans2 == true) && (ans3 != true))
                            {
                                MessageBox.Show("השדות שהוכנסו תחת מזכירות תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if ((ans1 != true) && (ans2 != true) && (ans3 == true))
                            {
                                MessageBox.Show("השדות שהוכנסו תחת מזכירות תקינים", "אישור", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }
                        else
                        {
                            MessageBox.Show(c1, "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                }
            }
        }
    }
}
