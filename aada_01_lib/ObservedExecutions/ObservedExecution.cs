using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace aada_01_lib.ObservedCalls
{
    public static class ObservedExecution<T>
    {
        private static Stopwatch stopwatch = new Stopwatch();

        public static (T, long) RunCode(Func<T> code)
        {
            stopwatch.Restart();

            T result = code();

            stopwatch.Stop();

            return (result, stopwatch.ElapsedMilliseconds);
        }
    }
}
