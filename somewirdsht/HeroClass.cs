using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace somewirdsht
{
        public class Hero
        {
            public string Name { get; set; }
            public int DMG_min { get; set; } = 1;
            public int DMG_max { get; set; } = 6;
            public int Health { get; set; } = 30;
            public int MaxHealth { get; set; } = 30;
            public int exp { get; set; } = 0;
            public int ExpToLvlUP { get; set; } = 10;
            public int LvL { get; set; } = 1;
            public List<List<string>> BackPack { get; set; }

        public Hero()
        {
            BackPack = new List<List<string>>();
        }
    }

 }
