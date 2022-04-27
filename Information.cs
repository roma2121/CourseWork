using System;
using System.Drawing;
using System.Windows.Forms;

namespace coursework
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }
        public byte inf = 0;
        
        private void Information_Load(object sender, EventArgs e)
        {
            if (inf == 101)
            {
                richTextBox1.Select(89, 39);
                richTextBox1.SelectionColor = Color.Red;

                richTextBox1.Visible = true;
                richTextBox2.Visible = false;
            }
            else
            {
                richTextBox1.Visible = false;
                richTextBox2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox2_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
