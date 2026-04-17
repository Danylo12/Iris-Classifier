using System;

namespace zad1
{
    public class WezelLisci : Wezel {
        public string Gatunek { get; set; }
        public WezelLisci(int[] aIndex, string aGatunek) : base(aIndex) {
            this.Gatunek = aGatunek;
        }
        public override string Test(double[] x){
            return Gatunek ?? "Nieznany";
        }

    }
}