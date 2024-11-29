using System;
using System.Collections.Generic;
using System.IO;

namespace SajatNev
{
    // Enum a tábla típusának meghatározására
    enum TablaTipus { Negyzetes, Altalanos }

    // Tábla osztály
    class Tabla : IComparable<Tabla>
    {
        private int[,] tablaTomb;
        private double sumErtek;
        private TablaTipus tipus;

        public double SumErtek => sumErtek;

        public Tabla(int n, int m)
        {
            tablaTomb = new int[n, m];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    tablaTomb[i, j] = rnd.Next(0, 101);
                }
            }

            tipus = (n == m) ? TablaTipus.Negyzetes : TablaTipus.Altalanos;
            Osszeg();
        }

        private void Osszeg()
        {
            double osszeg = 0;
            foreach (var elem in tablaTomb)
            {
                osszeg += elem;
            }
            sumErtek = tipus == TablaTipus.Negyzetes ? osszeg : -1;
        }

        public override string ToString()
        {
            return $"{tablaTomb.GetLength(0)} x {tablaTomb.GetLength(1)} {tipus} tábla összeg: {sumErtek}";
        }

        public void TablaKiir()
        {
            for (int i = 0; i < tablaTomb.GetLength(0); i++)
            {
                for (int j = 0; j < tablaTomb.GetLength(1); j++)
                {
                    Console.Write(tablaTomb[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public int CompareTo(Tabla other)
        {
            return other.SumErtek.CompareTo(this.SumErtek);
        }
    }
}