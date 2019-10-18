using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord_2._0
{
    class Spelbord
    {
        public void regelsToepassen(Speler speler, int dobbelWaarde, ref bool spelBezig)
        {
            switch (speler.Plaats) {
                case 23:
                    Console.WriteLine("BOEF! " + Convert.ToString(speler.Naam) + " is de gevangenis in gegooid. Game Over.");
                    speler.doetMee = false;
                    break;
                case 63:
                    Console.WriteLine("Gewonnen! Het spel eindigt");
                    spelBezig = false;
                    Console.ReadKey();
                    break;
                case int n when (n > 63):
                    int tooMuch = speler.Plaats - 63;
                    Console.WriteLine("Oeps! te ver gegaan, ga " + Convert.ToString(tooMuch) + " plaatsen terug..");
                    speler.Plaats = 63 - tooMuch;
                    speler.printStatus();
                    break;
                case 25:
                    Console.WriteLine("25! Terug naar start..");
                    speler.Plaats = 0;
                    speler.printStatus();
                    break;
                case 45:
                    Console.WriteLine("45! Terug naar start..");
                    speler.Plaats = 0;
                    speler.printStatus();
                    break;
                case int n when (n % 10 == 0):
                    Console.WriteLine("10, 20, 30, 40, 50, of 60! Loop nogmaals " + Convert.ToString(dobbelWaarde) + " stappen, naar " + Convert.ToString(speler.Plaats + dobbelWaarde) + "!");
                    speler.lopen(dobbelWaarde);
                    speler.printStatus();
                    break;
            }
        }
    }
}
