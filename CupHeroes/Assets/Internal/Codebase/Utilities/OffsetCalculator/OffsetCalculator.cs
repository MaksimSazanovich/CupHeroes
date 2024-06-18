using UnityEngine;

namespace Internal.Codebase.Utilities.OffsetCalculator
{
    public static class OffsetCalculator 
    {
        public static Vector3 Calculate(Vector3 position, float offset)
        {
            return new Vector3(Random.Range(position.x - offset, position.x + offset), Random.Range(position.y - offset, position.y + offset), 0);
        }
    }
}