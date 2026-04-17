using System;

namespace zad1
{
    public class WezelDecyzyjny : Wezel {
        public double Prog { get; set; }
        public int Cecha { get; set; }
        public Wezel Lewy { get; set; }
        public Wezel Prawy { get; set; }

        public WezelDecyzyjny(int[] aIndex, int aCecha, double aProg, Wezel aLewy, Wezel aPrawy) : base(aIndex) {
            this.Cecha = aCecha;
            this.Prog = aProg;
            this.Lewy = aLewy;
            this.Prawy = aPrawy;
        }
        public override string Test(double[] x){
            if (x[Cecha] < Prog){
                return Lewy.Test(x);
            }
            else{
                return Prawy.Test(x);
            }
        }
    }
}