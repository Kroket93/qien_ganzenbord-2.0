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
        public event waitForKeyDelegate waitForKey;
        public event readMessageDelegate readMessage;

        public void regelsToepassen(Speler speler, int dobbelWaarde, ref bool spelBezig, List<Speler> spelerLijst)
        {
            if (speler.beurtenOverslaan > 0)
            {
                speler.beurtenOverslaan -= 1;
                string message = ("Je moest een beurt overslaan! hierna moet je nog " + Convert.ToString(speler.beurtenOverslaan) + " beurten overslaan");
                updateMessage(message);
                speler.printStatus();
            }
            else if (speler.inDePut)
            {
                string message = ("Je zit in de put! Wacht tot je gered wordt..");
                updateMessage(message);
                speler.printStatus();
            }
            else
            {
                switch (speler.Plaats)
                {
                    case 6:
                        string message = ("Je hebt een brug gevonden! Je gaat door naar 12!");
                        updateMessage(message);
                        speler.Plaats = 12;
                        speler.printStatus();
                        break;
                    case 19:
                        string message2 = ("Je hebt een herberg gevonden en besluit daar te rusten, volgende beurt overslaan!");
                        updateMessage(message2);
                        speler.beurtenOverslaan += 1;
                        speler.printStatus();
                        break;
                    case int n when (n > 63):
                        int tooMuch = speler.Plaats - 63;
                        string message3 = ("Oeps! te ver gegaan, ga " + Convert.ToString(tooMuch) + " plaatsen terug..");
                        updateMessage(message3);
                        speler.Plaats = 63 - tooMuch;
                        speler.printStatus();
                        break;
                    case 31:
                        string message4 = ("Je bent in de put beland! Je moet hier blijven tot iemand anders in de put terecht komt..");
                        updateMessage(message4);
                        foreach (Speler splr in spelerLijst)
                        {
                            if (splr.inDePut)
                            {
                                splr.inDePut = false;
                                string message5 = (Convert.ToString(splr.Naam + " is uit de put!"));
                                updateMessage(message5);
                            }
                        }
                        speler.inDePut = true;
                        speler.printStatus();
                        break;
                    case 42:
                        string message6 = ("Je bent verdwaald geraakt in een doolhof, ga terug naar 39!");
                        updateMessage(message6);
                        speler.Plaats = 39;
                        speler.printStatus();
                        break;
                    case 52:
                        string message7 = ("Je bent in de gevangenis beland! 3 beurten overslaan..");
                        updateMessage(message7);
                        speler.beurtenOverslaan = 3;
                        speler.printStatus();
                        break;
                    case 58:
                        string message8 = ("Je gans is doodgegaan! begin opnieuw met een andere gans");
                        updateMessage(message8);
                        speler.Plaats = 0;
                        speler.printStatus();
                        break;
                    case 63:
                        string message9 = (Convert.ToString(speler.Naam) + " heeft gewonnen!! Het spel is beeindigd!");
                        spelBezig = false;
                        break;
                }
            }
 
        }
    }
}
