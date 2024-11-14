using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace somewirdsht
{
    public class KeyHandler
    {
        public static string KeyToPress(Hero hero)
        {
            again:
            string input = Console.ReadLine();
            switch (input)
            {
                case "s":
                    BackPackClass.ShowStatistic(hero);
                    goto again;
                    break;
                case "b":
                    BackPackClass.OpenBackpack(hero);
                    goto again;
                    break;
                default:
                    return input;
            }
        }
    }
}
