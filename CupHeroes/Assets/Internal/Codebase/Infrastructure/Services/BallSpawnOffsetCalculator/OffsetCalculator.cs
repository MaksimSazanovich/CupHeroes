using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.BallSpawnOffsetCalculator
{
    class OffsetCalculator : IOffsetCalculator
    {
        private readonly float offset = 0.1f;

        public Vector3 CalculateOffset(Vector3 position)
        {
            return new Vector3(Random.Range(position.x - offset, position.x + offset), Random.Range(position.y - offset, position.y + offset), 0);
        }
    }
}