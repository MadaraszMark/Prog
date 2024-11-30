using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fa1_versenyzo
{
    //Definiáljon egy Versenyző nevű osztályt,
    //amely megvalósítja az IComparable<Versenyző> interfészt
    class Versenyzo : IComparable<Versenyzo>
    {
        //privát tagjai: 
        //Id, ami egy egész szám	
        //Név, ami egy string
        private int Id;
        private string Nev;
        //Publikus tagjai:	
        //Eredmények, ami egy lista referenciája
        public List<int> Eredmenyek;
        //paraméteres konstruktor: A konstruktor paraméterként vegye át a id-t és
        //egy stringben a teljes nevet,
        //A konstruktor hozza létre az int listát és adja át az Eredmények lista-referenciának;
        //a nevet és az id-t írja bele a privát tagokba.
        public Versenyzo(int id, string nev)
        {
            Eredmenyek = new List<int>();
            Id = id;
            Nev = nev;
        }
        //paraméter nélküli konstruktor: ez csak a Eredmények lista-referenciáját inicializálja
        public Versenyzo()
        {
            Eredmenyek = new List<int>();
        }

        //-	setId és setNév metódusok: ezek a paraméterként kapott értéket adják át
        //a megfelelő privát tagoknak.
        public void setId(int id) { Id = id; }
        public void setNev(string nev) {  Nev = nev; }

        //-	egy legobbUgrás nevű metódus, paraméterlistája void, visszatérési értéke a
        //legjobb eredmény. Ha a lista üres adjon vissza -1-et.
        public int LegjobbUgras()
        {
            if (Eredmenyek.Count > 0)
            {
                int max = Eredmenyek[0];
                for (int i = 1; i < Eredmenyek.Count; i++)
                {
                    if (max < Eredmenyek[i])
                    {
                        max = Eredmenyek[i];
                    }
                }
                return max;
            }
            return -1;
        }

        //-	Implementálja az Object-től örökölt ToString() metódust, amely a példányt
        //a következő formában jelenítse meg:
        //id név, eredményei: eredmény1, …legjobb: legjobbEredmény
        //Pl:
        //12 Nagy Gábor, eredményei: 399, 400, 390, legjobb: 400
        public override string ToString()
        {
            string s = string.Format($"{Id} {Nev}, eredményei: ");
            foreach (var e in Eredmenyek)
            {
                s += e + ", ";
            }
            int legjobb = LegjobbUgras(); //0;
            s += "legjobb: " + legjobb;
            return s;
        }
        #region IComparable<Versenyzo> Members
        //- implementálja az IComparable<Versenyző> interfész metódusát úgy,
        //hogy az legyen a nagyobb, amelyiknek jobb a legjobb ugrása.
        public int CompareTo(Versenyzo other)
        {
            int egyik = LegjobbUgras();
            int masik = other.LegjobbUgras();
            return egyik.CompareTo(masik);
            //return LegjobbUgras().CompareTo(other.LegjobbUgras());
        }
        #endregion
    }
}
