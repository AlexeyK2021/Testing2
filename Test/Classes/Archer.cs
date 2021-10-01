using System;
using static Test.Classes.DisplayClass;

namespace Test.Classes
{
    public class Archer : Actor
    {
        private static Quiver quiver;

        public Archer(int hp, int numbersOfArrows) : base(hp)
        {
            Display($"I'm an Archer and I spawn now. I have {Hp} HP.");
            quiver = new Quiver(numbersOfArrows);
        }

        public override void Update(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Spacebar:
                    Jump();
                    break;
                case ConsoleKey.F:
                    Shoot();
                    break;
                case ConsoleKey.R:
                    Reload();
                    break;
                case ConsoleKey.T:
                    Random random = new Random();
                    Teleport(Convert.ToInt32(random.NextDouble() * 100),
                        Convert.ToInt32(random.NextDouble() * 100));
                    break;
                default: break;
            }
        }

        private void Shoot()
        {
            if (IsAlive)
            {
                Display(quiver.canShoot() ? "Shot " : "I can't shoot! I need to reload!");
            }
            else Display("I'm Died, I can't shoot!");
        }

        private void Jump()
        {
            Display(IsAlive ? "Jumping " : "I'm Died, I can't jump!");
        }

        private void Reload()
        {
            if (IsAlive)
            {
                Display("Reloading");
                quiver.reload();
            }
            else Display("I'm Died, I can't reload!");
        }

        private void Teleport(int x, int y)
        {
            Display(IsAlive ? $"I'm teleport to ({x} ; {y})" : "I'm Died! I can't teleport!");
        }
    }
}