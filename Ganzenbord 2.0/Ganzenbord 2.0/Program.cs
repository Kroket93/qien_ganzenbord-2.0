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
            nieuwSpel.updateMessage += update_Message;
            nieuwSpel.waitForKey += wait_For_Key_Message;
            nieuwSpel.readMessage += read_Message;

            nieuwSpel.initialiseerSpelers();
            nieuwSpel.spelStarten();
        }



        private static void update_Message(string message)
        {
            Console.WriteLine(message);
        }

        private static string read_Message()
        {
            return Console.ReadLine();
        }
        private static void wait_For_Key_Message()
        {
            Console.ReadKey();
        }

    }
}
