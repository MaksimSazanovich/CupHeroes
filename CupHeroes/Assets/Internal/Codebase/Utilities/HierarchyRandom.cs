using UnityEngine;

namespace Internal.Codebase.Utilities
{
    public static class HierarchyRandom
    {
        public static int Range(int minValue, int maxValue)
        {
            int firstSum = maxValue - minValue + 1;
            int sum = firstSum * (firstSum + 1) / 2 + 1;
            int randomValue = UnityEngine.Random.Range(1, sum);
            Debug.Log($"randomValue {randomValue}");
            int c = 1;
            int p = firstSum;
            for (int i = firstSum - 1; i > 1; i--)
            {
                if (randomValue > p) c++;
                else break;
                p += i;
            }
            return p;


            /*
            10 =>      5
            8,9 =>     4
            5,6,7 =>   3
            1,2,3,4 => 2

            */
        }
    }
}