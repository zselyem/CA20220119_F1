using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//16:12
namespace CA20220119
{
    class Program
    {
        public static Random rnd = new Random();
        public static List<Jatek> jatekok = new List<Jatek>();
        public static Dictionary<int, int> sikeres = new Dictionary<int, int>();
        public static Dictionary<string, int> kiado = new Dictionary<string, int>();
        public static List<string> mufajok = new List<string>();
        public static List<string> platformok = new List<string>();
        public static List<int> randomok = new List<int>();
        static void Main(string[] args)
        {
            Beolvas();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
            Feladat9();
            Feladat10();



            Console.ReadKey();
        }

        private static void Feladat10()
        {
            double osszesen = 0;
            double megjelent = 0;
            foreach(var j in jatekok)
            {
                if(j.kiado == "Electronic Arts")
                {
                    osszesen++;
                    if (j.platform.Contains("PC"))
                    {
                        megjelent++;
                    }
                }
            }
            double avg = megjelent / osszesen;
            Console.WriteLine($"10.feladat:\n\tAz Electronic Arts játékainak {avg:P2}-a jelent meg PC-n.");
        }

        private static void Feladat9()
        {
            string platform = "";
            Console.Write($"9.feladat:\n\tÍrja be egy platform nevét!: ");
            platform = Console.ReadLine();
            foreach(var j in jatekok)
            {
                if(j.platform.Contains(platform))
                {
                    platformok.Add(j.nev);
                }
            }
            Console.WriteLine($"\tEzen a platformon a következő játékok elérhetőek például:");
            if(platformok.Count <= 10)
            {
                int i = 1;
                foreach(var p in platformok)
                {
                    Console.WriteLine($"\t\t{i}. {p}");
                    i++;
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    randomok.Add(rnd.Next(0, platformok.Count()-1));
                }
                for(int j = 0; j < 10; j++)
                {
                    Console.WriteLine($"\t\t{j+1:D2}. {platformok[randomok[j]]}");
                }
            }
            
        }

        private static void Feladat8()
        {
            foreach(var j in jatekok)
            {
                if (!mufajok.Contains(j.mufaj))
                {
                    mufajok.Add(j.mufaj);
                }
            }
            mufajok.Sort();

            using (var sw = new StreamWriter(@"..\..\genres.txt"))
            {
                for (int i = 0; i < mufajok.Count; i++)
                {
                   sw.WriteLine(mufajok[i]);
                }
            }

            
            

        }

        private static void Feladat7()
        {
           foreach(var j in jatekok)
            {
                if (!kiado.ContainsKey(j.kiado))
                {
                    kiado.Add(j.kiado, 1);
                }
                else
                {
                    kiado[j.kiado] += 1;
                }
            }
            var legjobbKiado = kiado.Values.Max();
            foreach(var k in kiado)
            {
                if(k.Value == legjobbKiado)
                {
                    Console.WriteLine($"7.feladat:\n\tA legtöbb játékkal szereplő kiadó: {k.Key} ({k.Value}) játék.");
                }
            }
            

        }

        private static void Feladat6()
        {
            int utolso = 0;
            foreach(var j in jatekok)
            {
                if(j.platform.Contains("NES") && j.ev > utolso)
                {
                    utolso = j.ev;
                }
            }
            foreach(var j in jatekok)
            {
                if (j.platform.Contains("NES") && j.ev == utolso)
                {
                    Console.WriteLine($"6.feladat:\n\tAz utolsó NES jatek a {j.nev} megjelenesi eve: {j.ev}.");
                    utolso = 0;
                }
            }
        }

        private static void Feladat5()
        {
            foreach(var j in jatekok)
            {
                if (!sikeres.ContainsKey(j.ev))
                {
                    sikeres.Add(j.ev, 1);
                }
                else
                {
                    sikeres[j.ev] += 1;
                }
            }
            Console.WriteLine("5.feladat:\nIgazán sikeres évek:");
            Console.Write("\t");
            foreach(var s in sikeres)
            {
                if(s.Value >= 7)
                {
                    Console.Write($"{s.Key} ");
                    
                }
                    
                
            }
            Console.WriteLine();
        }


        private static void Feladat4()
        {
            int megjelentPCreIs = 0;
            foreach(var j in jatekok)
            {
                if (j.platform.Contains("PC"))
                {
                    megjelentPCreIs++;
                }
            }
            Console.WriteLine($"4.feladat:\n\t{megjelentPCreIs} db jatek jelent meg eloszor PC-re (is).");        
        }

        private static void Feladat3()
        {
            Console.WriteLine($"3.feladat:\n\tÖsszesen {jatekok.Count} játék zserepel a listában.");
        }

        private static void Beolvas()
        {
            Console.WriteLine("Az adatok beolvasasa...");
            using (var sr = new StreamReader(@"..\..\resources\games.txt", Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(';');
                    var platformok = sor[4].Split(',');
                    jatekok.Add(new Jatek(int.Parse(sor[0]), sor[1], sor[2], sor[3], platformok));
                }
            }
            #region az adatok kiirasa
            //foreach(var j in jatekok)
            //{
            //    Console.WriteLine(j.ev + " " + j.kiado + " " + j.nev + " " + j.mufaj + " " + j.platform[0]);
            //}
            #endregion



        }
    }
}
