using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace fa1_versenyzo
{
    //Feladat:
    //Írjon programot, amely egy távolugró verseny eredményeit olvassa be egy fájlból
    //versenyzőnként külön osztály-példányba, és kérésre kiírja a versenyző listát
    //és a győztest!
    //A versenyzők  eredményei az alábbi formátumú text fájlban vannak tárolva:
    //#id név1 név2 … eredmény1 eredmény2 eredmény3 …
    //…
    //Pl:
    //#12 Nagy Gábor 399 400 390
    //#7 Kis Csaba 403 392
    //#24 Juan Valerio 390  407 377 398
    //#3 Gipsz Jakab 390 375
    //#9 Kis Csaba 346 379 401
    //Egy sorban egy versenyző, a nevezési id-k nem sorrendben vannak.
    //A név szavainak száma mindig 2, és az érvényes ugrások számértéke esetenként eltérő.
    //Tesztelés: Hozzon létre egy tesztfájlt, melyben 4-5 versenyző adatai
    //szerepelnek a megadott minta szerint, az eredmények 
    //darabszáma ne legyen egyforma.
    class Program
    {
        static void Main(string[] args)
        {
            #region Versenyzo osztály tesztelése
            ////példa a CompareTo() függvény használatára alaptípus (double) esetén
            //double a = 30, b = 40;
            //Console.WriteLine(a.CompareTo(b));
            ////Versenyzo típusú lista létrehozása, feltöltése adatokkal, kírása, rendezése
            //List<Versenyzo> list = new List<Versenyzo>();
            //Versenyzo versenyzo = new Versenyzo(123, "Ó Ida");
            //versenyzo.Eredmenyek.Add(800);
            //versenyzo.Eredmenyek.Add(410);
            //versenyzo.Eredmenyek.Add(220);
            //list.Add(versenyzo);
            //versenyzo = new Versenyzo(145, "Próba Ida");
            //versenyzo.Eredmenyek.Add(500);
            //versenyzo.Eredmenyek.Add(210);
            //versenyzo.Eredmenyek.Add(220);
            //list.Add(versenyzo);
            //versenyzo = new Versenyzo();
            //versenyzo.setId(453);
            //versenyzo.setNev("Próba Elek");
            //versenyzo.Eredmenyek.Add(500);
            //versenyzo.Eredmenyek.Add(710);
            //versenyzo.Eredmenyek.Add(520);
            //list.Add(versenyzo);
            //Console.WriteLine("versenyzők listája:");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //list.Sort();
            //Console.WriteLine("versenyzők listája rendezve:");
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            //Hozzon létre egy Versenyző típusú listát és adja hozzá a listához a
            //fájlból beolvasott adatokból létrehozott versenyző példányokat.
            StreamReader olvas = new StreamReader("verseny.txt");
            List<Versenyzo> vLista = new List<Versenyzo>();
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                var d = sor.Split(' '); //string[]
                int id = int.Parse(d[0].Substring(1, d[0].Length - 1));
                string nev = d[1] + " " + d[2];
                Versenyzo v = new Versenyzo(id, nev);
                for (int i = 3; i < d.Length; i++)
                {
                    v.Eredmenyek.Add(int.Parse(d[i]));
                }
                vLista.Add(v);
            }
            olvas.Close();
            //Készítsen egy listát a versenyzőkről a ToString használatával.
            Console.WriteLine("A versenyzők listája: ");
            foreach (var item in vLista)
            {
                Console.WriteLine(item);
            }
            //Rendezze sorba a listát a List<Versenyző> Sort metódusával
            vLista.Sort();
            Console.WriteLine("\nA versenyzők listája a legjobb eredmény alapján rendezve: ");
            foreach (var item in vLista)
            {
                Console.WriteLine(item);
            }
            //Keresse meg a verseny győztesét és írja ki a ToString használatával.
            Console.WriteLine("\nA győztes: " + vLista[vLista.Count-1]);

            ////a verseny győztese
            //int gyoztesIndex = 0;
            //for (int i = 0; i < vLista.Count; i++)
            //{
            //    if (vLista[i].LegjobbUgras() > vLista[gyoztesIndex].LegjobbUgras())
            //    {
            //        gyoztesIndex = i;
            //    }
            //}
            //Console.WriteLine("\nA győztes: " + vLista[gyoztesIndex]);

            //Állapítsa meg, hogy vannak-e azonos nevű versenyzők a listában.
            //Az azonos nevű párokat írja ki a konzolra.
            Console.WriteLine("\nAzonos nevű versenyzők:");
            for (int i = 1; i < vLista.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (vLista[j].ToString().Split()[1] == vLista[i].ToString().Split()[1]
                        && vLista[j].ToString().Split()[2] == vLista[i].ToString().Split()[2])
                    {
                        Console.WriteLine(vLista[i] + " --- " + vLista[j]);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
