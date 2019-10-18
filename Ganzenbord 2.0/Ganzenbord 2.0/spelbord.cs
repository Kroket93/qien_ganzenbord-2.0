using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord_2._0
{
    public class Spelbord
    {
        public event printMessageDelegate updateMessage;

        public void regelsToepassen(Speler speler, int dobbelWaarde, ref bool spelBezig)
        {
            switch (speler.Plaats) {
                case 23:
                    string message = ("BOEF! " + Convert.ToString(speler.Naam) + " is de gevangenis in gegooid. Game Over.");
                    updateMessage(message);
                    speler.doetMee = false;
                    break;
                case 63:
                    string message2 = ("Gewonnen! Het spel eindigt");
                    updateMessage(message2);
                    spelBezig = false;
                    Console.ReadKey();
                    break;
                case int n when (n > 63):
                    int tooMuch = speler.Plaats - 63;
                    string message3 = ("Oeps! te ver gegaan, ga " + Convert.ToString(tooMuch) + " plaatsen terug..");
                    updateMessage(message3);
                    speler.Plaats = 63 - tooMuch;
                    speler.printStatus();
                    break;
                case 25:
                    string message4 = ("25! Terug naar start..");
                    updateMessage(message4);
                    speler.Plaats = 0;
                    speler.printStatus();
                    break;
                case 45:
                    string message5 = ("45! Terug naar start..");
                    updateMessage(message5);
                    speler.Plaats = 0;
                    speler.printStatus();
                    break;
                case int n when (n % 10 == 0):
                    string message6 = ("10, 20, 30, 40, 50, of 60! Loop nogmaals " + Convert.ToString(dobbelWaarde) + " stappen, naar " + Convert.ToString(speler.Plaats + dobbelWaarde) + "!");
                    updateMessage(message6);
                    speler.lopen(dobbelWaarde);
                    speler.printStatus();
                    regelsToepassen(speler, dobbelWaarde, ref spelBezig);
                    break;
            }
        }
    }
}
