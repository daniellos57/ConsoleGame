using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somewirdsht
{
    public static class  BackPackClass
    {
        public static void OpenBackpack(Hero hero)
        {
            List<string> consoleBuffer = new List<string>();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < Console.CursorTop; i++)
            {
                consoleBuffer.Add(Console.ReadLine());
            }

            // Wyczyść konsolę
            int position = 0;
            string exit = "xd";
            do
            {
                Console.Clear();
                Console.WriteLine("Pick - p, Exit - e, Up - u, Down - d");
                ViewBackpack(position, hero);
               var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.P:
                        PickFromBackpack(position, hero);
                        goto X;
                    case ConsoleKey.E:
                        exit = "e";
                        break;
                    case ConsoleKey.U:
                        X:
                        if (position == 0) position = hero.BackPack.Count-1;
                        else position--;
                        if (hero.BackPack[position][0] == null) { goto X; }
                            break;
                    case ConsoleKey.D:
                        Y:
                        if (position == hero.BackPack.Count - 1) position = 0;
                        else position++;
                        if (hero.BackPack[position][0] == null) { goto Y; }

                        break;
                }

            } while (exit != "e");

            Console.Clear();
            foreach (var line in consoleBuffer)
            {
                Console.WriteLine(line);
            }

        }
        public static void PickFromBackpack(int position, Hero hero) 
        {
            int kind = Convert.ToInt32(hero.BackPack[position][1]);
            int value = Convert.ToInt32(hero.BackPack[position][2]);
            switch (kind)
            {
                case 0: //hp potion
                    hero.Health = hero.Health + value;
                    break;
                case 1: //exp potion
                    HeroExp.ExpUp(value, hero);
                    break;
                case 2: //wepon
                    hero.DMG_max = value;
                    break;
                case 3: //armor
                    int helper = value - hero.MaxHealth;  
                    hero.MaxHealth = value;
                    hero.Health = hero.Health + helper;
                    break;
            }
            Console.Clear() ;
            Console.WriteLine("You succesfuly used " + hero.BackPack[position][0]);
            ShowStatistic(hero);
            Console.ReadKey();
           for (int i = 0; i<3;i++) hero.BackPack[position][i] = null;
        }


        public static void ViewBackpack(int position, Hero hero)
        {
            if (hero.BackPack!= null)
            {
                for (int i = 0; i < hero.BackPack.Count; i++)
                {
                    if (hero.BackPack[i][0] != null)
                    {
                        if (position == i) Console.WriteLine(hero.BackPack[i][0] + " <<");
                        else Console.WriteLine(hero.BackPack[i][0]);
                    }
                }
            }
        }

        public static void ShowStatistic(Hero hero)
        {
            Console.WriteLine("Your statistic: ");
            Console.WriteLine("DMG: "+hero.DMG_min + " - " + hero.DMG_max);
            Console.WriteLine("Current exp: " + hero.exp + " Need to lvl up: " +hero.ExpToLvlUP);
            Console.WriteLine("Current health: " + hero.Health + "/" + hero.MaxHealth);
        }

        public static void AddToBackPack(Hero hero,string name, int code, int value) 
        {
                hero.BackPack.Add(new List<string> { name,Convert.ToString(code),Convert.ToString(value) });
        }

    }
}
