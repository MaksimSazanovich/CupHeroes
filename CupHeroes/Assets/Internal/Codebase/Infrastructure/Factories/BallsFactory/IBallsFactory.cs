using System.Collections.Generic;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories.BallsFactory
{
    public interface IBallsFactory
    {
        public Ball CreateBall(Transform at, Vector3 postion, HashSet<int> lockBoosterLineIDs);
        public Ball CreateBall(Transform at, Vector3 postion);
    }
}