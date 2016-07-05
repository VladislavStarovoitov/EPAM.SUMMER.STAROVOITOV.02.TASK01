using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonMethod
{
    /// <summary>
    /// Contains method that finds nth root
    /// </summary>
    public static class NewtonMethod
    {
        /// <summary>
        /// Finds nth root
        /// </summary>
        /// <param name="number">The number whose nth root is to be found</param>
        /// <param name="pow">The number that specifies a power.</param>
        /// <param name="eps">The number that specifies the accuracy of calculation of the root</param>
        /// <returns>Nth root of the number</returns>
        public static double Root(double number, int pow, double eps = 0.0000001)
        {
            bool isPowNegative = pow < 0;
            if (eps <= 0 || eps >= 1)
            {
                throw new ArgumentException("eps");
            }
            if (isPowNegative)
                pow *= -1;
            if (pow == 0)
            {
                return Double.NaN;
            }
            if (number < 0 && (pow & 1) == 0)
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

        /// <summary>
        /// Returns a specified number raised to the specified power
        /// </summary>
        /// <param name="number">A double-precision floating-point number to be raised to a power</param>
        /// <param name="pow">A double-precision floating-point number that specifies a power</param>
        /// <returns>The number raised to the power</returns>
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
