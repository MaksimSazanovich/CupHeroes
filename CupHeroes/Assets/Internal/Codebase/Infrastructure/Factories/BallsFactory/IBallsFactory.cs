using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Runtime.CupMiniGame.BallSpawner;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories.BallsFactory
{
    public interface IBallsFactory
    {
        public Ball CreateBall(Transform at, Vector3 postion, int lockMultiplierId);
        public Ball CreateBall(Transform at, Vector3 postion);
    }
}