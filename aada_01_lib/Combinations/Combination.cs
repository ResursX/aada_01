using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace aada_01_lib.Combinations
{
    abstract public class Combination
    {
        public abstract BigInteger Calculate(int n, int k);
    }
}
