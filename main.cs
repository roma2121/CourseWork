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
using System.Net;

using AngouriMath;

namespace coursework
{

    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            Function.SelectedIndex = 0;
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


        private int read_from_textbox(ref double Xmin, ref double Xmax, ref double Step, ref double N_meaning, ref double M_meaning)
        {
            int work_code = 0;
            try
            {
                var _Xmin = double.Parse(minBorder.Text);
                Xmin = _Xmin;
            }
            catch
            {
                minBorder.Clear();
                minBorder.Focus();

                work_code = 101;
            }
            try
            {
                var _Xmax = double.Parse(maxBorder.Text);
                Xmax = _Xmax;
            }
            catch
            {
                maxBorder.Clear();
                maxBorder.Focus();

                work_code = 202;
            }
            try
            {
                var _Step = double.Parse(accuracy.Text);
                Step = _Step;
            }
            catch
            {
                accuracy.Clear();
                accuracy.Focus();

                work_code = 303;
            }
            try
            {
                var _N_meaning = double.Parse(N_values.Text);
                N_meaning = _N_meaning;
            }
            catch
            {
                N_values.Clear();
                N_values.Focus();

                work_code = 404;
            }
            try
            {
                var _M_meaning = double.Parse(M_values.Text);
                M_meaning = _M_meaning;
            }
            catch
            {
                M_values.Clear();
                M_values.Focus();

                work_code = 505;
            }

            return work_code;
        }

        private double min(double[] XX, double _Xmin, double _Xmax, double N, double M, int index)
        {
            // минимум
            switch (index)
            {
                case 0:
                    double MMIN0 = N * Math.Sin(M * XX[0]);
                    for (int j = 1; j < XX.Length; j++)
                    {
                        double test = N * Math.Sin(M * XX[j]);
                        if (MMIN0 > test)
                        {
                            MMIN0 = test;
                        }
                    }
                    if (MMIN0 > N * Math.Sin(M * _Xmin))
                    {
                        MMIN0 = N * Math.Sin(M * _Xmin);
                    }
                    if (MMIN0 > N * Math.Sin(M * _Xmax))
                    {
                        MMIN0 = N * Math.Sin(M * _Xmax);
                    }
                    return MMIN0;
                case 1:
                    double MMIN1 = N * Math.Cos(M * XX[0]);
                    for (int j = 1; j < XX.Length; j++)
                    {
                        double test = N * Math.Cos(M * XX[j]);
                        if (MMIN1 > test)
                        {
                            MMIN1 = test;
                        }
                    }
                    if (MMIN1 > N * Math.Cos(M * _Xmin))
                    {
                        MMIN1 = N * Math.Cos(M * _Xmin);
                    }
                    if (MMIN1 > N * Math.Cos(M * _Xmax))
                    {
                        MMIN1 = N * Math.Cos(M * _Xmax);
                    }
                    return MMIN1;
                case 2:
                    double MMIN2 = (N * Math.Sin(M * XX[0]) / XX[0]);
                    for (int j = 1; j < XX.Length; j++)
                    {
                        double test = (N * Math.Sin(M * XX[j])) / XX[j];
                        if (MMIN2 > test)
                        {
                            MMIN2 = test;
                        }
                    }
                    if (MMIN2 > (N * Math.Sin(M * _Xmin)) / _Xmin)
                    {
                        MMIN2 = (N * Math.Sin(M * _Xmin)) / _Xmin;
                    }
                    if (MMIN2 > (N * Math.Sin(M * _Xmax)) / _Xmax)
                    {
                        MMIN2 = (N * Math.Sin(M * _Xmax)) / _Xmax;
                    }
                    return MMIN2;
                case 3:
                    double MMIN3 = (N * Math.Cos(M * XX[0]) / XX[0]);
                    for (int j = 1; j < XX.Length; j++)
                    {
                        double test = (N * Math.Cos(M * XX[j])) / XX[j];
                        if (MMIN3 > test)
                        {
                            MMIN3 = test;
                        }
                    }
                    if (MMIN3 > (N * Math.Cos(M * _Xmin)) / _Xmin)
                    {
                        MMIN3 = (N * Math.Cos(M * _Xmin)) / _Xmin;
                    }
                    if (MMIN3 > (N * Math.Cos(M * _Xmax)) / _Xmax)
                    {
                        MMIN3 = (N * Math.Cos(M * _Xmax)) / _Xmax;
                    }
                    return MMIN3;
            }
            return 0;
        }
        private double max(double[] XX, double _Xmin, double _Xmax, double N, double M, int index)
        {
            // максимум
            switch (index)
            {
                case 0:
                    chart1.Series[0].LegendText = $"{N * M}cos({M}x)";
                    double MMAX0 = N * Math.Sin(M * XX[0]);
                    for (int j = 1; j < XX.Length; j++)
                    {
                        double test = N * Math.Sin(M * XX[j]);
                        if (MMAX0 < test)
                        {
                            MMAX0 = test;
                        }
                    }
                    if (MMAX0 < N * Math.Sin(M * _Xmin))
                    {
                        MMAX0 = N * Math.Sin(M * _Xmin);
                    }
                    if (MMAX0 < N * Math.Sin(M * _Xmax))
                    {
                        MMAX0 = N * Math.Sin(M * _Xmax);
                    }
                    return MMAX0;
                case 1:
                    chart1.Series[0].LegendText = $"-{N * M}sin({M}x)";
                    double MMAX1 = N * Math.Cos(M * XX[0]);
                    for (int j = 1; j < XX.Length; j++)
                    {
                        double test = N * Math.Cos(M * XX[j]);
                        if (MMAX1 < test)
                        {
                            MMAX1 = test;
                        }
                    }
                    if (MMAX1 < N * Math.Cos(M * _Xmin))
                    {
                        MMAX1 = N * Math.Cos(M * _Xmin);
                    }
                    if (MMAX1 < N * Math.Cos(M * _Xmax))
                    {
                        MMAX1 = N * Math.Cos(M * _Xmax);
                    }
                    return MMAX1;
                case 2:
                    chart1.Series[0].LegendText = $"({N * M}x*cos({M}x)-{N}sin({M}x))/x^2";
                    double MMAX2 = (N * Math.Sin(M * XX[0])) / XX[0];
                    for (int j = 1; j < XX.Length; j++)
                    {
                        double test = (N * Math.Sin(M * XX[j])) / XX[j];
                    if (MMAX2 < test)
                        {
                            MMAX2 = test;
                        }
                    }
                    if (MMAX2 < (N * Math.Sin(M * _Xmin)) / _Xmin)
                    {
                        MMAX2 = (N * Math.Sin(M * _Xmin)) / _Xmin;
                    }
                    if (MMAX2 < (N * Math.Sin(M * _Xmax)) / _Xmax)
                    {
                        MMAX2 = (N * Math.Sin(M * _Xmax)) / _Xmax;
                    }
                    return MMAX2;
                case 3:
                    chart1.Series[0].LegendText = $"(-{N * M}x*sin({M}x)-{N}cos({M}x))/x^2";
                    double MMAX3 = (N * Math.Cos(M * XX[0])) / XX[0];
                    for (int j = 1; j < XX.Length; j++)
                    {
                        double test = (N * Math.Cos(M * XX[j])) / XX[j];
                        if (MMAX3 < test)
                        {
                            MMAX3 = test;
                        }
                    }
                    if (MMAX3 < (N * Math.Cos(M * _Xmin)) / _Xmin)
                    {
                        MMAX3 = (N * Math.Cos(M * _Xmin)) / _Xmin;
                    }
                    if (MMAX3 < (N * Math.Cos(M * _Xmax)) / _Xmax)
                    {
                        MMAX3 = (N * Math.Cos(M * _Xmax)) / _Xmax;
                    }
                    return MMAX3;
            }
            return 0;
        }
        private void graphic(double _Xmin, int _Count, double[,] a, double N_meaning, double M_meaning)
        {
            //toolStripProgressBar1.Maximum = _Count;


            double N = N_meaning;
            double M = M_meaning;
            for (var i = 0; i < _Count; i++)
            {
                double _X = _Xmin + 0.1 * i;
                a[i, 0] = _X;

                //toolStripProgressBar1.Value++;

                int SelectedIndex = 12;
                this.Invoke((MethodInvoker)delegate ()
                {
                    SelectedIndex = Function.SelectedIndex;
                });


                if (SelectedIndex == 0)
                {
                    double _Y = N * M * Math.Cos(_X * M);
                    a[i, 1] = _Y;
                }
                else if (SelectedIndex == 1)
                {
                    double _Y = -N * M * Math.Sin(_X * M);
                    a[i, 1] = _Y;
                }
                else if (SelectedIndex == 2)
                {
                    double _Y = (N * M * _X * Math.Cos(_X * M) - N * Math.Sin(_X * M)) / (_X * _X);
                    a[i, 1] = _Y;
                }
                else if (SelectedIndex == 3)
                {
                    double _Y = (-N * M * _X * Math.Sin(_X * M) - N * Math.Cos(_X * M)) / (_X * _X);
                    //раскоментить для графика chart if (_Y < 1000 && _Y > -1000)
                    a[i, 1] = _Y;
                    //раскоментить для графика chart a[_Count/2+1, 1] = -1000;
                }
                else if (SelectedIndex == 12)
                {
                    MessageBox.Show("Ошибка вычислений!");
                }
            }
        }

        private void cal_c(double _Xmin, double _Xmax, double _Step, int _Count, double N_meaning, double M_meaning, double[] XX)
        {
            int index = 0;
            int ff = 0;
            double N = N_meaning;
            double M = M_meaning;
            for (var i = _Xmin; i <= _Xmax; i++)
            {
                // Вычисляем значение функций в точке X
                if (Function.SelectedIndex == 0)
                {
                    index = 0;
                    // Вычисляем значение X
                    double _X = (Math.PI / (2 * M)) + ((i * Math.PI) / M);
                    if (_X >= _Xmin && _X <= _Xmax)
                    {
                        XX[ff] = _X;
                        ff++;
                    }
                }
                else if (Function.SelectedIndex == 1)
                {
                    index = 1;
                    // Вычисляем значение X
                    double _X = (i * Math.PI) / M;
                    if (_X >= _Xmin && _X <= _Xmax)
                    {
                        XX[ff] = _X;
                        ff++;
                    }
                }
                else if (Function.SelectedIndex == 2)
                {
                    // Вычисляем значение X
                    double _X = _Xmin + 0.0001 * i;
                    index = 2;
                    double _Y = (N * M* _X * Math.Cos(_X * M)-N * Math.Sin(_X * M)) / (_X * _X);
                    if (Math.Round((0.0001 - _Y), 1) == 0)
                    {
                        XX[ff] = _X;
                        ff++;
                    }
                }
                else if (Function.SelectedIndex == 3)
                {
                    // Вычисляем значение X
                    double _X = _Xmin + 0.0001 * i;
                    index = 3;
                    double _Y = (-N * M * _X * Math.Sin(_X * M) - N * Math.Cos(_X * M)) / (_X * _X);
                    if (Math.Round((0.0001 - _Y), 1) == 0)
                    {
                        XX[ff] = _X;
                        ff++;
                    }
                }
            }
            double _MMIN = min(XX, _Xmin, _Xmax, N, M, index);
            double _MMAX = max(XX, _Xmin, _Xmax, N, M, index);
            textBox1.Text = (Convert.ToString(Math.Round(_MMIN, 3)) + Environment.NewLine + Convert.ToString(Math.Round(_MMAX, 3)));
        }
        public void painting(double[,] a)
        {
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            PointPairList list = new PointPairList();
            pane.XAxis.Title.Text = "Ось X";
            pane.YAxis.Title.Text = "Ось Y";
            pane.Title.Text = "График функции";



            // Добавляем вычисленные значения в графики
            for (int i = 0; i < (a.Length / 2); i++)
            {
            //раскоментить для графика chart
            //    chart1.Series[0].Points.AddXY(a[i,0], a[i,1]);

                list.Add(a[i, 0], a[i,1]);
            }

            
            if (Function.SelectedIndex == 0)
            {
                LineItem myCurve = pane.AddCurve("Косинус", list, Color.Red, SymbolType.None);
            }
            else if (Function.SelectedIndex == 1)
            {
                LineItem myCurve = pane.AddCurve("Синус", list, Color.Red, SymbolType.None);
            }
            else if (Function.SelectedIndex == 2)
            {
                LineItem myCurve = pane.AddCurve("Сложная функция", list, Color.Red, SymbolType.None);
            }
            else if (Function.SelectedIndex == 3)
            {
                LineItem myCurve = pane.AddCurve("Сложная функция", list, Color.Red, SymbolType.None);
            }

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            Entity expr = textBox5.Text;
            expr = textBox5.Text = Convert.ToString(expr.Differentiate("x"));
            Entity expr2 = $"{expr} = 0";
            textBox6.Text = Convert.ToString(expr2.Solve("x"));


            chart1.Series[0].Points.Clear();
            try
            {
                double Xmin = 0;
                double Xmax = 0;
                double Step = 0;
                double N_meaning = 0;
                double M_meaning = 0;

                int err = read_from_textbox(ref Xmin, ref Xmax, ref Step, ref N_meaning, ref M_meaning);

                if (err == 101)
                {
                    throw new Exception("Xmin введено неверно!");
                }
                else if (err == 202)
                {
                    throw new Exception("Xmax введено неверно!");
                }
                else if (err == 303)
                {
                    throw new Exception("В Шаг графика - введено неверно!");
                }
                else if (err == 404)
                {
                    throw new Exception("N введено неверно!");
                }
                else if (err == 505)
                {
                    throw new Exception("M введено неверно!");
                }

                chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax;

                if (Function.SelectedIndex == 0 | Function.SelectedIndex == 1)
                {
                    Step = 0.1;
                }
                else if (Function.SelectedIndex == 2 | Function.SelectedIndex == 3)
                {
                    Step = 0.0001;

                }
                var count = (int)Math.Ceiling((Xmax - Xmin) / Step) + 1;
                var XX = new double[count];
                cal_c(Xmin, Xmax, Step, count, N_meaning, M_meaning, XX);

                if (Function.SelectedIndex == 2 | Function.SelectedIndex == 3)
                {
                    count = count / 1000 + 1;
                }

                var a = new double[count, 2];
                await Task.Run(() => { graphic(Xmin, count, a, N_meaning, M_meaning); });
                painting(a);
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.Message);
            }
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss dddd");
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            try
            {
                //считывание начальной границы
                string _N_values = File.ReadLines(filename).Skip(0).First();
                N_values.Text = _N_values;
                //считывание начальной границы
                string _M_values = File.ReadLines(filename).Skip(1).First();
                M_values.Text = _M_values;
                //считывание начальной границы
                string _minBorder = File.ReadLines(filename).Skip(2).First();
                minBorder.Text = _minBorder;
                //считывание конечной границы
                string _maxBorder = File.ReadLines(filename).Skip(3).First();
                maxBorder.Text = _maxBorder;
                //считывание точнсти из файла
                string _accuracy = File.ReadLines(filename).Skip(4).First();
                accuracy.Text = _accuracy;

                MessageBox.Show("Файл открыт");

                button1_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Данные в файле некорректны!");
                minBorder.Clear();
                maxBorder.Clear();
                accuracy.Clear();
            }
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;

            //сохранение начальной границы, конечной границы и точности в файл
            using (StreamWriter file = new StreamWriter(filename, true, Encoding.Default))
            {
                file.WriteLine(N_values.Text);
                file.WriteLine(M_values.Text);
                file.WriteLine(minBorder.Text);
                file.WriteLine(maxBorder.Text);
                file.WriteLine(accuracy.Text);

                file.Close();
            }
            MessageBox.Show("Файл сохранён");
        }
        private void Function_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Function.SelectedIndex == 4)
            {
                // A
                label2.Text = "A =";
                // B
                label3.Text = "B =";
                // C
                label9.Visible = true;
                textBox2.Visible = true;

                label10.Visible = false;
                textBox3.Visible = false;

                label11.Visible = false;
                textBox4.Visible = false;
            }
            else if (Function.SelectedIndex == 5)
            {
                // A
                label2.Text = "A =";
                // B
                label3.Text = "B =";
                // C
                label9.Visible = true;
                textBox2.Visible = true;
                // D
                label10.Visible = true;
                textBox3.Visible = true;

                label11.Visible = false;
                textBox4.Visible = false;
            }
            else if (Function.SelectedIndex == 6)
            {
                // A
                label2.Text = "A =";
                // B
                label3.Text = "B =";
                // C
                label9.Visible = true;
                textBox2.Visible = true;
                // D
                label10.Visible = true;
                textBox3.Visible = true;
                // E
                label11.Visible = true;
                textBox4.Visible = true;
            }
            else
            {
                label9.Visible = false;
                textBox2.Visible = false;

                label10.Visible = false;
                textBox3.Visible = false;

                label11.Visible = false;
                textBox4.Visible = false;

                label2.Text = "N =";

                label3.Text = "M =";
            }
        }

        private void сохранитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                saveFileDialog1.Title = "Сохранить изображение как ...";
                chart1.SaveImage(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                zedGraphControl1.SaveAs(saveFileDialog1.FileName);
            }
        }

        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Function.SelectedIndex = 0;
            label9.Visible = false;
            textBox2.Visible = false;
            label10.Visible = false;
            textBox3.Visible = false;
            label11.Visible = false;
            textBox4.Visible = false;
            label2.Text = "N =";
            label3.Text = "M =";

            N_values.Text = null;
            M_values.Text = null;
            minBorder.Text = null;
            maxBorder.Text = null;
            accuracy.Text = null;

            chart1.Series[0].Points.Clear();
            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            zedGraphControl1.Refresh();
        }
    }
}
