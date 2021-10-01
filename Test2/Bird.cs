using System;

namespace Test2
{
    public class Bird : Animal
    {
        public Bird(int x = 0, int y = 0) : base(x, y)
        {
        }

        public void Fly(int vectorX, int vectorY)
        {
            Move(vectorX, vectorY);
            Console.WriteLine($"I'm flying. Now I'm at ( {PosX} ; {PosY} )");
        }

        public void LayEggs()
        {
            Console.WriteLine("Laying egg");
        }

        public void BuildNest()
        {
            Console.WriteLine("Building nest");
        }
    }
}