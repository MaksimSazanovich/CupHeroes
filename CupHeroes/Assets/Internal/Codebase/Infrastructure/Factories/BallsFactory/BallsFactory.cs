using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using NTC.Pool;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Factories.BallsFactory
{
    class BallsFactory : IBallsFactory
    {
        private IResourceProvider resourceProvider;

        [Inject]
        private void Constructor(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }
        public Ball CreateBall(Transform at, Vector3 position, int lockMultiplierId)
        {
            var config = resourceProvider.LoadBallConfig();
            var ball = NightPool.Spawn(config.Ball, position, Quaternion.identity, at);
            ball.GetComponent<BallCollision>().Constructor(lockMultiplierId);
            return ball;
        }

        public Ball CreateBall(Transform at, Vector3 postion)
        {
            var config = resourceProvider.LoadBallConfig();
            var ball = NightPool.Spawn(config.Ball, postion, Quaternion.identity, at);
            return ball;
        }
    }
}