using SajatNev;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Parkolo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Tabla> tablazatok = new List<Tabla>();

            try
            {
                string[] lines = File.ReadAllLines("teszt.txt");

                foreach (string line in lines)
                {
                    string[] split = line.Split(' ');
                    int n = int.Parse(split[0]);
                    int m = int.Parse(split[1]);
                    tablazatok.Add(new Tabla(n, m));
                }

                Console.WriteLine("Táblák adatai:");
                foreach (var tabla in tablazatok)
                {
                    Console.WriteLine(tabla);
                }

                tablazatok.Sort();

                Console.WriteLine("\nRendezett táblák kiírása:");
                foreach (var tabla in tablazatok)
                {
                    tabla.TablaKiir();
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}