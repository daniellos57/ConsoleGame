using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Linq;
using somewirdsht;
using static MainGame;
class MainGame
{
    public static void CreateNewHero(Hero hero)
    {
        Console.WriteLine("What's your name?");
        hero.Name = Console.ReadLine();
        hero.BackPack.Add(new List<string> { "HP potion", "0", "10" });
        hero.BackPack.Add(new List<string> { "EXP potion", "1", "5" });
        hero.BackPack.Add(new List<string> { "Long sword", "2", "8" });
        hero.BackPack.Add(new List<string> { "Hard armour", "3", "7" });

    }
    static void Main()
    {
        Hero hero = new Hero();
        Console.WriteLine("Welcome to Hero Draw!");
        Console.WriteLine("Choose what u wanna do!\n N - new game\n L- Load game\n P - Pong game!");
      AGAIN:  string input = Console.ReadLine();
        switch (input)
        {
            case "n":
                CreateNewHero(hero);
                Start(hero);
                break;
            case "l":
                Hero loadedHero = HeroManager.LoadHero();
                Start(loadedHero);
                break;
            case "p":
                StratPong();
                break;
            default:
                goto AGAIN;
        }



    }


public static void StratPong()
    {
        string[,] plansza = new string[10, 15];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                plansza[i, j] = " ";
            }

        }
        Boolean pong = false;

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                plansza[i, j] = "X";
            }

        }

        int x = 5;
        int y = 5;
        int down = 1;
        int left = 0;
        int arrow_right = 8;
        int arrow_left = 7;
        do
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    if (arrow_right < 14)
                    {
                        plansza[9, arrow_left] = " ";
                        plansza[9, arrow_right] = " ";
                        arrow_right++;
                        arrow_left++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    if (arrow_left > 0)
                    {
                        plansza[9, arrow_left] = " ";
                        plansza[9, arrow_right] = " ";
                        arrow_right--;
                        arrow_left--;
                    }
                }
            }
            plansza[9, arrow_left] = "-";
            plansza[9, arrow_right] = "-";
            plansza[x, y] = " ";

            if (down == 0)
            {
                if (x < 9) x++; else { x--; down = 1; }
            }
            else
            {
                if (x > 0) x--; else { x++; down = 0; }
            }


            if (left == 0)
            {
                if (y < 14) y++; else { y--; left = 1; }
            }
            else
            {
                if (y > 0) y--; else { y++; left = 0; }


                if (x == 8 && y == arrow_left) { down = 1; left = 0; x = 8; }
                if (x == 8 && y == arrow_right) { down = 1; left = 1; x = 8; }
                if (x == 9 && y != arrow_left && y != arrow_right) break;
            }

            if (x == 0 && plansza[0, y] == "X")
            {
                plansza[0, y] = " ";
                if (down == 1) down = 0;
                else down = 1;
            }

            if (x == 1 && plansza[1, y] == "X")
            {
                plansza[1, y] = " ";
                if (down == 1) down = 0;
                else down = 1;
            }

            plansza[x, y] = "*";
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Console.Write(plansza[i, j] + " ");
                }
                Console.WriteLine("\n");
            }
            Thread.Sleep(300);
        } while (true);

        plansza[x, y] = "*";

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                Console.Write(plansza[i, j] + " ");
            }
            Console.WriteLine("\n");
        }

        Console.WriteLine("U lose!");
    }
public static void Start(Hero hero)
    {
        Console.WriteLine("Hello " + hero.Name + "! Let's go and find your friends!");
        Console.WriteLine("Press 'B' to search your inventory before a fight or 'S' to check your stats.");
        Console.WriteLine("In battle, you can attempt to attack, retreat, or power up.");

        MapClass.Map(0);
        Console.WriteLine("You've encountered a skeleton! \nDo you want to fight it? (y/n)");
        string input = KeyHandler.KeyToPress(hero);

        if (input == "y")
        {
            FightClass.fight("Skeleton", 10, 1, 4, 11, true, hero);
        }
        else
        {
            Console.WriteLine("You chose to leave!");
        }

        BackPackClass.AddToBackPack(hero, "BigGlockForTest", 1, 1);
        Console.WriteLine("Let's go to another location!");
        HeroManager.SaveHero(hero);
        Console.ReadKey();

        MapClass.Map(1);
        Console.WriteLine("You’ve arrived at a city! \nDo you want to talk to the old woman? (y/n)");
        input = KeyHandler.KeyToPress(hero);

        if (input == "y")
        {
            Console.WriteLine("\nShe tells you that you’re a handsome young lad and gives you some pierogis.");
            Console.WriteLine("\nPierogis will boost your experience in the next fight!");
            Console.ReadKey();

            Console.WriteLine("\nSuddenly, someone interrupts your meal! You have to fight!");
            FightClass.fight("Unknown Man", 15, 3, 5, 20, false, hero);
            Console.WriteLine("\nYou gain new pierogis and restore your health to full!");
            hero.Health = hero.MaxHealth;
        }
        else
        {
            Console.WriteLine("\nYou chose to leave her alone.");
        }

        HeroManager.SaveHero(hero);
        Console.WriteLine("\nGrandpa> I just wanted to enjoy some pierogis!");
        Console.WriteLine("\nYou leave them and continue searching for your friends.");
        Console.WriteLine("\nYou could swear you saw one of them head into a place with dancing ladies...");
        Console.ReadKey();

        Console.WriteLine("\nYou approach the lady at the entrance and ask:\nA - 'Can I go in?'\nB - 'Hey, that was my friend Tomek! Could you ask him to come out?'\nC - *Ignore her and rush inside*");
        input = KeyHandler.KeyToPress(hero);

        Console.WriteLine("\nThe lady looks at you and says:");
        Console.WriteLine("\nLady> You can’t come in. Get lost!");
        Console.ReadKey();

        Console.WriteLine("\nYou try sneaking in from the back, but someone spots you and calls the guards! You have to fight!");
        Console.ReadKey();
        FightClass.fight("Guards", 20, 1, 8, 12, true, hero);

        Console.WriteLine("\nYou manage to escape and get inside!");
        HeroManager.SaveHero(hero);
        Console.WriteLine("\nYou see Tomek and run over to him.");
        Console.WriteLine("\nTomek> Hey, what are you doing here?");
        Console.ReadKey();

        Console.WriteLine("\nYou> I'm here to pick you up! We need to find Mariusz and bring him back.");
        Console.WriteLine("\nTomek> Alright, let’s go!");
        Console.WriteLine("\nThe two of you leave the place and head to the harbor.");
        // 1. Spotkanie z handlarzem
        Console.WriteLine("\nYou encounter a mysterious figure in the shadows. He appears to be a weapons trader.");
        Console.WriteLine("Trader> Hello there, adventurer. Would you like to trade for a better weapon? (y/n)");
        input = KeyHandler.KeyToPress(hero);

        if (input == "y")
        {
            Console.WriteLine("\nTrader> I have a powerful sword for you, but it will cost you. Do you have anything to offer?");
            BackPackClass.AddToBackPack(hero, "MysticSword", 2, 15); // Dodajemy nową broń do plecaka bohatera
            Console.WriteLine("\nYou traded some items and received a Mystic Sword!");
        }
        else
        {
            Console.WriteLine("\nTrader> Very well, maybe next time.");
        }
        Console.WriteLine("\nAs you make your way through a narrow street, a shadowy figure jumps out and blocks your path.");
        Console.WriteLine("Thief> Hand over all your valuables, or else!");
        Console.WriteLine("\nDo you want to fight the thief? (y/n)");
        input = KeyHandler.KeyToPress(hero);

        if (input == "y")
        {
            Console.WriteLine("\nYou prepare yourself to fight the thief!");
            FightClass.fight("Thief", 12, 2, 5, 15, true, hero); // Przekazujemy parametry walki


                Console.WriteLine("\nYou defeated the thief!");

                // Nagroda za wygraną
                Console.WriteLine("You search the thief and find a few valuables.");
                BackPackClass.AddToBackPack(hero, "Golden Ring", 1, 1); // Dodajemy cenny przedmiot do plecaka
            HeroExp.ExpUp(10, hero); // Dodajemy punkty doświadczenia za pokonanie złodzieja
                Console.WriteLine("\nYou gain 10 experience points and a Golden Ring!");
        }
        else
        {
            Console.WriteLine("\nYou decide not to fight and the thief sneers as he slips into the shadows.");
            Console.WriteLine("Unfortunately, he manages to steal a few coins from you as he disappears.");
        }


        // 2. Wpadnięcie w pułapkę
        Console.WriteLine("\nAs you walk through a narrow alley, you suddenly hear a loud noise!");
        Console.WriteLine("You've triggered a trap! Do you want to try to escape? (y/n)");
        input = KeyHandler.KeyToPress(hero);

        if (input == "y")
        {
            Console.WriteLine("\nYou barely manage to escape the trap! But you lose some health.");
            hero.Health -= 5;
            if (hero.Health <= 0) hero.Health = 1; // Upewnij się, że zdrowie nie spadnie poniżej 1
        }
        else
        {
            Console.WriteLine("\nThe trap catches you, and you lose a significant amount of health.");
            hero.Health -= 10;
        }

        // 3. Tajemnicza skrzynia
        Console.WriteLine("\nYou find a mysterious chest along the path. Do you want to try to open it? (y/n)");
        input = KeyHandler.KeyToPress(hero);

        if (input == "y")
        {
            Console.WriteLine("\nYou open the chest...");
            Random rnd = new Random();
            int chestOutcome = RandomNumbers.randomnumber(1, 4);

            switch (chestOutcome)
            {
                case 1:
                    Console.WriteLine("You found a potion! It restores some health.");
                    hero.Health += 10;
                    if (hero.Health > hero.MaxHealth) hero.Health = hero.MaxHealth;
                    break;
                case 2:
                    Console.WriteLine("It's a trap! You lose some health.");
                    hero.Health -= 10;
                    if (hero.Health <= 0) hero.Health = 1;
                    break;
                case 3:
                    Console.WriteLine("You find a rare gem! This will increase your experience.");
                    HeroExp.ExpUp(15, hero);
                    break;
            }
        }
        else
        {
            Console.WriteLine("You decide to leave the chest alone.");
        }

        // 4. Spotkanie z przyjacielem
        Console.WriteLine("\nJust before reaching the harbor, you run into an old friend.");
        Console.WriteLine("Friend> Hey! Long time no see! Need some help?");
        Console.WriteLine("He offers to accompany you for the next battle. Do you accept his help? (y/n)");
        input = KeyHandler.KeyToPress(hero);

        if (input == "y")
        {
            Console.WriteLine("\nYour friend joins you, boosting your confidence and strength for the next fight!");
            hero.DMG_min += 2;  // Dodajemy bonus do minimalnych obrażeń
            hero.DMG_max += 3;  // Dodajemy bonus do maksymalnych obrażeń
        }
        else
        {
            Console.WriteLine("You thank him, but decide to continue on your own.");
        }

    }
}
