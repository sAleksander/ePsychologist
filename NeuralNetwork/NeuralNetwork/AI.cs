using System.Drawing;

namespace NeuralNetwork
{
    public class AI
    {
        public static int Calculate(int age, string sex, Bitmap brainScan)
        {
            double[] input;
            var pixelBrightness = SupportAI.CalculateScan(brainScan);
            if (sex.ToLower() == Properties.Resource.Female)
                input = new double[] { age, 1.0, pixelBrightness[0], pixelBrightness[1] };
            else
                input = new double[] { age, .0, pixelBrightness[0], pixelBrightness[1] };
            input[0] = SupportAI.Normalize(input[0], double.Parse(Properties.Resource.NormalizeAgeMax), double.Parse(Properties.Resource.NormalizeAgeMin));
            input[2] = SupportAI.Normalize(input[2], double.Parse(Properties.Resource.NormalizeBrightnessMax), double.Parse(Properties.Resource.NormalizeBrightnessMin));
            input[3] = SupportAI.Normalize(input[3], double.Parse(Properties.Resource.NormalizeDarknessMax), double.Parse(Properties.Resource.NormalizeDarknessMin));

            Network network = new Network(new int[] { 4, 7, 7, 1 });
            network.ImportBiases("...\\...\\...\\NeuralNetwork\\NeuralNetwork\\Biases.txt");
            network.ImportWeights("...\\...\\...\\NeuralNetwork\\NeuralNetwork\\Weights.txt");

            return network.FeedForward(input);
        }

    }
}
