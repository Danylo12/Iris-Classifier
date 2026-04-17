using System;

namespace zad1
{
    internal class DataProcessing
    {
        public static double[][] GetStandardizedTab(double[][] originalData)
        {
            int rows = originalData.Length;
            int cols = originalData[0].Length;


            double[][] std = new double[rows][];
            for (int i = 0; i < rows; i++) std[i] = new double[cols];

            for (int j = 0; j < cols; j++)
            {
                double sum = 0;
                for (int i = 0; i < rows; i++) sum += originalData[i][j];
                double mean = sum / rows;

                double sumSqDiff = 0;
                for (int i = 0; i < rows; i++) 
                    sumSqDiff += Math.Pow(originalData[i][j] - mean, 2);
                double stdDev = Math.Sqrt(sumSqDiff / rows);

                for (int i = 0; i < rows; i++)
                {
                    std[i][j] = (stdDev > 0.000001) ? (originalData[i][j] - mean) / stdDev : 0;
                }
            }
            return std;
        }
    }
}