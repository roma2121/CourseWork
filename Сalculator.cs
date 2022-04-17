using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coursework
{
    public partial class Сalculator : Form
    {
        public Сalculator()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            try
            {
                equation_textBox.Text = File.ReadLines(filename).Skip(0).First();
                minBorder.Text = File.ReadLines(filename).Skip(1).First();
                maxBorder.Text = File.ReadLines(filename).Skip(2).First();

                MessageBox.Show("Файл открыт");
            }
            catch
            {
                MessageBox.Show("Данные в файле некорректны!");
                equation_textBox.Clear();
                minBorder.Clear();
                maxBorder.Clear();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            using (StreamWriter file = new StreamWriter(filename, true, Encoding.Default))
            {
                file.WriteLine(equation_textBox.Text);
                file.WriteLine(minBorder.Text);
                file.WriteLine(maxBorder.Text);
                file.Close();
            }
            MessageBox.Show("Файл сохранён");
        }

        private void сохранитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zedGraphControl1.SaveAs(saveFileDialog1.FileName);
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            equation_textBox.Clear();
            minBorder.Clear();
            maxBorder.Clear();

            equationText.Clear();
            indexText = 0;
        }

        private void adding_equation_text()
        {
            equation_textBox.Clear();

            for (int i = 0; i < equationText.Count; i++)
            {
                equation_textBox.Text = equation_textBox.Text + equationText[i];
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (equationText.Count > 0)
            {
                equationText.Remove(equationText.Last());
                indexText--;
                adding_equation_text();
            }
        }

        List<string> equationText = new List<string>();
        int indexText = -1;

        private void various_symbols_Click(object sender, EventArgs e)
        {
            indexText++;
            Button B = (Button)sender;
            equationText.Add(B.Text);

            adding_equation_text();
        }

        private void sqrt_Click(object sender, EventArgs e)
        {
            indexText++;
            Button B = (Button)sender;
            equationText.Add("sqrt");

            adding_equation_text();
        }

        private void x_Click(object sender, EventArgs e)
        {
            indexText++;
            Button B = (Button)sender;
            equationText.Add("(x)");

            adding_equation_text();
        }

        private void divide_Click(object sender, EventArgs e)
        {
            indexText++;
            Button B = (Button)sender;
            equationText.Add("/");

            adding_equation_text();
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            indexText++;
            Button B = (Button)sender;
            equationText.Add("*");

            adding_equation_text();
        }

        private void square_Click(object sender, EventArgs e)
        {
            indexText++;
            Button B = (Button)sender;
            equationText.Add("^2");

            adding_equation_text();
        }

        private void cube_Click(object sender, EventArgs e)
        {
            indexText++;
            Button B = (Button)sender;
            equationText.Add("^3");

            adding_equation_text();
        }

        private void degree_Click(object sender, EventArgs e)
        {
            indexText++;
            Button B = (Button)sender;
            equationText.Add("^");

            adding_equation_text();
        }
    }
}
