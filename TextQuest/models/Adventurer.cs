using System;
using System.Collections.Generic;
using System.Text;
using TextQuest.MessageHelper;

namespace TextQuest.models
{
    public class Adventurer
    {
        public static string Name { get; set; }
        public static int Health { get; set; }
        public static int Magic { get; set; }
        public static int Luck { get; set; }

        public static int CombatStr { get; set; }
        public static int Money { get; set; }

        public static bool Hit { get; set; }

        public static void NameHero()
        {            
            Name = Console.ReadLine();
        }

        public static void GeneratePlayerStats()
        {
            DialogHelper.Dialog("Lets take a look at your stats hero!\n", ConsoleColor.Blue);
            Random randomNum = new Random();
            Health = randomNum.Next(1, 7) * 3;
            Magic = randomNum.Next(1, 7) * 3;
            Luck = randomNum.Next(1, 5) * 2;
            CombatStr = randomNum.Next(1, 3);

            DialogHelper.Dialog(
                "Hitpoints: " + Health + "\n" +
                "Mana: " + Magic + "\n" +
                "Luck: " + Luck + "\n" +
                "Combat Skill: " + CombatStr + "\n", ConsoleColor.Green);

            DialogHelper.Dialog("Lets hope you are up to the challenge ahead of you!", ConsoleColor.Blue);
        }

    }
}
