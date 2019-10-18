using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord_2._0
{
    public class Speler
    {
        public string Naam { get; set; }
        public int Plaats { get; set; }
        public Speler(string naamInput)
        {
            Naam = naamInput;
            Plaats = 0;
        }

        public void lopen(int dobbelWaarde)
        {
            Plaats += dobbelWaarde;
        }
        public void printStatus()
        {
            Console.WriteLine(Naam + " staat nu op plek " + Plaats);
        }

    }
}
