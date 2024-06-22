using System;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers
{
    public sealed class HorizontalMovingPlatform : MonoBehaviour
    {
        [SerializeField] private float leftPointX;
        [SerializeField] private float rightPointX;
        [SerializeField] private float speed = 1;
        private readonly float stopTime = 0.5f;
        
        private bool canMove = true;
        
        private Vector3 currentTarget;
        private Vector3 leftPoint;
        private Vector3 rightPoint;

        private float waitTimer;
        private float waitTime = 1;

        private void Awake()
        {
            currentTarget = new Vector3(leftPointX, transform.position.y);
            transform.position = currentTarget;
            waitTimer = waitTime;
            leftPoint = new Vector3(leftPointX, transform.position.y);
            rightPoint = new Vector3(rightPointX, transform.position.y);
        }

        private void Start()
        {
            
        }

        private void OnEnable()
        {
            BallCollision.OnCollideHorizontalMovingPlatform += Stop;
        }

        private void OnDisable()
        {
            BallCollision.OnCollideHorizontalMovingPlatform -= Stop;
        }

        private void Update()
        {
            if (canMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, currentTarget) < 0.01f)
                {
                    waitTimer -= Time.deltaTime;

                    if (waitTimer <= 0f)
                    {
                        currentTarget = (currentTarget == leftPoint) ? rightPoint : leftPoint;
                        waitTimer = waitTime;
                    }
                }
            }
        }

        private void Stop() => canMove = false;
    }
}