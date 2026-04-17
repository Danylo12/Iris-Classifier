using System;
using System.Collections.Generic;
using System.Linq;

namespace zad1
{
    internal class Drzewo
    {
        public Wezel Korzen { get; private set; }
        private tablica dane;
        private int maxGlebokosc;
        
        private Func<int[], double> kryteriumOceny;

        public Drzewo(tablica adane, int glebokosc, Func<int[], double> metodaOceny = null)
        {
            this.dane = adane;
            this.maxGlebokosc = glebokosc;
            this.kryteriumOceny = metodaOceny ?? ObliczGini;
        }

        private double ObliczGini(int[] indexs) {
            if (indexs.Length == 0) return 0;
            double kwadrat = 0;
            int n = indexs.Length;
            var groups = indexs.GroupBy(i => dane.nazwy[i]);
            foreach (var group in groups) {
                double p = (double)group.Count() / n; 
                kwadrat += p * p;
            }
            return 1 - kwadrat;
        }

        public void Zbuduj(int[] poczatkoweIndeksy)
        {
            Korzen = ZbudujDrzewo(poczatkoweIndeksy, 0);
        }

        private Wezel ZbudujDrzewo(int[] indeksy, int glebokosc)
        {
            var unikalneNazwy = indeksy.Select(i => dane.nazwy[i]).Distinct().ToArray();

            if (unikalneNazwy.Length <= 1 || glebokosc >= maxGlebokosc)
            {
                return new WezelLisci(indeksy, WybierzBGatunek(indeksy));
            }

            double BJakosc = double.MaxValue; 
            int BCecha = 0;
            double BProg = 0;
            int[] BLewe = Array.Empty<int>();
            int[] BPrawe = Array.Empty<int>(); 

            for (int cecha = 0; cecha < 4; cecha++){
                var dostepneWartosci = indeksy.Select(i => dane.Tab[i][cecha]).Distinct().OrderBy(v => v).ToArray();
                
                foreach (var prog in dostepneWartosci) {
                    int[] lewe = indeksy.Where(i => dane.Tab[i][cecha] < prog).ToArray();
                    int[] prawe = indeksy.Where(i => dane.Tab[i][cecha] >= prog).ToArray();

                    if (lewe.Length == 0 || prawe.Length == 0) continue;

                    double JakoscLewe = kryteriumOceny(lewe);
                    double JakoscPrawe = kryteriumOceny(prawe);
                    
                    double JakoscCalkowita = ((double)lewe.Length / indeksy.Length * JakoscLewe) + 
                                             ((double)prawe.Length / indeksy.Length * JakoscPrawe);

                    if (JakoscCalkowita < BJakosc){
                        BJakosc = JakoscCalkowita;
                        BCecha = cecha;
                        BProg = prog;
                        BLewe = lewe;
                        BPrawe = prawe;
                    }
                }
            }

            if (BLewe.Length == 0) return new WezelLisci(indeksy, WybierzBGatunek(indeksy));

            return new WezelDecyzyjny(
                indeksy, BCecha, BProg, 
                ZbudujDrzewo(BLewe, glebokosc + 1), 
                ZbudujDrzewo(BPrawe, glebokosc + 1)
            );        
        }

        private string WybierzBGatunek(int[] indeksy){
            return indeksy.GroupBy(i => dane.nazwy[i]).OrderByDescending(g => g.Count()).First().Key;
        }
    }
}