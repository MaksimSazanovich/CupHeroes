using UnityEngine;

namespace Internal.Codebase.Utilities.SpeedCalculator
{
    public static class CalculateSpeedEquidistantMotion
    {
        private const float koef = 1.8f;

        public static float Calculate(float time, float path)
        {
            return path / time * Smooth(time);
        }

        private static float Smooth(float time)
        {
            float x = Time.time % time / time;
            return koef * x * (1 - x);
        }
    }
}