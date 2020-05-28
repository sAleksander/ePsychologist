using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NeuralNetwork
{
    class SupportAI
    {
        private SupportAI() { }

        public static double[][] LoadData(byte[] file, int start, bool dataLearning)
        {
            double[][] output = new double[1][];
            try
            {
                string[] rawData = Encoding.UTF8.GetString(file).Split('\n');
                double[][] tmpOutput = new double[5][] { new double[rawData.Length], new double[rawData.Length], new double[rawData.Length], new double[rawData.Length], new double[rawData.Length] };
                for (int i = 0; i < rawData.Length; i++)
                {
                    var tmp = rawData[i].Split(';');
                    double diagnose = 0, sex = 0;
                    if (tmp[2].ToLower() == Properties.Resource.Female)
                        sex = 1;
                    if (tmp[3] == Properties.Resource.Schizophrenia + '\r')
                        diagnose = 1;
                    var pixelsCount = SupportAI.CalculateScan($"...\\...\\PreparedScans\\{i + start + 1}.png", 165, 200, 300, 400);
                    tmpOutput[0][i] = double.Parse(tmp[1]);//wiek
                    tmpOutput[1][i] = sex;//plec
                    tmpOutput[2][i] = pixelsCount[0];//jasne
                    tmpOutput[3][i] = pixelsCount[1];//ciemne
                    tmpOutput[4][i] = diagnose;//diagnoza
                }
                if (dataLearning)
                {
                    Normalize(ref tmpOutput[0]); //wiek
                    Normalize(ref tmpOutput[2]); //jasne
                    Normalize(ref tmpOutput[3]); //ciemne
                }
                else
                {
                    Normalize(ref tmpOutput[0], double.Parse(Properties.Resource.NormalizeAgeMax), double.Parse(Properties.Resource.NormalizeAgeMin)); //wiek
                    Normalize(ref tmpOutput[2], double.Parse(Properties.Resource.NormalizeBrightnessMax), double.Parse(Properties.Resource.NormalizeBrightnessMin)); //jasne
                    Normalize(ref tmpOutput[3], double.Parse(Properties.Resource.NormalizeDarknessMax), double.Parse(Properties.Resource.NormalizeDarknessMin)); //ciemne
                }

                output = new double[tmpOutput.Last().Length][];
                for (int i = 0; i < tmpOutput[0].Length; i++)
                    output[i] = new double[] { tmpOutput[0][i], tmpOutput[1][i], tmpOutput[2][i], tmpOutput[3][i], tmpOutput[4][i] };

            }
            catch (Exception)
            {
                Console.WriteLine(Properties.Resource.FileError);
            }

            return ShuffleData(output);
        }

        static double[] CalculateScan(string fname, int startX, int startY, int lengthX, int lengthY)
        {
            Bitmap brainScan = new Bitmap(fname);
            int width = brainScan.Width;
            int height = brainScan.Height;
            double[] sum = new double[2];
            sum[0] = 0;
            sum[1] = 0;

            Color pixel;
            for (int i = startX; i < lengthX; i++)
            {
                for (int j = startY; j < lengthY; j++)
                {
                    pixel = brainScan.GetPixel(i, j);
                    if (pixel.GetBrightness() < 0.4)
                    {
                        sum[0] += 1;
                    }
                    else
                    {
                        sum[1] += 1;
                    }
                }

            }
            return sum.Select(s => s / (lengthX - startX) * (lengthY - startY)).ToArray();
        }
        public static double[] CalculateScan(Bitmap brainScan, int startX = 165, int startY = 200, int lengthX = 300, int lengthY = 400)
        {
            int width = brainScan.Width;
            int height = brainScan.Height;
            double[] sum = new double[2];
            sum[0] = 0;
            sum[1] = 0;

            Color pixel;
            for (int i = startX; i < lengthX; i++)
            {
                for (int j = startY; j < lengthY; j++)
                {
                    pixel = brainScan.GetPixel(i, j);
                    if (pixel.GetBrightness() < 0.4)
                    {
                        sum[0] += 1;
                    }
                    else
                    {
                        sum[1] += 1;
                    }
                }

            }
            return sum.Select(s => s / (lengthX - startX) * (lengthY - startY)).ToArray();
        }

        public static double[] Normalize(ref double[] data)
        {
            double max = data.Max();
            double min = data.Min();


            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == max)
                    data[i] = 1;
                else if (data[i] == min)
                    data[i] = 0;
                else
                    data[i] = (data[i] - min) / (max - min);
            }
            return data;
        }

        public static double[] Normalize(ref double[] data, double max, double min)
        {

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == max)
                    data[i] = 1;
                else if (data[i] == min)
                    data[i] = 0;
                else
                    data[i] = (data[i] - min) / (max - min);
            }
            return data;
        }
        public static double Normalize( double data, double max, double min)
        {
                if (data == max)
                    data = 1;
                else if (data == min)
                    data = 0;
                else
                    data = (data - min) / (max - min);
            return data;
        }

        public static double[][] ShuffleData(double[][] Data)
        {
            Random rnd = new Random();
            return Data.OrderBy(x => rnd.Next()).ToArray();
        }
    }
}
