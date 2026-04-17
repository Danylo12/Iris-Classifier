using System;
using System.Collections.Generic;
using System.Linq;
using zad1;
using irisy__zad1_;

namespace ConsoleApp1
{
    internal class MainClass
    {
        public static double ObliczEntropie(int[] indices, tablica data)
        {
            if (indices.Length == 0) return 0;
            int n = indices.Length;
            var counts = indices.GroupBy(i => data.nazwy[i]).Select(g => g.Count());
            double entropy = 0;
            foreach (var count in counts)
            {
                double p = (double)count / n;
                entropy -= p * Math.Log2(p);
            }
            return entropy;
        }

        public static void Main()
        {
            tablica data = new tablica(150, 4);
            data.LoadFromFile("bezdekIris.data");
            
            CV cv = new CV(5, 150); 
            var folds = cv.MakeCV();

            Console.WriteLine("=== Gini (Default) ===");
            RunTest(data, folds, null); 

            Console.WriteLine("\n=== Entropy ===");
            RunTest(data, folds, (idx) => ObliczEntropie(idx, data));
        }

        private static void RunTest(tablica data, List<(int[] train, int[] test)> folds, Func<int[], double> criterion)
        {
            double sumaAcc = 0;
            foreach (var fold in folds)
            {
                Drzewo tree = new Drzewo(data, 3, criterion);
                tree.Zbuduj(fold.train);

                int poprawnie = 0;
                foreach (int i in fold.test)
                {
                    if (tree.Korzen.Test(data.Tab[i]) == data.nazwy[i]) poprawnie++;
                }
                sumaAcc += (double)poprawnie / fold.test.Length * 100;
            }
            Console.WriteLine($"Srednia Accuracy: {sumaAcc / folds.Count:F2}%");
        }
    }
}