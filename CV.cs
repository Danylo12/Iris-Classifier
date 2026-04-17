using System;
using System.Collections.Generic;
using System.Linq;

namespace irisy__zad1_
{
    internal class CV
    {
        int[] indexTable;
        int k;

        public CV(int k, int size)
        {
            indexTable = new int[size];
            for (int i = 0; i < size; i++)
                indexTable[i] = i;

            this.k = k;
        }

        public List<(int[] train, int[] test)> MakeCV()
        {
            List<(int[], int[])> dataIndex = new List<(int[], int[])>();
            int foldSize = indexTable.Length / k; 

            for (int i = 0; i < k; i++)
            {
                int[] test = indexTable.Skip(i * foldSize).Take(foldSize).ToArray();
                int[] train = indexTable.Except(test).ToArray();

                dataIndex.Add((train, test)); 
            }

            return dataIndex;
        }
    }
}