using System;

namespace Test2
{
    public abstract class Animal
    {
        protected int PosX { get; set; }
        protected int PosY { get; set; }

        protected Animal(int x, int y)
        {
            PosX = x;
            PosY = y;
        }

        protected void Move(int vectorX, int vectorY)
        {
            PosX += vectorX;
            PosY += vectorY;
        }

        public void Eat()
        {
            Console.WriteLine("Eating");
        }

        public void Sleep(int hours)
        {
            Console.WriteLine($"I will sleep for {hours} hours");
        }
    }
}