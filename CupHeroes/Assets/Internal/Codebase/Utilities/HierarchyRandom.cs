using UnityEngine;

namespace Internal.Codebase.Utilities
{
    public static class HierarchyRandom
    {
        public static int Range(int minValue, int maxValue)
        {
            int firstSum = maxValue - minValue + 1;
            int sum = firstSum * (firstSum + 1) / 2 + 1;
            int randomValue = Random.Range(1, sum);
            int min = 0;
            int max = 1;
            for (int i = 1; i <= firstSum + 1; i++)
            {
                min += i;
                max = min + i + 1;
                if (randomValue == 1)
                {
                    return maxValue;
                }
                if (randomValue >= min && randomValue <= max)
                {
                    int group = i + 1;
                    return maxValue - group + 1;
                }
            }
            return 0;
        }
    }
}