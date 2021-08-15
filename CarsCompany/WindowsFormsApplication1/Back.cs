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
    public partial class Back : Form
    {
        public Back()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void Back_Load_1(object sender, EventArgs e)
        {
            //פותח את הכניסה.            
            Open Log = new Open(); 
            Log.StartPosition = FormStartPosition.CenterScreen;
            Log.ShowDialog();
            if (Log.DialogResult == DialogResult.OK)
            {
                //
            }
            else
            {
                Close();
            }
        }
    }
}
