using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Praktika
{
    public class TäisnurkneKolmnurk : IKujund
    {
        private double a;
        private double b;
        private double c;

        public TäisnurkneKolmnurk(double a, double b)
        {
            this.a = a;
            this.b = b;
            this.c = Math.Sqrt(a * a + b * b);
        }

        public double ArvutaPindala()
        {
            return a * b / 2;
        }

        public double ArvutaÜmbermõõt()
        {
            return a + b + c;
        }
    }
}
