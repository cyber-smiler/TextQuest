using System;
using TextQuest.enums;
using TextQuest.models;
using TextQuest.MessageHelper;

namespace TextQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            DialogHelper.Dialog("Hello Adventurer, please state your name!\n", ConsoleColor.Blue);
            Adventurer.NameHero();
            
            if(String.IsNullOrEmpty(Adventurer.Name))
            {
                DialogHelper.Dialog("Im sorry traveller i didn't catch your name, what was it again?\n", ConsoleColor.Blue);
                Adventurer.NameHero();
            }

            DialogHelper.Dialog("Welcome " + Adventurer.Name + ", these are grave times! An evil wizard threatens the lands!!", ConsoleColor.Blue);
            
            var acceptTheQuest = AcceptingQuest();
            if (acceptTheQuest)
            {
                Adventurer.GeneratePlayerStats();
            }
            else
            {
               DialogHelper.Dialog("That is a shame, i guess we will have to wait for the next brave adventurer! Farewell Traveller!", ConsoleColor.Blue);
                Environment.Exit(0);
            }

            StartAdventure();
        }

        static void StartAdventure()
        {
            DialogHelper.Dialog("The evil wizard Zabiloff is holding the land hostage, you must help us to defeat him!\n", ConsoleColor.Blue);
            DialogHelper.Dialog("Where would you like to go first, the local Adventurer's Market (M) or head out on the road to Zabiloff (R)?\n", ConsoleColor.Blue);

            var answer = RetrieveKey().KeyChar.ToString().ToUpper();

            switch (answer)
            {
                case "M":
                    AdventurerMarket();
                    break;
                case "R":
                    OnTheRoad();
                    break;
                default:
                    break;
            }           
        }

        static void OnTheRoad()
        {
            DialogHelper.Dialog("\nYou head out on the open road towards Zabiloffs tower, which you have been told is far off to the West. \n" +
                "You have been travelling for several hours when you see a large forest on the horizon. \n" +
                "As you get closer to the forest you notice a shadowy figure just within what appears to be the path through the forest.");

            GenerateMonsterEncounter();

            DialogHelper.Dialog("The figure moves out of the shadows and in the bright sunlight you see that before you is a " + MonsterGen.MonsterName + "!!");
            Console.WriteLine();
            DialogHelper.Dialog("The " + MonsterGen.MonsterName + " sees you approaching and starts to make its way towards you. \n" +
                "It is slow to start with but soon gathers speed and before you know it the " + MonsterGen.MonsterName + " is running full speed towards you!");
            DialogHelper.Dialog("You raise your sword in preparation for the battle to come!");

            CombatBegins();

        }

        static void AdventurerMarket()
        {

        }
        
        static void GenerateMonsterEncounter()
        {
            var randomNum = new Random();
            var monsterIdx = randomNum.Next(0, 8);
            var monsterType = "";

            switch (monsterIdx)
            {
                case 0:
                    monsterType = "Goblin";
                        break;
                case 1:
                    monsterType = "Wolf";
                    break;
                case 2:
                    monsterType = "Giant Spider";
                    break;
                case 3:
                    monsterType = "Zombie";
                    break;
                case 4:
                    monsterType = "Half Ogre";
                    break;
                case 5:
                    monsterType = "Ogre";
                    break;
                case 6:
                    monsterType = "Bassalisk";
                    break;
                case 7:
                    monsterType = "Gibberling";
                    break;
                case 8:
                    monsterType = "Ghoul";
                    break;
                default:
                    break;
            }

            MonsterGen.MonsterIdx = monsterIdx;
            MonsterGen.MonsterName = monsterType;
            MonsterGen.GenerateMonsterStats();
        }

        static bool AcceptingQuest()
        {
            var accepted = false;
            DialogHelper.Dialog("Will you please help us?\n", ConsoleColor.Blue);

            var playerReply = Console.ReadLine();
            if (playerReply.ToUpper() == "YES" || playerReply.ToUpper() == "Y")
                accepted = true;


            return accepted;
        }

        static ConsoleKeyInfo RetrieveKey()
        {
            return Console.ReadKey();
        }

        static void CombatBegins()
        {
            DialogHelper.Dialog("\nThe " + MonsterGen.MonsterName + " has the following stats: \n" +
                "Hitpoints: " + MonsterGen.MonsterHealth + "\n" +
                "Combat Skill: " + MonsterGen.MonsterStr + "\n", ConsoleColor.Green);

            while (Adventurer.Health > 0 && MonsterGen.MonsterHealth > 0)
            {
                Random attackNum = new Random();
                var playerAttack = attackNum.Next(1, 6) * Adventurer.CombatStr;
                var monsterAttack = attackNum.Next(1, 6) * MonsterGen.MonsterStr;

                if (Adventurer.Hit = HitOrMiss())
                {
                    DialogHelper.Dialog("You hit the " + MonsterGen.MonsterName + " for " + playerAttack + " points of damage\n", ConsoleColor.Green);
                    MonsterGen.MonsterHealth -= playerAttack;
                }
                else
                {
                    DialogHelper.Dialog("You swing your sword but miss your target by a sliver\n", ConsoleColor.Green);
                }

                if (MonsterGen.Hit = HitOrMiss())
                {
                    DialogHelper.Dialog("The " + MonsterGen.MonsterName + " hits you for " + monsterAttack + " points of damage\n", ConsoleColor.Red);
                    Adventurer.Health -= monsterAttack;
                }
                else
                {
                    DialogHelper.Dialog("The " + MonsterGen.MonsterName + " launches for you but thankfully misses!\n", ConsoleColor.Red);
                }

                if (Adventurer.Health <= 0 || MonsterGen.MonsterHealth <= 0)
                {
                    if(Adventurer.Health <= 0)
                    {
                        DialogHelper.Dialog("\nYou have been slain! Better luck next time!\n", ConsoleColor.Red);
                        continue;
                    }

                    if(MonsterGen.MonsterHealth <= 0)
                    {
                        DialogHelper.Dialog("\nYou have defeated the " + MonsterGen.MonsterName + " well done hero!\n", ConsoleColor.Green);
                        continue;
                    }
                }
            }

            Console.ReadLine();
        }

        static bool HitOrMiss()
        {
            Random hitNum = new Random();
            var value = hitNum.Next(1, 6);

            if (value % 2 == 0)
                return true;

            return false;

        }
    }
}
