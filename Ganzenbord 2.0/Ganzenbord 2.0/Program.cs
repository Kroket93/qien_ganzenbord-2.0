using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Spel nieuwSpel = new Spel();
            nieuwSpel.initialiseerSpelers();
            nieuwSpel.spelStarten();
        }
    }
}
