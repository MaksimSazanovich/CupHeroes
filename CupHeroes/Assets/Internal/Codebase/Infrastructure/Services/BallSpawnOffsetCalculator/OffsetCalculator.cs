using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.BallSpawnOffsetCalculator
{
    static class OffsetCalculator 
    {
        public static Vector3 CalculateOffset(Vector3 position, float offset)
        {
            return new Vector3(Random.Range(position.x - offset, position.x + offset), Random.Range(position.y - offset, position.y + offset), 0);
        }
    }
}