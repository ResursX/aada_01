using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace aada_01_lib.Factorials
{
    public class StirlingFactorial : Factorial
    {
        private static double Theta = 0.7509;

        public override BigInteger Calculate(int n)
        {
            double t = 1;

            for (int i = 0; i < n; i++)
            {
                t *= n / Math.E;
            }

            BigInteger B = (BigInteger)Math.Round(Math.Sqrt(2 * Math.PI * n) * t * Math.Exp(1 / (12 * n + Theta)));

            return B > 0 ? B : 1;
        }
    }
}
