using System;
using System.Collections.Generic;

namespace Ganzenbord_2._0
{
    public class Spel
    {

        public Spel()
        {
            spelBord.updateMessage += update_Message;
            Dobbelsteen.updateMessage += update_Message;

        }
        public event printMessageDelegate updateMessage;


        //intializeren
        //vars
        private List<Speler> spelerLijst = new List<Speler>();
        bool spelBezig = true;

        //objs
        public Spelbord spelBord = new Spelbord();




        private static void update_Message(string message)
        {
            Console.WriteLine(message);
        }

        public void spelStarten()
        {
            while (spelBezig)
            {
                foreach (Speler speler in spelerLijst)
                {
                    if (speler.doetMee)
                    {
                        printBeurt(speler);
                        speler.printStatus();
                        int dobbelWaarde = Dobbelsteen.dobbelen();
                        speler.lopen(dobbelWaarde);
                        speler.printStatus();
                        spelBord.regelsToepassen(speler, dobbelWaarde, ref spelBezig);
                        eindeBeurt();
                    }


                };
            };
        }

        public void initialiseerSpelers()
        {
            bool klaar = false;
            while (!klaar)
            {
                string message = "Ganzenbord! voer de naam van een speler in. vul 'klaar' in om te starten!";
                updateMessage(message);
                string input = Console.ReadLine();
                if (input != "klaar")
                {
                    if (input == "")
                    {
                        string errorMessage = "Error, vul een naam in!";
                        updateMessage(errorMessage);
                    }
                    else
                    {
                        spelerToevoegen(input);
                    }
                }
                else
                {
                    klaar = true;
                }
            }

            foreach (Speler speler in spelerLijst)
            {
                speler.updateMessage += update_Message;
            }
        }

        public void eindeBeurt()
        {
            string message = "Druk ergens op om je beurt te eindigen";
            updateMessage(message);
            string message2 = " ";
            updateMessage(message2);
            Console.ReadKey();
        }


        public void spelerToevoegen(string naamInput)
        {
            Speler spelerInstance = new Speler(naamInput);
            spelerLijst.Add(spelerInstance);
        }

        public void printBeurt(Speler speler)
        {
            string message = speler.Naam + " is nu aan de beurt";
            updateMessage(message);
        }
    }
}
