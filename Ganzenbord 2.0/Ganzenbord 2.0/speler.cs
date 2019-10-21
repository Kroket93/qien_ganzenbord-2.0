using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord_2._0
{
    public class Speler
    {

        public event printMessageDelegate updateMessage;

        public string Naam { get; set; }
        public int Plaats { get; set; }
        public bool doetMee { get; set; }
        public int beurtenOverslaan { get; set; }
        public bool inDePut { get; set; }

        public Speler(string naamInput)
        {
            Naam = naamInput;
            Plaats = 0;
            doetMee = true;
            beurtenOverslaan = 0;
            inDePut = false;
        }
        public void lopen(int dobbelWaarde)
        {
            Plaats += dobbelWaarde;
        }
        public void printStatus()
        {
            string message = (Naam + " staat nu op plek " + Plaats);
            updateMessage(message);
        }
    }
}
