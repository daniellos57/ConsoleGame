using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somewirdsht
{
    public static class MapClass
    {
        public static void Map(int number)
        {
            string[] currentLocation = { "Darwin", "Brisbane", "Perth", "Melbourne" };
            Console.WriteLine("You are current in " + currentLocation[number] + "\n");
            string[] mapa = {
            "                  _,__        .:",
            "         Darwin <*  /        | \\",
            "            .-./     |.     :  :,",
            "           /           '-._/     \\_",
            "          /                '       \\",
            "        .'                         *: Brisbane",
            "     .-'                             ;",
            "     |                               |",
            "     \\                              /",
            "      |                            /",
            "Perth  \\*        __.--._          /",
            "        \\     _.'       \\:.       |",
            "        >__,-'             \\_/*_.-' Melbourne",
            "                             :--,",
            "                              '/'"
        };

            // Wyszukiwanie i zamiana nazwy miasta na "You are here"
            for (int i = 0; i < mapa.Length; i++)
            {
                if (mapa[i].Contains(currentLocation[number]))
                {
                    mapa[i] = mapa[i].Replace(currentLocation[number], "here");
                }
            }

            // Wyświetlanie zaktualizowanej mapy
            foreach (string line in mapa)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
