using System;
using System.Collections.Generic;

namespace JaratKezeloProject
{
    public class JaratKezelo
    {
        private class Jarat
        {
            public string JaratSzam { get; }
            public string RepterHonnan { get; }
            public string RepterHova { get; }
            public DateTime Indulas { get; }
            public int OsszesKeses { get; private set; }

            public Jarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
            {
                JaratSzam = jaratSzam;
                RepterHonnan = repterHonnan;
                RepterHova = repterHova;
                Indulas = indulas;
                OsszesKeses = 0;
            }

            public void AddKeses(int keses)
            {
                if (OsszesKeses + keses < 0)
                {
                    throw new ArgumentException("A késés nem lehet negatív.");
                }
                OsszesKeses += keses;
            }

            public DateTime GetTenyelegesIndulas()
            {
                return Indulas.AddMinutes(OsszesKeses);
            }
        }

        private readonly Dictionary<string, Jarat> jaratok = new Dictionary<string, Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratok.ContainsKey(jaratSzam))
            {
                throw new ArgumentException("A járatszám már létezik.");
            }

            var jarat = new Jarat(jaratSzam, repterHonnan, repterHova, indulas);
            jaratok.Add(jaratSzam, jarat);
        }

        public void Keses(string jaratSzam, int keses)
        {
            if (!jaratok.ContainsKey(jaratSzam))
            {
                throw new ArgumentException("Nem létező járatszám.");
            }

            var jarat = jaratok[jaratSzam];
            jarat.AddKeses(keses);
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            if (!jaratok.ContainsKey(jaratSzam))
            {
                throw new ArgumentException("Nem létező járatszám.");
            }

            return jaratok[jaratSzam].GetTenyelegesIndulas();
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            List<string> eredmeny = new List<string>();

            foreach (var jarat in jaratok.Values)
            {
                if (jarat.RepterHonnan == repter)
                {
                    eredmeny.Add(jarat.JaratSzam);
                }
            }

            return eredmeny;
        }
    }
}
