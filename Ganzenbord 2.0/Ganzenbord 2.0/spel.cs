using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord_2._0
{
    class Spel
    {
        //intializeren
        //vars
        private List<Speler> spelerLijst = new List<Speler>();
        private List<Speler> spelersTeVerwijderenLijst = new List<Speler>();
        bool spelBezig = true;
        //objs
        Spelbord spelBord = new Spelbord();

        public void spelStarten()
        {
            //debug spelers instancen
            spelerToevoegen("hans");
            spelerToevoegen("griet");

            while (spelBezig)
            {

                Speler spelerTeVerwijderen = null;
                foreach (Speler speler in spelerLijst)
                {
                    printBeurt(speler);
                    speler.printStatus();
                    int dobbelWaarde = Dobbelsteen.dobbelen();
                    speler.lopen(dobbelWaarde);
                    speler.printStatus();
                    spelBord.regelsToepassen(speler, dobbelWaarde, ref spelBezig, ref spelerTeVerwijderen);
                    toevoegenAanVerwijderlijst(spelerTeVerwijderen);
                    Console.WriteLine("Druk ergens op om je beurt te eindigen");
                    Console.WriteLine(" ");
                    Console.ReadKey();
                };
                spelersVerwijderen();

                //Console.ReadKey(); //einde van een while iteratie
            };
        }

        public void initialiseerSpelers()
        {
            bool klaar = false;

            while (!klaar)
            {
                Console.WriteLine("Ganzenbord! voer de naam van een speler in. vul 'klaar' in om te starten!");
                string input = Console.ReadLine();
                if (input != "klaar")
                {
                    spelerToevoegen(input);
                }
                else
                {
                    klaar = true;
                }
                
            }
        }

        public void spelerToevoegen(string naamInput)
        {
            Speler spelerInstance = new Speler(naamInput);
            spelerLijst.Add(spelerInstance);
        }

        public void toevoegenAanVerwijderlijst(Speler speler)
        {
            if(speler != null)
            {
                spelersTeVerwijderenLijst.Add(speler);
            }
            
        }
        public void spelersVerwijderen()
        {
            foreach (Speler obj in spelersTeVerwijderenLijst) {

                spelerLijst.Remove(obj);


            }
        }

        public void printBeurt(Speler speler)
        {
            Console.WriteLine(speler.Naam + " is nu aan de beurt");
        }
    }
}
