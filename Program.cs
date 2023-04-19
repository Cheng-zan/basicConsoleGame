using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;

namespace playGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            wantToPlay();
        }

        static public void wantToPlay()
        {
            string userInput;

            Console.Write("Do you want to play? y/n: ");
            userInput = Console.ReadLine();
            Console.Clear();

            if (userInput == "y" || userInput == "Y")
            {
                rpgGame();
            } 
            else if (userInput == "n" || userInput == "N") 
            {
                Console.WriteLine("You are not playing");
            }
            else
            {
                wantToPlay();
            }
        }

        static public void rpgGame()
        {
            string name;
            bool isPlay = true;
            string userChoice;
            Wizard enemy = new Wizard("Goblin", "acid", 100);
            
            Console.Write("Please insert your name: ");
            name = Console.ReadLine();

            if (name == string.Empty)
            {
                rpgGame();
            }

            Wizard w1 = new Wizard(name , "fire", 200);
            Console.Clear();

            Console.WriteLine($" Hi {name}. U have {w1.spell} spell and have " +
                                $"{w1.spellSlots} spell slots.\n You will fight with {enemy.name}.");
            Console.WriteLine("\n\nClick an key to continue");
            Console.ReadKey();
            Console.Clear();

            while (isPlay)
            {
                Console.WriteLine($"   Name: {enemy.name}   Health: {enemy.health}");
                Console.WriteLine($"   Name: {w1.name}      Health: {w1.health} ");
                Console.WriteLine("\n");
                Console.WriteLine(" Choose your number");

                Console.Write(" 1.Lightning    2.Retreat    3.Meditate : ");
                userChoice = Console.ReadLine();
                Console.Clear();

                if (userChoice == "1")
                {
                    if (w1.spellSlots > 0)
                    {
                        Console.WriteLine("You cast lightning spell");
                        w1.spellSlots--;
                        enemy.health -= 30;
                        Console.WriteLine($"Enemy health : {enemy.health}");
                        Console.ReadLine();
                        Console.Clear();
                        if (enemy.health <= 0)
                        {
                            Console.WriteLine($"{enemy.name} are death");
                            Console.WriteLine("You win");
                            isPlay = false;
                            Console.ReadLine();
                        }
                    }
                    else if (w1.spellSlots == 0)
                    {
                        Console.WriteLine("U doesnt have spell left");
                        Console.WriteLine($"{enemy.name} are using {enemy.spell} ");
                        w1.health -= 40;

                        if (w1.health <= 0)
                        {
                            Console.WriteLine("You death");
                            Console.ReadLine();
                            isPlay = false;
                        } else 
                        { 
                            Console.WriteLine("Your health now is " + w1.health);
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
                else if (userChoice == "2")
                {
                    if(enemy.health < 100)
                    {
                        Console.WriteLine("You cannot retreat. You already distracting enemy");
                        w1.health -= 10;
                        Console.ReadKey();
                        Console.Clear();
                    } 
                    else
                    {
                        Console.WriteLine("you retreat");
                        isPlay = false;
                    }

                }
                else if (userChoice == "3")
                {
                    w1.Meditate();
                    Console.WriteLine($"Your spell has been add to {w1.spellSlots}");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    isPlay = true;
                }
            }
        }
    }

    class Wizard
    {
        public string name;
        public string spell;
        public int spellSlots;
        public int health;
        public int att;

        public Wizard(string _name, string _spell, int _health)
        {
            name = _name;
            spell = _spell;
            spellSlots = 2;
            health = _health;
        }

        public void Meditate()
        {
            spellSlots = 2;
            
        }
    }
}