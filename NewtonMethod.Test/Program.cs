using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonMethod;

namespace NewtonMethod.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            double eps = 0.001;
            double number = 9;
            int pow = 2;
            ShowResult(number, pow, eps);

            pow = 0;
            ShowResult(number, pow, eps);

            number = 0.5;
            pow = 2;
            ShowResult(number, pow, eps);

            number = 0;
            ShowResult(number, pow, eps);

            number = -9;
            ShowResult(number, pow, eps);

            number = 9;
            pow = -2;

            ShowResult(number, pow, eps);
            Console.Read();
        }

        static void ShowResult(double number, int pow, double eps)
        {
            double result = NewtonMethod.Root(number, pow, eps);
            var powResult = Math.Pow(number, 1 / (double)pow);
            bool checkResult;
            if (Double.IsInfinity(powResult))
            {
                powResult = Double.NaN;
            }
            if (Double.IsNaN(powResult) && Double.IsNaN(result))
            {
                checkResult = true;
            }
            else
            {
                checkResult = Math.Abs(powResult - result) < eps;
            }
            string resultString = "number: {0}, pow: {1}, test result: {2}";
            Console.WriteLine(resultString, number, pow, checkResult);
            Console.WriteLine();
        }
    }
}
