using System.Collections.Generic;
using System.Drawing;
using ZedGraph;
using AngouriMath;

namespace coursework
{
    class Draftsman
    {
        coursework.Сalculator сalculator;
        public Draftsman(coursework.Сalculator f)
        {
            this.сalculator = f;
        }

        public void painting(ref List<double> arrayPoints, ref int numberPoints, ref Entity equationY, ref List<double> arrayRoot)
        {
            GraphPane pane = сalculator.zedGraphControl1.GraphPane;
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

            сalculator.zedGraphControl1.AxisChange();
            сalculator.zedGraphControl1.Invalidate();
        }
    }
}
