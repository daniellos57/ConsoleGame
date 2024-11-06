using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somewirdsht
{
    public static class FightClass
    {
        public static void Death()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }
        public static void fight(string name, int monsterHealth, int MonsterDMGmin, int MonsterDMGmax, int maxEXP, bool CanEscape, Hero hero)
        {

            Console.Clear();
            int MonsterDMG;
            int HeroDMG;

            Console.WriteLine(name + " just attacked you!");
            do
            {

                HeroDMG = RandomNumbers.randomnumber(hero.DMG_min, hero.DMG_max);
                MonsterDMG = RandomNumbers.randomnumber(MonsterDMGmin, MonsterDMGmax);
again:
                Console.WriteLine("\nWhat you wanna do? \nP - power up\nL - leave\nA - attack\n");

                string input = Console.ReadLine();

                int x = RandomNumbers.randomnumber(1, 3);

                if (input == "l")
                {
                    if (CanEscape == true)
                    {
                        Console.WriteLine("You choose to try leave!");
                        if (x == 2)
                        {
                            Console.WriteLine("You menage to escape!");
                            break;
                        }
                        else Console.WriteLine("You can not escape!");
                    }
                    else Console.WriteLine("You can not escape!");
                }


                switch (input)
                {
                    case "p":
                        Console.WriteLine("You choose to try power up!");
                        if (x == 1)
                        {
                            Console.WriteLine("You menage to power up!");
                            HeroDMG = HeroDMG + 1;
                        }
                        else
                        {
                            Console.WriteLine("You can not power up! You lose some dmg!");
                            if (HeroDMG > 1) HeroDMG--;
                        }
                        break;
                    case "a":
                        Console.WriteLine("You choose to attack!");
                        break;

                    default:
                        Console.WriteLine("You picked wrong button");
                        goto again;
                }

                monsterHealth = monsterHealth - HeroDMG;
                hero.Health = hero.Health - MonsterDMG;
                Console.WriteLine("You attacked for " + HeroDMG);
                Console.WriteLine(name + " have " + monsterHealth + " hp left\n");
                if (monsterHealth > 0)
                {
                    Console.WriteLine(name + " attacked for " + MonsterDMG);
                    Console.WriteLine("You have " + hero.Health + " hp left\n");
                }
            } while (monsterHealth > 0 && hero.Health > 0);
            if (monsterHealth <= 0)
            {
                Console.Write("You knock him down! ");
                Console.ReadKey();
                Console.WriteLine("You earnd some bonus!");
                Console.Write("You have " + hero.Health + " hp left");
                hero.DMG_min += 1;
                Console.Write("You now have " + hero.DMG_min + "-" + hero.DMG_max + " dmg!");
                HeroExp.ExpUp(maxEXP, hero);
            }
            else if (hero.Health < 0)
            {
                Console.WriteLine("You just died!");
                Console.ReadKey();
                Death();
            }
        }
    }
}
