using System;

namespace zad1
{
    public abstract class Wezel {
        public int[] Index { get; set; }
        public abstract string Test(double[] x);
        public Wezel(int[] aIndex) { this.Index = aIndex; }
    }
}