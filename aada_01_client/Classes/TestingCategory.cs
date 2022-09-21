using aada_01_lib.ObservedCalls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace aada_01_client.Classes
{
    // Класс для тестирования на время множества алгоритмов, выполняющих одну и ту же задачу
    class TestingCategory<T>
    {
        public readonly string Name;

        public readonly int ParameterCount;

        public readonly Type[] ParameterTypes;

        private readonly Func<int, object[]> ParameterProvider;

        public readonly List<string> AlgorithmNames;

        private readonly List<Func<object[], T>> Algorithms;

        public TestingCategory(string name, int paramCount, Type[] paramTypes, Func<int, object[]> paramProvider)
        {
            Name = name;
            ParameterCount = paramCount;
            ParameterTypes = paramTypes;
            ParameterProvider = paramProvider;

            AlgorithmNames = new List<string>();
            Algorithms = new List<Func<object[], T>>();
        }

        public void AddAlgorithm(string name, Func<object[], T> code)
        {
            AlgorithmNames.Add(name);
            Algorithms.Add(code);
        }

        public List<TestingResults<T>> Run(int numberOfRuns, int startRun = 0)
        {
            List<TestingResults<T>> results = new List<TestingResults<T>>();

            for (int i = startRun; i < numberOfRuns; i++)
            {
                object[] param = ParameterProvider(i);

                results.Add(new TestingResults<T>(param));

                for (int j = 0; j < Algorithms.Count; j++)
                {
                    Debug.WriteLine("Running test {0}, now testing algorithm {1}", i + 1, AlgorithmNames[j]);

                    (T result, long time) = ObservedExecution<T>.RunCode(() => Algorithms[j](param));

                    results[i - startRun].Results.Add(result);
                    results[i - startRun].ExecutionTimes.Add(time);
                }
            }

            return results;
        }
    }
}
