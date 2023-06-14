using System;
namespace RPG.Helpers
{
    public static class RNG
    {
        /*
		* Our random generator
		*/
        private static Random _generator = new Random(Guid.NewGuid().GetHashCode());

        /*
		* Returns a random number between X and Y+1
		*/
        public static int RandomInt(int min, int max)
        {
            return _generator.Next(min, max + 1);
        }

        /*
		* Returns a random percentage between 0 and 100
		*/
        public static int RandomPercentage()
        {
            return _generator.Next(0, 100);
        }

        /*
		* Returns a random percentage between X and Y
		*/
        public static int RandomPercentage(int min, int max)
        {
            return _generator.Next(min, max);
        }

        /*
		* Returns a random double between X and Y
		*/
        public static double RandomDouble(double min, double max)
        {
            return _generator.NextDouble() * (max - min) + min;
        }

        /*
		* Returns a boolean based on if RandomPercentage() returns 50+ %
		*/
        public static bool CoinFlip()
        {
            return RandomPercentage() > 50;
        }
    }
}

