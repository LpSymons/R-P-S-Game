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
        private string _userName;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Play button to start the game,
        /// this methodd also will check that a name has been 
        /// entered to proceed. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            _userName = txtName.Text;

            if (String.IsNullOrWhiteSpace(_userName))
            {
                MessageBox.Show("Please Enter a Player Name!");
            }
            else
            {
                MessageBox.Show($"Welcome " + _userName);
                Form1 f1 = new Form1(_userName);
                Form2 f2 = new Form2();

                f1.Show(this);
                f2.Hide();
            }
            txtName.Text = _userName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for playing, Ending Game now");
            this.Close();
        }
    }
}