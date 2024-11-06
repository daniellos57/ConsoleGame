using System;
using System.IO;
using System.Security.Cryptography;
using somewirdsht;
using static Program;
class Program
{
    static void Main()
    {
        Hero hero = new Hero();
        Console.WriteLine("Hello adnevturer! Let's seek for your friends!");
        MapClass.Map(0);
        Console.WriteLine("You just aproached a skeleteon! \n Do you want to FightClass.fight it? (y/n)");
        string input = Console.ReadLine();
        if (input == "y")
            FightClass.fight("Skeleton",10,1,4,11,true,hero);
        else Console.WriteLine("You choose to leave!");
        Console.WriteLine("Let's go to another location!");
        Console.ReadKey();
        MapClass.Map(1);
        Console.WriteLine("You just aproached a City! \n Do you want to talk to old women? (y/n) ");
        input = Console.ReadLine();
        if (input == "y")
        {
            Console.WriteLine("\nShe said that you are one handsome boy and give you some pierogis");
            Console.WriteLine("\nPierogis boost your exp in next FightClass.fight!");
            Console.ReadKey();
            Console.WriteLine("\nSomeone interrupted your dinner! You have to FightClass.fight him!");
            FightClass.fight("Unknown man", 15, 3, 5, 20,false,hero);
            Console.WriteLine("\nYou get some new pierogis and gain full HP!");
            hero.Health = hero.MaxHealth;
        }
        else Console.WriteLine("\nYou choose to leave her alone.");
        Console.WriteLine("\nGrandpa> I just wanna eat some pierogis!");
        Console.WriteLine("\nYou leave them alone and go and search your friends");
        Console.WriteLine("\nYou could swere that one of them just walk streight to that local with dancing ladis");
        Console.ReadKey();
        Console.WriteLine("\nYou approach lady in front and ask her: \nA - Can i go in?\nB - Hey, that was my friend Tomek! Can you ask him\nC - *Ignore her and run inside*");
        input = Console.ReadLine();
        Console.WriteLine("\nLady looked at you and said: ");
        Console.WriteLine("\nLady> You cannot come in, get lost!");
        Console.ReadKey();
        Console.WriteLine("\nYou tried to go from the back but someone saw you and call guards, you have to FightClass.fight!");
        Console.ReadKey();
        FightClass.fight("guards", 20,1, 8, 12, true,hero);
    }
}
