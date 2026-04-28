using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Praktika
{
    // Liidese nimi algab alati suure I-tähega
    public interface IKujund
    {
        // Liides kirjeldab AINULT meetodite allkirju. Sisu siia ei kirjutata.
        // Iga klass, mis seda liidest rakendab, PEAB need meetodid ise looma.
        double ArvutaPindala();
        double ArvutaÜmbermõõt();
    }
}
