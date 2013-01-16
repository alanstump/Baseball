using System;

namespace Baseball.Lib.Utils
{
    public static class PercentHelper
    {
        public static double CalculateAverage(int atBats, int hits)
        {
            if (atBats == 0)
                return 0;

            return Math.Round(hits / (double) atBats, 3);
        }

        public static double CalculateOnBasePercentage(int atBats, int hits, int walks)
        {
            if (atBats + walks == 0)
                return 0;

            return Math.Round((hits + walks) / (double)(atBats + walks), 3);
        }
    }
}