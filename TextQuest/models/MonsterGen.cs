using System;
using System.Collections.Generic;
using System.Text;

namespace TextQuest.models
{
    public class MonsterGen
    {
        public static string MonsterName { get; set; }
        public static int MonsterIdx { get; set; }
        public static int MonsterHealth { get; set; }
        public static int MonsterStr { get; set; }

        public static bool Hit { get; set; }

        public static void GenerateMonsterStats()
        {
            Random monsterRdm = new Random();
            MonsterHealth = monsterRdm.Next(1, 7) * 3;
            MonsterStr = monsterRdm.Next(1, 3);
        }
    }
}
