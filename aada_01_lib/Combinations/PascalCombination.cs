using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace aada_01_lib.Combinations
{
    public class PascalCombination : Combination
    {
        private readonly List<List<BigInteger>> Triangle;

        public PascalCombination()
        {
            Triangle = new List<List<BigInteger>>(1) { new List<BigInteger>(1) { 1 } };
        }

        public override BigInteger Calculate(int n, int k)
        {
            if (n < 0 || k < 0 || k > n)
            {
                return 0;
            }

            if (n >= Triangle.Count || Triangle[n][k] == 0)
            {
                BigInteger t = Calculate(n - 1, k - 1) + Calculate(n - 1, k);

                if (n >= Triangle.Count)
                {
                    Triangle.Add(new List<BigInteger>(n + 1));

                    for (int i = 0; i <= n; i++)
                    {
                        Triangle[n].Add(0);
                    }
                }

                Triangle[n][k] = t;
            }

            return Triangle[n][k];
        }
    }
}
