namespace Internal.Codebase.Utilities.SpeedCalculator
{
    public static class CalculateSpeedEquidistantMotionV2
    {
        public static float Calculate(float acceleration, float movingTime, float currentTime)
        {
            float maxSpeed = acceleration * (movingTime / 2);
            
            if (currentTime <= movingTime / 2)
                return acceleration * currentTime;
            else return maxSpeed - acceleration * (currentTime - movingTime / 2);
        }
    }
}