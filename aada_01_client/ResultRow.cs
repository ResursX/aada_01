using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace aada_01_client
{
    class ResultRow
    {
        public BigInteger Result;

        public long Time;

        public ResultRow(BigInteger result, long time)
        {
            Result = result;
            Time = time;
        }
    }
}
