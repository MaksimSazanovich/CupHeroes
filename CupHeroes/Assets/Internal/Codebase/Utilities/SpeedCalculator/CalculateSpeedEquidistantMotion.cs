using UnityEngine;

namespace Internal.Codebase.Utilities.SpeedCalculator
{
    public static class CalculateSpeedEquidistantMotion
    {
        private const float koef = 2.6f;

        public static float Calculate(float movingTime, float path)
        {
            return path / movingTime * Smooth(movingTime);
        }

        private static float Smooth(float time)
        {
            float x = Time.time % time / time;
            return koef * x * (1 - x);
        }
    }
}