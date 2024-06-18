
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.BallSpawnOffsetCalculator
{
    public interface IOffsetCalculator
    {
        public Vector3 CalculateOffset(Vector3 position, float offset);
    }
}