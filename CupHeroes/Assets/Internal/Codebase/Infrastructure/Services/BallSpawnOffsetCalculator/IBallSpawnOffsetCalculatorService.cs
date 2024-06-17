
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.BallSpawnOffsetCalculator
{
    public interface IBallSpawnOffsetCalculatorService
    {
        public Vector3 CalculateOffset(Vector3 position);
    }
}