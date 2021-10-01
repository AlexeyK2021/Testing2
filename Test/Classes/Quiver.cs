using static Test.Classes.DisplayClass;

namespace Test.Classes
{
    public class Quiver
    {
        private static int numbersOfArrows;
        private static int arrowsNow;

        public Quiver(int numbersOfArrows_)
        {
            numbersOfArrows = numbersOfArrows_;
            arrowsNow = numbersOfArrows;
        }

        public bool isEmpty()
        {
            return arrowsNow == 0 ? true : false;
        }

        public void reload()
        {
            arrowsNow = numbersOfArrows;
        }

        public bool canShoot()
        {
            if (arrowsNow > 0)
            {
                arrowsNow--;
                return true;
            }

            return false;
        }

        
    }
}