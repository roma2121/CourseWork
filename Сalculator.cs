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
using System.Text.RegularExpressions;

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
                indexText--;
                equationText.Remove(equationText.Last());
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
            if (equationText.Count != 0 && equationText[indexText - 1] == "(")
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

        private void ReadingBoundaries(ref double Xmin, ref double Xmax)
        {
            Xmin = double.Parse(minBorder.Text);
            Xmax = double.Parse(maxBorder.Text);
            if (Xmin + Xmax > 2000)
            {
                minBorder.Text = null;
                maxBorder.Text = null;
                throw new Exception("Диапазон значений слишком велик!");
            }
        }

        private void ReadingEquation(out Entity expr)
        {
            expr = equation_textBox.Text;
        }

        private void CheckingEquation()
        {
            try
            {
                Entity expr;
                double Xmin = 0, Xmax = 0, Step = 0;

                ReadingBoundaries(ref Xmin, ref Xmax);
                ReadingEquation(out expr);

                Entity equationY = expr;



                var numberPoints = (int)Math.Ceiling((Xmax - Xmin) / 0.5) + 1;

                int countPoints = 0;
                double[,] arrayPoints = new double[numberPoints, 2];
                CalculationPoint(Xmin, ref Xmax, ref numberPoints, ref expr, ref arrayPoints, countPoints);


                expr = Convert.ToString(expr.Differentiate("x"));

                textBox1.Text = "f '(x) = " + Convert.ToString(expr);
                textBox1.Text += Environment.NewLine + Convert.ToString(expr) + " = 0";
                Entity expr2 = $"{expr} = 0";
                textBox1.Text += Environment.NewLine + Convert.ToString(expr.SolveEquation("x"));



                //отбор корней начало 
                string test1 = Convert.ToString(expr.SolveEquation("x"));
                string[] subs = test1.Split(',');
                for (int i = 0; i < subs.Length; i++)
                {

                    subs[i] = subs[i].Replace("{ ", "");
                    subs[i] = subs[i].Replace(" }", "");
                }
                //отбор корней
                double[,] arrayRoot = new double[subs.Length, 2];
                int j = 0;
                for (int i = 0; i < subs.Length; i++)
                {
                    Entity firstRoot = subs[i];
                    double x = (double)(firstRoot.EvalNumerical());
                    double y;
                    if (x >= Xmin && x <= Xmax)
                    {
                        y = (double)(equationY.Substitute("x", x)).EvalNumerical();

                        arrayRoot[j , 0] = x;
                        arrayRoot[j , 1] = y;

                        j++;
                    }
                }

                painting(ref arrayPoints, ref numberPoints, ref expr, ref arrayRoot);
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
            Xmin = Xmin + 0.5;

            CalculationPoint(Xmin, ref Xmax, ref numberPoints, ref expr, ref arrayPoints, i);
        }

        public void painting(ref double[,] arrayPoints, ref int numberPoints, ref Entity expr, ref double[,] arrayRoot)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            pane.XAxis.Title.Text = "Ось X";
            pane.YAxis.Title.Text = "Ось Y";
            pane.Title.Text = "График функции";

            // Добавляем вычисленные значения в графики
            for (int i = 0; i < numberPoints; i++)
            {
                list1.Add(arrayPoints[i, 0], arrayPoints[i, 1]);
            }
            //добавляем корни на график
            for (int i = 0; i < arrayRoot.Length / 2; i++)
            {
                list2.Add(arrayRoot[i, 0], arrayRoot[i, 1]);
            }
            LineItem myCurve1 = pane.AddCurve($"{expr}", list1, Color.Red, SymbolType.None);
            LineItem myCurve2 = pane.AddCurve("", list2, Color.Blue, SymbolType.Circle);
            myCurve2.Symbol.Fill.Type = FillType.Solid;
            myCurve2.Symbol.Size = 4;
            myCurve2.Line.IsVisible = false;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
    }
}
