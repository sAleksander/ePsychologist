using System;
using System.Linq;

namespace NeuralNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] dataLearning = SupportAI.LoadData(Properties.Resource.TrainingData, 0, true);
            double[][] inputLearning = dataLearning.Select(line => line.Take(4).ToArray()).ToArray();
            double[][] outputLearning = dataLearning.Select(line => line.Skip(4).ToArray()).ToArray();


            double[][] dataTest = SupportAI.LoadData(Properties.Resource.TestData, dataLearning.Last().Length, false);
            double[][] inputTest = dataTest.Select(line => line.Take(4).ToArray()).ToArray();
            double[][] outputTest = dataTest.Select(line => line.Skip(4).ToArray()).ToArray();

            Network network = new Network(new int[] { 4, 7, 7, 1 });
            network.ImportBiases("...\\...\\Biases.txt");
            network.ImportWeights("...\\...\\Weights.txt");

            network.ShowNetwork();
            int gen = 500;
            double procentage = 0.0;
            int tmp = 1;
            while (procentage < 65)
            {
                // v uczenie v
                for (int j = 0; j < gen; j++)
                {
                    for (int i = 0; i < inputLearning.Length; i++)
                    {
                        network.Learning(inputLearning[i], outputLearning[i]);
                        if (j > gen - 2 && procentage > 60) network.ShowOutput(outputLearning[i]);
                    }
                }
                //v testowanie v
                int pass = 0;
                for (int i = 0; i < inputTest.Length; i++)
                {
                    if (network.FeedForward(inputTest[i], outputTest[i]))
                        pass++;
                   // network.ShowOutput(outputTest[i]);
                }
                procentage = 100.0 * pass / inputTest.Length;
                Console.WriteLine($"Gen: {(tmp++)*gen} \nAll: {inputTest.Length} Correct: {pass} Procentage: {procentage}%"); 
            }

            network.ExportBiases("...\\...\\Biases.txt");
            network.ExportWeights("...\\...\\Weights.txt");
            Console.ReadKey();
        }
    }
}
