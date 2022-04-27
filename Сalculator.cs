using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using AngouriMath;

using System.Diagnostics;

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

        private void ReadingBoundaries(out double Xmin, out double Xmax, out int numberPoints, out float accuracy)
        {
            if (!double.TryParse(minBorder.Text.Replace(".", ","), out  Xmin))
            {
                minBorder.Text = null;
                minBorder.Focus();
                throw new Exception("Левая граница введена неверно!");
            }

            if (!double.TryParse(maxBorder.Text.Replace(".", ","), out Xmax))
            {
                maxBorder.Text = null;
                maxBorder.Focus();
                throw new Exception("Правая граница введена неверно!");
            }

            if (Xmin > Xmax)
            {
                minBorder.Text = null;
                minBorder.Focus();
                throw new Exception("Левая граница больше правой!");
            }

            if (Math.Abs(Xmin) + Math.Abs(Xmax) > 2000)
            {
                minBorder.Text = null;
                maxBorder.Text = null;
                throw new Exception("Диапазон значений слишком велик!");
            }

            if (Math.Abs(Xmin) + Math.Abs(Xmax) <= 200)
            {
                accuracy = 0.1f;
                numberPoints = (int)Math.Ceiling((Xmax - Xmin) / 0.1) + 1;
            }
            else if (Math.Abs(Xmin) + Math.Abs(Xmax) <= 1000)
            {
                accuracy = 0.5f;
                numberPoints = (int)Math.Ceiling((Xmax - Xmin) / 0.5) + 1;
            }
            else
            {
                accuracy = 1f;
                numberPoints = (int)Math.Ceiling((Xmax - Xmin) / 1) + 1;
            }
        }

        private void ReadingEquation(out Entity expr)
        {
            expr = equation_textBox.Text;
        }

        private void RootSelection(ref double Xmin, ref double Xmax, ref Entity expr, ref Entity equationY, ref List<double> arrayRoot)
        {
            //отбор корней начало
            string[] roots = Convert.ToString(expr.SolveEquation("x")).Split(',');

            int newCountRoots = (int)(((Math.Abs(Xmin) + Xmax) + 1) / 6.29);

            string top = Convert.ToString((expr.SolveEquation("x")));
            string equat = Convert.ToString(equationY);

            int coefficient = 0;
            for (int i = 0; i <= 10; i++)
            {
                if (equat.Contains($"{i}"))
                {
                    coefficient = i;
                }
            }

            int quantityEquat = 1;
            if (coefficient != 0)
            {
                quantityEquat = coefficient;
            }

            sbyte fun;
            byte parity;

            parity = 2;
            if (top.Contains("2 * pi * n_1"))
            {
                fun = -1;
            }
            else if (roots.Length == 1)
            {
                parity = 1;
                fun = 0;
            }
            else
            {
                fun = 1;
            }

            if (top.Contains("n_1"))
            {
                for(int i = 0; i < 2; i++)
                {
                    roots[i] = roots[i].Replace("{ ", "");
                    roots[i] = roots[i].Replace(" }", "");
                    roots[i] = roots[i].Replace("\\/", "");
                    roots[i] = roots[i].Replace("\\ ", "");
                }

                Array.Resize(ref roots, roots.Length * (newCountRoots + 2) * quantityEquat);

                for (int i = 0; i < roots.Length; i++)
                {
                    roots[i] = roots[i % parity];
                }

                int g = - 1;
                int num = (int)Math.Abs(Xmin / 6.26);
                int k;

                for (int i = 0; i < roots.Length; i++)
                {
                    g += i % parity;

                    k = -num + g + fun - (2 * coefficient);

                    roots[i] = roots[i].Replace("n_1", $"({k})");
                }
            }
            else
            {
                for (int i = 0; i < roots.Length; i++)
                {
                    roots[i] = roots[i].Replace("{ ", "");
                    roots[i] = roots[i].Replace(" }", "");
                    roots[i] = roots[i].Replace("\\/", "");
                }
            }
            try
            {
                //отбор корней
                double x;
                for (int i = 0; i < roots.Length; i++)
                {
                    Entity firstRoot = roots[i];
                    x = (double)firstRoot.EvalNumerical();
                    if (x >= Xmin & x <= Xmax)
                    {
                        arrayRoot.Add(x);
                        arrayRoot.Add((double)(equationY.Substitute("x", x)).EvalNumerical());
                    }
                }
            }
            catch
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.errorMessage = "Вычислить значения корней урвнения невозможно!";
                errorMessage.ShowDialog();
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

                ReadingBoundaries(out Xmin, out Xmax, out numberPoints, out accuracy);
                ReadingEquation(out expr);

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
                await Task.Run(() => CalculationPoint(Xmin, ref numberPoints, ref equationY, ref arrayPoints, ref accuracy, progress) );

                PrintProgressSolution(expr);

                List<double> arrayRoot = new List<double>();
                await Task.Run(() => RootSelection(ref Xmin, ref Xmax, ref expr, ref equationY, ref arrayRoot) );
                sw.Stop();
                textBox2.Text = sw.Elapsed.ToString();

                painting(ref arrayPoints, ref numberPoints, ref equationY, ref arrayRoot);

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

        private void CalculationPoint(double Xmin, ref int numberPoints, ref Entity expr, ref List<double> arrayPoints, ref float accuracy, IProgress<int> progress)
        {
            for (int i = 0; i < numberPoints; i++)
            {
                var subs = expr.Substitute("x", Xmin);

                arrayPoints.Add(Xmin);
                arrayPoints.Add((double)(subs.EvalNumerical()));

                Xmin = Math.Round((Xmin + accuracy), 2);

                if (progress != null)
                    progress.Report(i);
            }
        }

        public void painting(ref List<double> arrayPoints, ref int numberPoints, ref Entity equationY, ref List<double> arrayRoot)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            pane.XAxis.Title.Text = "Ось X";
            pane.YAxis.Title.Text = "Ось Y";
            pane.Title.Text = "График функции";
           
            string equation = equationY.ToString();
            if (equation.Contains("cotan"))
            {
                list1.Add(arrayPoints[0], arrayPoints[1]);
                double y = arrayPoints[1];
                for (int i = 2; i < arrayPoints.Count; i += 2)
                {
                    if (y < arrayPoints[i + 1])
                    {
                        y = arrayPoints[i + 1];
                        list1.Add(PointPairBase.Missing, PointPairBase.Missing);
                    }
                    else
                    {
                        y = arrayPoints[i + 1];
                        list1.Add(arrayPoints[i], arrayPoints[i + 1]);
                    }
                }
            }
            else if (equation.Contains("tan"))
            {
                list1.Add(arrayPoints[0], arrayPoints[1]);
                double y = arrayPoints[1];
                for (int i = 2; i < arrayPoints.Count; i += 2)
                {
                    if (y > arrayPoints[i + 1])
                    {
                        y = arrayPoints[i + 1];
                        list1.Add(PointPairBase.Missing, PointPairBase.Missing);
                    }
                    else
                    {
                        y = arrayPoints[i + 1];
                        list1.Add(arrayPoints[i], arrayPoints[i + 1]);
                    }
                }
            }
            else
            {
                //Добавляем вычисленные значения в графики
                for (int i = 0; i < arrayPoints.Count; i += 2)
                {
                    list1.Add(arrayPoints[i], arrayPoints[i + 1]);
                }
                //добавляем корни на график
                for (int i = 0; i < arrayRoot.Count; i += 2)
                {
                    list2.Add(arrayRoot[i], arrayRoot[i + 1]);
                }
            }

            LineItem myCurve1 = pane.AddCurve($"{equationY}", list1, Color.Red, SymbolType.None);
            LineItem myCurve2 = pane.AddCurve("", list2, Color.Blue, SymbolType.Circle);
            myCurve2.Symbol.Fill.Type = FillType.Solid;
            myCurve2.Symbol.Size = 4;
            myCurve2.Line.IsVisible = false;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
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