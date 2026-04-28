using System;
using System.Collections.Generic;

namespace OOP_Praktika
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ühine nimekiri kõikide liidest rakendavate objektide jaoks
            List<IKujund> kujundid = new List<IKujund>();

            while (true) // Lõputu tsükkel, kuni kasutaja valib 0
            {
                Console.WriteLine("Vali kujund");
                Console.WriteLine("1. Ruut");
                Console.WriteLine("2. Ring");
                Console.WriteLine("3. Kolmnurk");
                Console.WriteLine("4. Ristkülik");
                Console.WriteLine("5. Täisnurkne kolmnurk");
                Console.WriteLine("0. Välju\n\n");
                Console.Write("Sisesta oma valik: ");
                int valik = int.Parse(Console.ReadLine());

                if (valik == 0) break; // Murrame tsüklist välja

                switch (valik)
                {
                    case 1:
                        Console.Write("Sisesta ruudu küljepikkus: ");
                        // Turvaline sisestus TryParse abiga
                        if (double.TryParse(Console.ReadLine(), out double külg))
                        {
                            kujundid.Add(new Ruut(külg)); // Lisame uue objekti listi
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Vigane sisend! Palun sisesta number.");
                        }
                        break;
                    case 2: // Ring
                        Console.Write("Sisesta ringi raadius: ");

                        if (double.TryParse(Console.ReadLine(), out double raadius))
                        {
                            kujundid.Add(new Ring(raadius));
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Vigane sisend! Palun sisesta number.");
                        }
                        break;
                    case 3: // Kolmnurk
                        Console.Write("Sisesta kolmnurga esimene külg: ");
                        bool külg1Ok = double.TryParse(Console.ReadLine(), out double külg1);

                        Console.Write("Sisesta kolmnurga teine külg: ");
                        bool külg2Ok = double.TryParse(Console.ReadLine(), out double külg2);

                        Console.Write("Sisesta kolmnurga kolmas külg: ");
                        bool külg3Ok = double.TryParse(Console.ReadLine(), out double külg3);

                        if (külg1Ok && külg2Ok && külg3Ok)
                        {
                            kujundid.Add(new Kolmnurk(külg1, külg2, külg3));
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Vigane sisend! Kõik küljed peavad olema numbrid.");
                        }
                        break;
                    case 4: // Ristkülik
                        Console.Write("Sisesta ristküliku pikkus: ");
                        bool pikkusOk = double.TryParse(Console.ReadLine(), out double pikkus);

                        Console.Write("Sisesta ristküliku laius: ");
                        bool laiusOk = double.TryParse(Console.ReadLine(), out double laius);

                        if (pikkusOk && laiusOk)
                        {
                            kujundid.Add(new Ristkülik(pikkus, laius));
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Vigane sisend! Pikkus ja laius peavad olema numbrid.");
                        }
                        break;

                    case 5:
                        Console.Write("Sisesta esimese kaateti pikkus: ");
                        bool kaatetAOk = double.TryParse(Console.ReadLine(), out double kaatetA);

                        Console.Write("Sisesta teise kaateti pikkus: ");
                        bool kaatetBOk = double.TryParse(Console.ReadLine(), out double kaatetB);

                        if (kaatetAOk && kaatetBOk)
                        {
                            kujundid.Add(new TäisnurkneKolmnurk(kaatetA, kaatetB));
                        }
                        else
                        {
                            Console.WriteLine("⚠️ Vigane sisend! Palun sisesta number.");
                        }
                        break;

                    // Märkus: Ring ja Kolmnurk töötavad sama loogika alusel. 
                    // Õpilased saavad need ise Switch-lausesse lisada!

                    default:
                        Console.WriteLine("Tundmatu valik.");
                        break;
                }
            }

            // Tulemuste kuvamine
            double kogupindala = 0;
            IKujund suurimKujund = null;
            double suurimPindala = 0;

            Console.WriteLine("\n--- Kujundite tulemused ---");
            foreach (var kujund in kujundid)
            {
                // Polümorfism: Iga kujund arvutab pindala ja ümbermõõdu oma spetsiifilise valemi järgi!
                // kujund.GetType().Name annab meile klassi nime (nt "Ruut" või "Ring")
                // :F2 ümardab tulemused 2 komakohani
                //Console.WriteLine($"Tüüp: {kujund.GetType().Name} | Pindala: {kujund.ArvutaPindala():F2} | Ümbermõõt: {kujund.ArvutaÜmbermõõt():F2}");

                string nimi = kujund.GetType().Name;
                double pindala = kujund.ArvutaPindala();
                double ümbermõõt = kujund.ArvutaÜmbermõõt();

                kogupindala += pindala;

                if (suurimKujund == null || pindala > suurimPindala)
                {
                    suurimKujund = kujund;
                    suurimPindala = pindala;
                }

                string rida = $"Tüüp: {nimi,-10} | Pindala: {pindala,8:F2} | Ümbermõõt: {ümbermõõt,8:F2}";

                // KONTROLL: Kas see kujund on tegelikult Kolmnurk?
                // Kasutame 'Pattern Matching' (kujund is Kolmnurk k)
                if (kujund is Kolmnurk k)
                {
                    // Nüüd me saame kasutada muutujat 'k', et küsida Kolmnurga omadusi
                    rida += $" | Liik: {k.Tüüp}";
                }

                Console.WriteLine(rida);
            }
            Console.WriteLine("\n--- Statistika ---");
            Console.WriteLine($"Kogupindala: {kogupindala:F2}");

            if (suurimKujund != null)
            {
                Console.WriteLine($"Kõige suurem kujund: {suurimKujund.GetType().Name} | Pindala: {suurimPindala:F2}");
            }

            //Ruut ruut = new Ruut(5);

            //double ruuduPindala = ruut.ArvutaPindala();
            //double ruuduÜmbermõõt = ruut.ArvutaÜmbermõõt();

            //Console.WriteLine(ruuduPindala);
            //Console.WriteLine(ruuduÜmbermõõt);

            //Ring ring = new Ring(5);

            //double ringiPindala = ring.ArvutaPindala();
            //double ringiÜmbermõõt = ring.ArvutaÜmbermõõt();

            //Console.WriteLine(ringiPindala);
            //Console.WriteLine(ringiÜmbermõõt);

            //Console.WriteLine("Kolmnurk");
            //Kolmnurk kolmnurk = new Kolmnurk(5, 5, 5);
            //Console.WriteLine($"Kolmnurga tüüp on {kolmnurk.Tüüp.ToString().ToLower()}");

            //double kolmnurgaPindala = ring.ArvutaPindala();
            //double kolmnurgaÜmbermõõt = ring.ArvutaÜmbermõõt();

            //Console.WriteLine(kolmnurgaPindala);
            //Console.WriteLine(kolmnurgaÜmbermõõt);


        }
    }

}
