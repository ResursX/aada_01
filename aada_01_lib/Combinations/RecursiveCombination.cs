using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace aada_01_lib.Combinations
{
    public class RecursiveCombination : Combination
    {
        public override BigInteger Calculate(int n, int k)
        {
            if (n == 0 || k == 0 || n == k)
                return 1;

            return Calculate(n - 1, k - 1) + Calculate(n - 1, k);
        }
    }
}
