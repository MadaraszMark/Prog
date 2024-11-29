using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgParadigmKonyvtar
{
    //Definiáljon egy Konyv nevű osztályt a következő adatmezőkkel.
    //(5 pont)
    internal class Konyv : IKategoria
    {
        private int kod;
        private string szerzo;
        private string cim;
        private KolcsKat kk;

        //Minden adatmezőnek legyen lekérdező tulajdonsága is. 5 pont
        //(5 pont)
        public int Kod { get { return kod; } set { kod = value; } }
        public string Szerzo { get { return szerzo; } set { szerzo = value; } }
        public string Cim { get { return cim; } set { cim = value; } }
        public KolcsKat KK { get { return kk; } set {  kk = value; } }

        //Az osztály paraméteres konstruktora vegye át sztringként a fájl egy sorát. A könyv adataival töltse fel az adatmezőket.
        //A kk adattag feltöltéséhez használja a Kategoria() metódust.
        //(5 pont)
        public Konyv(string sor)
        {
            string[] s = sor.Split(';');

            kod = int.Parse(s[0]);
            szerzo = s[1];
            cim = s[2];
            kk = Kategoria(char.ToUpper(s[3][0]));
        }

        //Kategória(); Visszaadja a karakterhez tartozó KolcsKat típusú értéket.
        //(5 pont)
        public KolcsKat Kategoria(char c)
        {
            switch (c)
            {
                case 'K':
                    return KolcsKat.Kikölcsönzött;
                case 'H':
                    return KolcsKat.Hozzáférhető;
                case 'R':
                    return KolcsKat.Raktárban;
                default:
                    throw new ArgumentException("Ismeretlen kategória!");
            }
        }

        //Definiálja át a ToString() metódust úgy, hogy a következő alakban írja ki a könyvek adatait:
        //(5 pont)
        public override string ToString()
        {
            return String.Format($"{kod} # {szerzo}: {cim} # {kk}");
        }
    }
}
