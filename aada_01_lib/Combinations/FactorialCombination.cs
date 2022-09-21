using aada_01_lib.Factorials;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace aada_01_lib.Combinations
{
    public class FactorialCombination : Combination
    {
        private readonly Factorial F;

        public FactorialCombination(Factorial factorial)
        {
            F = factorial;
        }

        public override BigInteger Calculate(int n, int k)
        {
            return F.Calculate(n) / F.Calculate(k) / F.Calculate(n - k);
        }
    }
}
