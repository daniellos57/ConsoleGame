using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somewirdsht
{
    public static class HeroExp
    {
        public static void LvlUp(Hero hero)
        {
            if (hero.exp >= hero.ExpToLvlUP)
            {
                hero.exp = 0;
                hero.LvL = hero.LvL + 1;
                hero.DMG_max = hero.DMG_max + RandomNumbers.randomnumber(1, 3);
                hero.ExpToLvlUP = hero.ExpToLvlUP * 2;
                hero.MaxHealth = hero.MaxHealth + 5;
                hero.Health = hero.MaxHealth;
                Console.WriteLine("\nYou just lvl up, you have now: " + hero.LvL + " lvl, you now have " + hero.DMG_min + "-" + hero.DMG_max + " dmg!");
            }
            Console.ReadKey();

        }
        public static void ExpUp(int maxEXP, Hero hero)
        {
            Console.Clear();
            int extraexp = RandomNumbers.randomnumber(2, maxEXP);
            hero.exp = hero.exp + extraexp;
            Console.WriteLine("\nYou earnd " + extraexp + " exp, you now have " + hero.exp + " exp");
            LvlUp(hero);
        }
    }
}
