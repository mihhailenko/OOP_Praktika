using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Praktika
{
    public class Ring : IKujund
    {
        public double Raadius { get; set; }

        public Ring(double raadius)
        {
            Raadius = raadius;
        }

        // Math.PI annab meile täpse Pii väärtuse
        public double ArvutaPindala() => Math.PI * Raadius * Raadius;
        public double ArvutaÜmbermõõt() => 2 * Math.PI * Raadius;
    }
}
