using System;

namespace RPG.Helpers
{
    public static class CMath
    {
        /*
		* Calculate the amount of weapons a creature/humanniod should have
		*/
        public static int PercentageToWeapons(int min = 0, int max = 100)
        {
            var percentage = RNG.RandomPercentage(min, max);
            switch (true)
            {
                // define a new variable (value) and the case happens when value == percentage >= X && percentage < Y
                case var value when (percentage >= 90):
                    return 4;
                case var value when (percentage >= 70 && percentage < 90):
                    return 3;
                case var value when (percentage >= 50 && percentage < 70):
                    return 2;
                case var value when (percentage >= 30 && percentage < 50):
                    return 1;
                case var value when (percentage >= 20 && percentage < 30):
                    return 0;
                default:
                    return 0;

            }
        }
    }
}
