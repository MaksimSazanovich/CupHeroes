using UnityEngine;

namespace Internal.Codebase.Utilities.PositionOffsetCalculator
{
    public static class PositionOffsetCalculator 
    {
        public static Vector3 CalculateBothAxis(Vector3 position, float offset)
        {
            return new Vector3(Random.Range(position.x - offset, position.x + offset), Random.Range(position.y - offset, position.y + offset), 0);
        }

        public static Vector3 CalculateHorizontally(Vector3 position, float offset)
        {
            return new Vector3(Random.Range(position.x - offset, position.x + offset), position.y, 0);  
        }
    }
}