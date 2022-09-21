using System;
using System.Collections.Generic;
using System.Text;

namespace aada_01_client.Classes
{
    class TestingResults<T>
    {
        public readonly object[] Parameters;

        public readonly List<T> Results;

        public readonly List<long> ExecutionTimes;

        public TestingResults(object[] param)
        {
            Parameters = param;

            Results = new List<T>();
            ExecutionTimes = new List<long>();
        }
    }
}
