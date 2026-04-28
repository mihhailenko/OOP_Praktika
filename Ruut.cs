using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Praktika
{
    public class Ruut : IKujund
    {
        public double Külg { get; set; }

        public Ruut(double külg)
        {
            Külg = külg;
        }

        public double ArvutaPindala() => Külg * Külg;
        public double ArvutaÜmbermõõt() => 4 * Külg;
    }
}
