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

        public string UserName { get; set; }

        public Form2()
        {
            InitializeComponent();
     
        }

        public Form2(string UserName)
        {
            this.UserName = UserName;
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

            string UserName = txtName.Text;

            if(String.IsNullOrWhiteSpace(UserName))
            {
                MessageBox.Show("Please Enter a Player Name!");
            }
            else
            {
                MessageBox.Show($"Welcome{ txtName.Text}");
            Form1 f1 = new Form1();
            Form2 f2 = new Form2();
            {
                f1.Show(this);
                f2.Hide();

            }
            txtName.Text = UserName;
            }

        }

        public void PlayerName()
        {
            
            
        }
    }
}
