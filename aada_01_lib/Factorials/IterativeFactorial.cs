using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace aada_01_lib.Factorials
{
    public class IterativeFactorial : Factorial
    {
        public override BigInteger Calculate(int n)
        {
            BigInteger m = 1;

            for (int i = 2; i <= n; i++)
            {
                m *= i;
            }

            return m;
        }
    }
}
