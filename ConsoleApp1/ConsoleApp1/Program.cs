using System;
using System.Collections.Generic;
using JaratKezeloProject;

namespace TestJaratKezeloProject
{
    class Program
    {
        static void Main(string[] args)
        {
            TestUjJarat();
            TestKeses();
            TestMikorIndul();
            TestJaratokRepuloterrol();

            Console.WriteLine("Minden teszt sikeresen lefutott!");
        }

        static void TestUjJarat()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("J123", "BUD", "NYC", new DateTime(2023, 6, 7, 12, 0, 0));

            var result = jaratKezelo.MikorIndul("J123");
            if (result != new DateTime(2023, 6, 7, 12, 0, 0))
            {
                throw new Exception("Új járat tesztelése sikertelen.");
            }

            try
            {
                jaratKezelo.UjJarat("J123", "BUD", "LAX", new DateTime(2023, 6, 8, 12, 0, 0));
                throw new Exception("Új járat tesztelése sikertelen...");
            }
            catch (ArgumentException)
            {
               
            }
        }

        static void TestKeses()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("J123", "BUD", "NYC", new DateTime(2023, 6, 7, 12, 0, 0));
            jaratKezelo.Keses("J123", 30);

            var result = jaratKezelo.MikorIndul("J123");
            if (result != new DateTime(2023, 6, 7, 12, 30, 0))
            {
                throw new Exception("TestKeses sikertelen.");
            }

            try
            {
                jaratKezelo.Keses("J123", -60);
                throw new Exception("TestKeses sikertelen, nem lehet negativ.");
            }
            catch (ArgumentException)
            {
                
            }
        }

        static void TestMikorIndul()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("J123", "BUD", "NYC", new DateTime(2023, 6, 7, 12, 0, 0));
            jaratKezelo.Keses("J123", 10);
            jaratKezelo.Keses("J123", 20);

            var result = jaratKezelo.MikorIndul("J123");
            if (result != new DateTime(2023, 6, 7, 12, 30, 0))
            {
                throw new Exception("TestMikorIndul sikertelen.");
            }
        }

        static void TestJaratokRepuloterrol()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("J123", "BUD", "NYC", new DateTime(2023, 6, 7, 12, 0, 0));
            jaratKezelo.UjJarat("J124", "BUD", "LAX", new DateTime(2023, 6, 8, 12, 0, 0));
            jaratKezelo.UjJarat("J125", "LAX", "NYC", new DateTime(2023, 6, 9, 12, 0, 0));

            var result = jaratKezelo.JaratokRepuloterrol("BUD");

            if (!result.Contains("J123") || !result.Contains("J124") || result.Contains("J125"))
            {
                throw new Exception("TestJaratokRepuloterrol sikertelen.");
            }
        }
    }
}
