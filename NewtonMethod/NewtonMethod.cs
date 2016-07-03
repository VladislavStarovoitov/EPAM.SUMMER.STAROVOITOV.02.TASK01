using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonMethod
{
    public static class NewtonMethod
    {
        public static double Root(double number, int pow, double eps)
        {
            bool isPowNegative = pow < 0;
            if (isPowNegative)
                pow *= -1;
            if (pow == 0)
            {
                return Double.NaN;
            }
            if (number < 0)
            {
                return Double.NaN;
            }
            if (Math.Abs(number) < eps)
            {
                return 0;
            }
            double previousValue = number;
            double currentValue = (1 / (double)pow) * ((pow - 1) * previousValue + number / (Pow(previousValue, pow - 1)));
            while (Math.Abs(currentValue - previousValue) > eps)
            {
                previousValue = currentValue;
                currentValue = (1 / (double)pow) * ((pow - 1) * previousValue + number / (Pow(previousValue, pow - 1)));
            }
            return isPowNegative ? 1 / currentValue : currentValue;
        }

        private static double Pow(double number, int pow)
        {
            double result = 1;
            while (pow != 0)
            {
                if ((pow & 1) != 0)
                {
                    result *= number;
                }
                pow >>= 1;
                number *= number;
            }
            return result;
        }
    }
}
