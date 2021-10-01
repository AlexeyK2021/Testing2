using System;

namespace Test2
{
    public class Dog : Animal
    {
        public Dog(int x = 0, int y = 0) : base(x, y)
        {
        }

        public void DoCommand(String command)
        {
            if (command == "sit")
            {
                Console.WriteLine("I'm sitting now");
            }
            else if (command == "voice")
            {
                Console.WriteLine("I'm doing voice now");
            }
            else if (command == "fas")
            {
                Console.WriteLine("I'm fassing now");
            }
        }

        public void Run(int vectorX, int vectorY)
        {
            Move(vectorX, vectorY);
            Console.WriteLine($"I'm running. Now I'm at ( {PosX} ; {PosY} )");
        }

        public void Bark()
        {
            Console.WriteLine("Woof woof");
        }

        public void Bite()
        {
            Console.WriteLine("Biting somebody");
        }
    }
}