using System;
using System.Collections.Generic;
using AngouriMath;

namespace coursework
{
    class Estimator
    {
        coursework.Interface сalculator;
        public Estimator(coursework.Interface f)
        {
            this.сalculator = f;
        }

        public void CalculationPoint(double Xmin, ref int numberPoints, ref Entity expr, ref List<double> arrayPoints, ref float accuracy, IProgress<int> progress)
        {
            try
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
            catch
            {
            }
        }

        public void RootSelection(ref double Xmin, ref double Xmax, ref Entity expr, ref Entity equationY, ref List<double> arrayRoot)
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
                for (int i = 0; i < 2; i++)
                {
                    roots[i] = roots[i].Replace("{ ", "");
                    roots[i] = roots[i].Replace(" }", "");
                    roots[i] = roots[i].Replace("\\/", "");
                    roots[i] = roots[i].Replace("\\ ", "");
                }

                Array.Resize(ref roots, roots.Length * (newCountRoots + 2) * quantityEquat + 1);

                for (int i = 0; i < roots.Length; i++)
                {
                    roots[i] = roots[i % parity];
                }

                int g = -1;
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
    }
}
