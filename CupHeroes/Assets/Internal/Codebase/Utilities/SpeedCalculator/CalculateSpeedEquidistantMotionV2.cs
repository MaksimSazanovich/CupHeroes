namespace Internal.Codebase.Utilities.SpeedCalculator
{
    public static class CalculateSpeedEquidistantMotionV2
    {
        public static float Calculate(float acceleration, float movingTime, float currentTime)
        {
            if (currentTime <= movingTime / 2)
            {
                float startSpeed = acceleration * currentTime;
                return startSpeed + acceleration * currentTime;
            }
            else
            {
                float startSpeed = acceleration * (movingTime - currentTime);
                return startSpeed - acceleration * (currentTime - movingTime / 2);
            }
        }
    }
}