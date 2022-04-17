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


        private void read_from_textbox(ref double Xmin, ref double Xmax, ref double Step, ref double N_meaning, ref double M_meaning)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void cal_c(double _Xmin, double _Xmax, double _Step, int _Count, double N_meaning, double M_meaning, double[] XX)
        {
            
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
                list.Add(a[i, 0], a[i,1]);
            }
            
            LineItem myCurve = pane.AddCurve("Косинус", list, Color.Red, SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            Entity expr = equation_textBox.Text;
            expr = equation_textBox.Text = Convert.ToString(expr.Differentiate("x"));
            Entity expr2 = $"{expr} = 0";
            textBox6.Text = Convert.ToString(expr2.Solve("x"));

            try
            {
                //painting(a);
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
                equation_textBox.Text = File.ReadLines(filename).Skip(0).First();
                minBorder.Text = File.ReadLines(filename).Skip(1).First();
                maxBorder.Text = File.ReadLines(filename).Skip(2).First();
                accuracy.Text = File.ReadLines(filename).Skip(3).First();

                MessageBox.Show("Файл открыт");
                button1_Click(sender, e);
            }
            catch
            {
                MessageBox.Show("Данные в файле некорректны!");
                equation_textBox.Clear();
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
                file.WriteLine(equation_textBox.Text);
                file.WriteLine(minBorder.Text);
                file.WriteLine(maxBorder.Text);
                file.WriteLine(accuracy.Text);
                file.Close();
            }
            MessageBox.Show("Файл сохранён");
        }
        
        private void сохранитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                saveFileDialog1.Title = "Сохранить изображение как ...";
                zedGraphControl1.SaveAs(saveFileDialog1.FileName);
            }
        }

        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            minBorder.Text = null;
            maxBorder.Text = null;
            accuracy.Text = null;

            GraphPane pane = zedGraphControl1.GraphPane;
            pane.CurveList.Clear();
            zedGraphControl1.Refresh();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Сalculator CalculatorForm = new Сalculator();
            CalculatorForm.Show();
        }
    }
}
