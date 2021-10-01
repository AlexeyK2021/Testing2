using System;
using System.Threading;
using Test.Classes;
using static Test.Classes.DisplayClass;

namespace Test
{
    class Program
    {
        private static Actor actor;
        private static bool isControl = true;

        static void Main(string[] args)
        {
            ConsoleKey ck = 0;
            actor = new Archer(50, 5);
            while (isControl)
            {
                for (int i = 0; i < 50; i++)
                {
                    if (Console.KeyAvailable) ck = Console.ReadKey(true).Key;
                    Thread.Sleep(1);
                }

                if (ck == (ConsoleKey)0)
                {
                    if (!actor.DoingSmth)
                    {
                        Display("I'm doing nothing!");
                        actor.DoingSmth = true;
                    }
                }
                else
                {
                    if (actor.DoingSmth)
                    {
                        do_action(ck);
                        actor.DoingSmth = false;
                    }

                    ck = 0;
                }
            }
        }

        private static void do_action(ConsoleKey pushedKey)
        {
            Console.WriteLine();
            switch (pushedKey)
            {
                case ConsoleKey.W:
                    actor.Move(0, 1);
                    break;
                case ConsoleKey.S:
                    actor.Move(0, -1);
                    break;
                case ConsoleKey.A:
                    actor.Move(-1, 0);
                    break;
                case ConsoleKey.D:
                    actor.Move(1, 0);
                    break;
                case ConsoleKey.E:
                    actor.Roll();
                    break;
                case ConsoleKey.M:
                    actor.TakeDamage(10);
                    break;
                case ConsoleKey.C:
                    isControl = false;
                    Display("Breaking game...");
                    break;
                default:
                    actor.Update(pushedKey);
                    break;
            }
        }
    }
}