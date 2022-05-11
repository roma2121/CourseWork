using System;
using System.Windows.Forms;

namespace coursework
{
    internal static class Program
    {
        public static Сalculator Сalculator
        {
            get => default;
            set
            {
            }
        }

        public static Сalculator Сalculator1
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Сalculator());
        }
    }
}
