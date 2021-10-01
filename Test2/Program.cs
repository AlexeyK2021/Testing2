using System;
using System.Collections;

namespace Test2
{
    class Program
    {
        private static bool isControl = true;
        private static bool isChecked = false;
        private static Animal animal_ = null;

        static void Main(string[] args)
        {
            while (isControl)
            {
                while (animal_ == null)
                {
                    Console.WriteLine("You should chose the animal to control:\n" +
                                      "Press 1 for Dog\n" +
                                      "Press 2 for Bird");

                    ConsoleKey key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.D2 && !isChecked)
                    {
                        animal_ = new Bird();
                        Console.WriteLine("You selected bird");
                        isChecked = true;
                        break;
                    }

                    if (key == ConsoleKey.D1 && !isChecked)
                    {
                        animal_ = new Dog();
                        Console.WriteLine("You selected dog");
                        isChecked = true;
                        break;
                    }

                    Console.WriteLine("Unknown key.");
                }

                while (isChecked)
                {
                    DoAction(animal_, Console.ReadKey(true).Key);
                }
            }
        }

        private static void DoAction(Animal animal, ConsoleKey key)
        {
            if (key == ConsoleKey.Q && isChecked)
            {
                animal_ = null;
                isChecked = false;
                return;
            }

            if (key == ConsoleKey.F)
            {
                animal.Eat();
            }
            else if (key == ConsoleKey.Z)
            {
                animal.Sleep(Convert.ToInt32(new Random().NextDouble() * 10));
            }
            else if (animal is Dog)
            {
                if (key == ConsoleKey.A)
                {
                    ((Dog)animal).Run(-1, 0);
                }
                else if (key == ConsoleKey.W)
                {
                    ((Dog)animal).Run(0, 1);
                }
                else if (key == ConsoleKey.S)
                {
                    ((Dog)animal).Run(0, -1);
                }
                else if (key == ConsoleKey.D)
                {
                    ((Dog)animal).Run(1, 0);
                }
                else if (key == ConsoleKey.G)
                {
                    ((Dog)animal).Bark();
                }
                else if (key == ConsoleKey.R)
                {
                    ((Dog)animal).Bite();
                }
                else if (key == ConsoleKey.E)
                {
                    ArrayList comands = new ArrayList() { "voice", "sit", "fas" };
                    int number = Convert.ToInt32(new Random().NextDouble());
                    ((Dog)animal).DoCommand(comands[number % 3].ToString());
                }
            }
            else if (animal is Bird)
            {
                if (key == ConsoleKey.A)
                {
                    ((Bird)animal).Fly(-1, 0);
                }
                else if (key == ConsoleKey.W)
                {
                    ((Bird)animal).Fly(0, 1);
                }
                else if (key == ConsoleKey.S)
                {
                    ((Bird)animal).Fly(0, -1);
                }
                else if (key == ConsoleKey.D)
                {
                    ((Bird)animal).Fly(1, 0);
                }
                else if (key == ConsoleKey.G)
                {
                    ((Bird)animal).LayEggs();
                }
                else if (key == ConsoleKey.R)
                {
                    ((Bird)animal).BuildNest();
                }
                else if (key == ConsoleKey.C)
                {
                    isControl = false;
                }
            }
        }
    }
}