using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPS_Winform
{
    public partial class Form2 : Form
    {

        public static string userName;

        public Form2()
        {
            InitializeComponent();

            txtName.Text = userName;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Welcome{ txtName.Text}");
            Form1 f1 = new Form1();
            Form2 f2 = new Form2();
            {
                f1.Show(this);
                f2.Hide();

            }
            

        }
    }
}
