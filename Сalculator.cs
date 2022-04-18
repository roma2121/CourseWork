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

using ZedGraph;
using AngouriMath;

namespace coursework
{
    public partial class Сalculator : Form
    {
        public Сalculator()
        {
            InitializeComponent();
            timer1.Enabled = true;
            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraph_PointValueEvent);
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
            if (equationText[indexText - 1] == "(")
                equationText.Add("x");
            else
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

        private void CheckingEquation()
        {
            try
            {
                Entity expr = equation_textBox.Text;

                double Xmin = 0, Xmax = 0, Step = 0;
                Xmin = double.Parse(minBorder.Text);
                Xmax = double.Parse(maxBorder.Text);
                var numberPoints = (int)Math.Ceiling((Xmax - Xmin) / 0.1) + 1;

                int i = 0;
                double[,] arrayPoints = new double[numberPoints, 2];
                CalculationPoint(Xmin, ref Xmax, ref numberPoints, ref expr, ref arrayPoints, i);

                painting(ref arrayPoints, ref numberPoints, ref expr);

                expr = Convert.ToString(expr.Differentiate("x"));

                textBox1.Text = "f '(x) = " + Convert.ToString(expr);
                textBox1.Text += Environment.NewLine + Convert.ToString(expr) + " = 0";
                Entity expr2 = $"{expr} = 0";
                textBox1.Text += Environment.NewLine + Convert.ToString(expr.SolveEquation("x"));

            }
            catch
            {
                equation_textBox.Clear();
                MessageBox.Show("Уравнение введено неверно!");
            }
        }
        private void calculation_Click(object sender, EventArgs e)
        {
            CheckingEquation();
        }

        private void CalculationPoint(double Xmin, ref double Xmax, ref int numberPoints, ref Entity expr, ref double[,] arrayPoints, int i)
        {
            if (i == numberPoints)
                return;
            
            var subs = expr.Substitute("x", Xmin);

            arrayPoints[i, 0] = Math.Round((Xmin), 1);
            arrayPoints[i, 1] = (double)(subs.EvalNumerical());

            i++;
            Xmin = Xmin + 0.1;

            CalculationPoint(Xmin, ref Xmax, ref numberPoints, ref expr, ref arrayPoints, i);
        }

        public void painting(ref double[,] arrayPoints, ref int numberPoints, ref Entity expr)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            PointPairList list = new PointPairList();
            pane.XAxis.Title.Text = "Ось X";
            pane.YAxis.Title.Text = "Ось Y";
            pane.Title.Text = "График функции";

            // Добавляем вычисленные значения в графики
            for (int i = 0; i < numberPoints; i++)
            {
                list.Add(arrayPoints[i, 0], arrayPoints[i, 1]);
            }

            LineItem myCurve = pane.AddCurve($"{expr}", list, Color.Red, SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        string zedGraph_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            // Получим точку, около которой находимся
            PointPair point = curve[iPt];
            // Сформируем строку
            string result = string.Format("X: {0:F3}\nY: {1:F3}", point.X, point.Y);
            return result;
        }
    }
}
