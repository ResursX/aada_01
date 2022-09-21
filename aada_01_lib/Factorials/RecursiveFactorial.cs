using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace aada_01_lib.Factorials
{
    public class RecursiveFactorial : Factorial
    {
        public override BigInteger Calculate(int n)
        {
            if (n < 2)
                return 1;

            return Calculate(n - 1) * n;
        }
    }
}
