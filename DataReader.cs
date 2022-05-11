using System;
using AngouriMath;

namespace coursework
{
    class DataReader
    {
        coursework.Interface сalculator;
        public DataReader(coursework.Interface f)
        {
            this.сalculator = f;
        }

        public void ReadingBoundaries(out double Xmin, out double Xmax, out int numberPoints, out float accuracy)
        {
            if (!double.TryParse(сalculator.minBorder.Text.Replace(".", ","), out Xmin))
            {
                сalculator.minBorder.Text = null;
                сalculator.minBorder.Focus();
                throw new Exception("Левая граница введена неверно!");
            }

            if (!double.TryParse(сalculator.maxBorder.Text.Replace(".", ","), out Xmax))
            {
                сalculator.maxBorder.Text = null;
                сalculator.maxBorder.Focus();
                throw new Exception("Правая граница введена неверно!");
            }

            if (Xmin > Xmax)
            {
                сalculator.minBorder.Text = null;
                сalculator.minBorder.Focus();
                throw new Exception("Левая граница больше правой!");
            }

            if (Math.Abs(Xmin) + Math.Abs(Xmax) > 2000 && сalculator.повышеннаяТочностьToolStripMenuItem.Checked == false)
            {
                сalculator.minBorder.Text = null;
                сalculator.maxBorder.Text = null;
                throw new Exception("Диапазон значений слишком велик!");
            }

            if (сalculator.повышеннаяТочностьToolStripMenuItem.Checked == true)
            {
                accuracy = 0.01f;
                numberPoints = (int)Math.Ceiling((Xmax - Xmin) / 0.01) + 1;
            }
            else if (Math.Abs(Xmin) + Math.Abs(Xmax) <= 200)
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

        public void ReadingEquation(out Entity expr)
        {
            expr = сalculator.equation_textBox.Text;
        }
    }
}
