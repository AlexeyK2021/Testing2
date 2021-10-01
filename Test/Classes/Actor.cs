using System;
using static Test.Classes.DisplayClass;

namespace Test.Classes
{
    public abstract class Actor
    {
        protected int Hp;
        protected bool IsAlive;
        public bool DoingSmth = true;
        protected bool CanMove = true;

        private struct Axis
        {
            private static int x;
            private static int y;


            public Axis(int x = 0, int y = 0)
            {
                Axis.x = x;
                Axis.y = y;
            }

            public static int GetX()
            {
                return x;
            }

            public static int GetY()
            {
                return y;
            }

            public static void SetX(int x)
            {
                Axis.x = x;
            }

            public static void SetY(int y)
            {
                Axis.y = y;
            }
        }

        public abstract void Update(ConsoleKey key);

        protected Actor(int hp)
        {
            Hp = hp;
            IsAlive = true;
        }

        public void Move(int x, int y)
        {
            if (CanMove)
            {
                if (IsAlive)
                {
                    Axis.SetX(Axis.GetX() + x);
                    Axis.SetY(Axis.GetY() + y);
                    Display("Moving");
                }
                else Display("I'm Died, I can't roll!");
            }
            else Display("I can't move");
        }
        
        public void Roll()
        {
            Display(IsAlive ? "Rolling..." : "I'm Died, I can't roll!");
        }

        public void TakeDamage(int damage)
        {
            if (IsAlive)
            {
                Hp -= damage;
                if (Hp <= 0)
                {
                    Display("Oh, I take {damage} damage points. I'm died!");
                    IsAlive = false;
                }
                else
                {
                    Display($"Oh, I take {damage} damage points. I still have {Hp}");
                }
            }
            else Display("I'm Died! I can't take damage!");
        }
    }
}