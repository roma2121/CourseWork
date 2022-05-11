using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using AngouriMath;

using System.Diagnostics;

namespace coursework
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
            timer1.Enabled = true;
            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraph_PointValueEvent);
        }

        Stopwatch sw = new Stopwatch();

        string zedGraph_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            // Получим точку, около которой находимся
            PointPair point = curve[iPt];
            // Сформируем строку
            string result = string.Format("X: {0:F3}\nY: {1:F3}", point.X, point.Y);
            return result;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss dddd");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            try
            {
                equation_textBox.Text = File.ReadLines(filename).Skip(0).First();
                equationText.Add(equation_textBox.Text);
                indexText = 0;
                minBorder.Text = File.ReadLines(filename).Skip(1).First();
                maxBorder.Text = File.ReadLines(filename).Skip(2).First();

                MessageBox.Show("Файл открыт");
            }
            catch
            {
                clearField_buttom_Click(sender, e);
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
            indexText = -1;
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
            if (indexText > -1)
            {
                indexText--;
                equationText.RemoveAt(equationText.Count - 1);
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
            Button B = (Button)sender;
            if (equationText.Count != 0 && equationText[indexText] == "(")
                equationText.Add("x");
            else
                equationText.Add("(x)");
            indexText++;
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

        private void minBorder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                maxBorder.Focus();
            }
        }

        private void maxBorder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button37.Focus();
            }
        }

        private void Сalculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                clearField_button.Focus();
            }
        }

        private void PrintProgressSolution(Entity expr)
        {
            textBox1.Text = "f '(x) = " + Convert.ToString(expr);
            textBox1.Text += Environment.NewLine + Convert.ToString(expr) + " = 0";
            textBox1.Text += Environment.NewLine + Convert.ToString(expr.SolveEquation("x"));
        }

        async private void CheckingEquation()
        {
            try
            {
                equation_comboBox.Items.Add(equation_textBox.Text);
                equation_comboBox.Update();

                Entity expr;
                double Xmin, Xmax;
                int numberPoints;
                float accuracy;

                DataReader datareader = new DataReader(this);
                datareader.ReadingBoundaries(out Xmin, out Xmax, out numberPoints, out accuracy);
                datareader.ReadingEquation(out expr);

                Entity equationY = expr;

                expr = Convert.ToString(expr.Differentiate("x"));
                var subs = (expr.Substitute("x", Xmin)).EvalNumerical();

                toolStripProgressBar1.Maximum = numberPoints;
                toolStripProgressBar1.Value = 0;
                var progress = new Progress<int>(percent =>
                {
                    toolStripProgressBar1.Value = percent;
                });

                List<double> arrayPoints = new List<double>();

                sw.Restart();
                sw.Start();
                Estimator estimator = new Estimator(this);
                await Task.Run(() => estimator.CalculationPoint(Xmin, ref numberPoints, ref equationY, ref arrayPoints, ref accuracy, progress) );

                PrintProgressSolution(expr);

                List<double> arrayRoot = new List<double>();
                await Task.Run(() => estimator.RootSelection(ref Xmin, ref Xmax, ref expr, ref equationY, ref arrayRoot) );
                sw.Stop();
                textBox2.Text = sw.Elapsed.ToString();

                Draftsman draftsman = new Draftsman(this);
                draftsman.painting(ref arrayPoints, ref numberPoints, ref equationY, ref arrayRoot);

                toolStripProgressBar1.Value = 0;

                GC.Collect();
            }
            catch (Exception ex)
            { 
                if (ex.Message != "Левая граница введена неверно!" && ex.Message != "Правая граница введена неверно!" && ex.Message != "Диапазон значений слишком велик!" && ex.Message != "Левая граница больше правой!")
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.errorMessage = "Функция введена неверно!";
                    errorMessage.ShowDialog();

                    equation_textBox.Clear();
                    equationText.Clear();
                    indexText = -1;
                }
                else
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.errorMessage = ex.Message;
                    errorMessage.ShowDialog();
                }
                toolStripProgressBar1.Value = 0;
            }
        }

        private void calculation_Click(object sender, EventArgs e)
        {
            CheckingEquation();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Information informationForm = new Information();
            informationForm.inf = 101;
            informationForm.Show();
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Information informationForm = new Information();
            informationForm.inf = 202;
            informationForm.Show();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearField_buttom_Click(object sender, EventArgs e)
        {
            indexText = -1;
            minBorder.Clear();
            maxBorder.Clear();
            equationText.Clear();
            equation_textBox.Clear();
            textBox1.Clear();
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.Invalidate();
        }

        private void equation_comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (equation_comboBox.Items.Count != 0)
            {
                indexText = -1;
                equation_textBox.Text = equation_comboBox.SelectedItem.ToString();
                equationText.Add(equation_textBox.Text);
            }
        }
    }
}