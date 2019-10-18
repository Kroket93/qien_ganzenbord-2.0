using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganzenbord_2._0
{
    static class Dobbelsteen
    {
        public static event printMessageDelegate updateMessage;
        public static int dobbelen()
        {
            Random rnd = new Random();
            int dobbelWaarde = rnd.Next(1, 7);
            string message = ("Je hebt " + Convert.ToString(dobbelWaarde) + " gegooid");
            updateMessage(message);
            return dobbelWaarde;
        }
    }
}
