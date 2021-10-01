using System;
using static Test.Classes.DisplayClass;

namespace Test.Classes
{
    public class Warrior : Actor
    {
        private static bool isBlocking = false;

        public Warrior(int hp) : base(hp)
        {
            Display($"I'm a Warrior and I spawn now. I have {Hp} HP.");
        }

        private void DoBlock()
        {
            if (IsAlive)
            {
                if (isBlocking)
                {
                    Display("I'm already blocking! Stopping to block...");
                }
                else
                {
                    CanMove = false;
                    Display("Starting blocking..");
                }

                isBlocking = !isBlocking;
            }
            else Display("I'm Died, I can't blocking!");
        }

        public override void Update(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.F:
                    DoBlock();
                    break;
                default: break;
            }
        }
    }
}