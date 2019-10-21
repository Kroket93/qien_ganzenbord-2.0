using System;
using System.Collections.Generic;

namespace Ganzenbord_2._0
{
    public class Spel
    {

        public Spel()
        {
            spelBord.updateMessage += update_Message;
            spelBord.waitForKey += wait_For_Key;
            spelBord.readMessage += read_Message;
            
            Dobbelsteen.updateMessage += update_Message;

        }
        public event printMessageDelegate updateMessage;
        public event waitForKeyDelegate waitForKey;
        public event readMessageDelegate readMessage;




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

        private static void wait_For_Key()
        {
            Console.ReadKey();
        }
        
        private static string read_Message()
        {
            return Console.ReadLine();
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
                        if (speler.beurtenOverslaan == 0 && !speler.inDePut)
                        {
                            speler.lopen(dobbelWaarde);
                            speler.printStatus();
                        }
                        spelBord.regelsToepassen(speler, dobbelWaarde, ref spelBezig, spelerLijst);
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
                string input = readMessage();//Console.ReadLine();
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
            waitForKey();
            //Console.ReadKey();
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
