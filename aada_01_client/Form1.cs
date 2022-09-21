using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using aada_01_lib.Factorials;
using aada_01_lib.Combinations;
using aada_01_client.Classes;
using System.IO;

namespace aada_01_client
{
    public partial class Form1 : Form
    {
        Factorial factI, factR, factS;
        Combination combFI, combFR, combFS, combR, combP;

        private void button1_Click(object sender, EventArgs e)
        {
            Run();
        }

        List<TestingResults<BigInteger>> results;

        List<TestingCategory<BigInteger>> categories;

        public Form1()
        {
            InitializeComponent();

            SetupConfiguration();

            InitializeForm();
        }

        private void SetupConfiguration()
        {
            factI = new IterativeFactorial();
            factR = new RecursiveFactorial();
            factS = new StirlingFactorial();

            combFI = new FactorialCombination(factI);
            combFR = new FactorialCombination(factR);
            combFS = new FactorialCombination(factS);

            combR = new RecursiveCombination();
            combP = new PascalCombination();

            categories = new List<TestingCategory<BigInteger>>();

            categories.Add(new TestingCategory<BigInteger>("Факториал", 1, new Type[1] { typeof(int) }, x => new object[1] { x + 1 }));
            categories[0].AddAlgorithm("Итеративный", x => factI.Calculate((int) x[0]));
            categories[0].AddAlgorithm("Рекурсивный", x => factR.Calculate((int) x[0]));
            categories[0].AddAlgorithm("Формула Стирлинга", x => factS.Calculate((int) x[0]));

            categories.Add(new TestingCategory<BigInteger>("Сочетания", 2, new Type[2] { typeof(int), typeof(int) }, x => new object[2] { x + 1, x / 2 + 1 }));
            categories[1].AddAlgorithm("Факториал - Итеративный", x => combFI.Calculate((int)x[0], (int)x[1]));
            categories[1].AddAlgorithm("Факториал - Рекурсивный", x => combFR.Calculate((int)x[0], (int)x[1]));
            categories[1].AddAlgorithm("Факториал - Стирлинга", x => combFS.Calculate((int)x[0], (int)x[1]));
            categories[1].AddAlgorithm("Рекурсивный", x => combR.Calculate((int)x[0], (int)x[1]));
            categories[1].AddAlgorithm("Пирамида Паскаля", x => combP.Calculate((int)x[0], (int)x[1]));
        }

        private void InitializeForm()
        {
            foreach (TestingCategory<BigInteger> cat in categories)
            {
                comboBox1.Items.Add(cat.Name);
            }
        }

        private void Run()
        {
            //try
            //{
                int sel = comboBox1.SelectedIndex,
                    N = ((int)numericUpDown2.Value),
                    M = ((int)numericUpDown1.Value) < N ? ((int)numericUpDown1.Value) : 0;
                TestingCategory<BigInteger> cat = categories[sel];

                results = cat.Run(N, M);

                saveFileDialog1.ShowDialog();

                using (StreamWriter file = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int i = 0; i < cat.ParameterCount; i++)
                    {
                        file.Write("Переменные ");
                    }

                    for (int i = 0; i < cat.AlgorithmNames.Count; i++)
                    {
                        file.Write(cat.AlgorithmNames[i].Replace(' ', '_') + " " + cat.AlgorithmNames[i].Replace(' ', '_') + " ");
                    }

                    file.WriteLine();

                    for (int i = 0; i < cat.ParameterCount; i++)
                    {
                        file.Write("x" + i + " ");
                    }

                    for (int i = 0; i < cat.AlgorithmNames.Count; i++)
                    {
                        file.Write("Result Time ");
                    }

                    file.WriteLine();

                    foreach (TestingResults<BigInteger> res in results)
                    {
                        foreach (object p in res.Parameters)
                        {
                            file.Write(p.ToString() + " ");
                        }

                        for(int i = 0; i < cat.AlgorithmNames.Count; i++)
                        {
                            file.Write(res.Results[i].ToString() + " " + res.ExecutionTimes[i].ToString() + " ");
                        }

                        file.WriteLine();
                    }

                    file.Close();
                }
            //}
            //catch(Exception e)
            //{
            //    throw;

                //MessageBox.Show(e.Message);
            //}
        }
    }
}
