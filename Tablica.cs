using System;
using System.IO;
using System.Globalization;

namespace zad1
{
    public class tablica
    {
        private double[][] tab;
        public string[] nazwy;

        public double[][] Tab => tab;

        public tablica(int rows, int columns)
        {
            tab = new double[rows][];
            nazwy = new string[rows];
            for (int i = 0; i < rows; i++)
                tab[i] = new double[columns];
        }

        public void LoadFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int row = 0;
            foreach (string line in lines)
            {
                if (row >= tab.Length || string.IsNullOrWhiteSpace(line)) break;
                string[] values = line.Split(',');
                for (int col = 0; col < 4 && col < values.Length; col++)
                    tab[row][col] = double.Parse(values[col], CultureInfo.InvariantCulture);
                if (values.Length > 4) nazwy[row] = values[4].Trim();
                row++;
            }
        }
    }
}