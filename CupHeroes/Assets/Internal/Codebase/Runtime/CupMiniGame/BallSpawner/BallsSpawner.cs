using System;
using System.Collections;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure.Factories.BallsFactory;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers;
using Internal.Codebase.Runtime.CupMiniGame.Cup;
using Internal.Codebase.Utilities.PositionOffsetCalculator;
using ModestTree;
using NTC.Pool;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Runtime.CupMiniGame.BallSpawner
{
    [DisallowMultipleComponent]
    public sealed class BallsSpawner : MonoBehaviour
    {
        [field: SerializeField] public List<Ball.Ball> Balls { get; private set; }
        [field: SerializeField] public int MaxBallsCount { get; private set; }
        public static Action<int, HashSet<int>, Vector3> OnCollidedBall;

        private IBallsFactory ballsFactory;
        private int ballsOnStartMiniGame = 1;
        private Cup.Cup cup;
        private CupDropController cupDropController;
        private float timeBetweenSpawnFirstBalls = 0.1f;
        private float spawnOffset = 0.1f;

        [Inject]
        public void Constructor(IBallsFactory ballsFactory, Cup.Cup cup, CupDropController cupDropController)
        {
            this.cup = cup;
            this.ballsFactory = ballsFactory;
            this.cupDropController = cupDropController;
        }

        private void OnEnable()
        {
            BallCollision.OnCollidedMultiplierX += CreateSecondBalls;
            cupDropController.OnDropped += Init;
        }

        private void OnDisable()
        {
            BallCollision.OnCollidedMultiplierX -= CreateSecondBalls;
            cupDropController.OnDropped -= Init;
        }

        private void Start()
        {
            if (Balls.IsEmpty())
            {
                CreateFirstBalls();
                DespawnBalls();
            }
        }

        private void Init()
        {
            StartCoroutine(CreateFirstBallsWithDelay());
        }

        private void CreateFirstBalls()
        {
            for (int i = 0; i < MaxBallsCount; i++)
            {
                Balls.Add(ballsFactory.CreateBall(transform, Vector3.zero));
            }
        }
        
        private IEnumerator CreateFirstBallsWithDelay()
        {
            for (int i = 0; i < ballsOnStartMiniGame; i++)
            {
                Balls.Add(ballsFactory.CreateBall(transform, cup.Neck.position));
                yield return new WaitForSeconds(timeBetweenSpawnFirstBalls);
            }
        }

        private void CreateSecondBalls(int count, HashSet<int> lockBoosterLineIDs, Vector3 position)
        {
            for (int i = 0; i < count; i++)
            {
                Balls.Add(ballsFactory.CreateBall(transform, PositionOffsetCalculator.CalculateBothAxis(position, spawnOffset), lockBoosterLineIDs));
            }
        }
        
        private void DespawnBalls()
        {
            for (int i = 0; i < MaxBallsCount; i++)
            {
                NightPool.Despawn(Balls[i]);
            }
        }
    }
}