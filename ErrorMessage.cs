using System;
using System.Windows.Forms;

namespace coursework
{
    public partial class ErrorMessage : Form
    {
        public ErrorMessage()
        {
            InitializeComponent();
        }

        public string errorMessage;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ErrorMessage_Load(object sender, EventArgs e)
        {
            label1.Text = errorMessage;
        }
    }
}
