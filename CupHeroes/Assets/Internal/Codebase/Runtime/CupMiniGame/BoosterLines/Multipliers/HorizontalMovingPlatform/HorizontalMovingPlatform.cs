using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Utilities.SpeedCalculator;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers.HorizontalMovingPlatform
{
    public sealed class HorizontalMovingPlatform : MonoBehaviour
    {
        [SerializeField] private float leftPointX;
        [SerializeField] private float rightPointX;

        [SerializeField] private float movingTime;

        [SerializeField] private float acceleration = 1;

        //[SerializeField] private float speed = 1;
        [SerializeField] private float stopTime = 1;

        [SerializeField] private Points startPoint;

        [SerializeField] private MovingTypes movingTypes;


        private bool canMove = true;

        private Vector3 currentTarget;
        private Vector3 leftPoint;
        private Vector3 rightPoint;

        private float stopTimer;
        private float currentTime;
        private float maxDistanceDelta;
        [SerializeField] private float linearSpeed;

        private void Awake()
        {
            leftPoint = new Vector3(leftPointX, transform.position.y);
            rightPoint = new Vector3(rightPointX, transform.position.y);

            if (startPoint == Points.leftPoint)
            {
                currentTarget = rightPoint;
                transform.position = leftPoint;
            }
            else
            {
                currentTarget = leftPoint;
                transform.position = rightPoint;
            }

            stopTimer = stopTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BallCollision ballCollision) && transform.position.y <= other.transform.position.y)
                Stop();
        }

        private void FixedUpdate()
        {
            if (canMove)
            {
                currentTime += Time.fixedDeltaTime;

                if (movingTypes == MovingTypes.math)
                {
                    transform.position = Vector3.MoveTowards(transform.position, currentTarget,
                        CalculateSpeedEquidistantMotion.Calculate(movingTime, (rightPointX - leftPointX)) *
                        Time.fixedDeltaTime);
                }
                else if (movingTypes == MovingTypes.math)
                {
                    if (currentTime < movingTime / 2)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, currentTarget,
                            acceleration * Mathf.Pow(currentTime, 2) / 2 -
                            acceleration * Mathf.Pow(currentTime - Time.fixedDeltaTime, 2) / 2);
                    }
                    else
                    {
                        float maxSpeed = acceleration * movingTime / 2;
                        float time = currentTime - movingTime / 2;
                        maxDistanceDelta = Mathf.Abs((maxSpeed * time - acceleration * Mathf.Pow(time, 2) / 2) -
                                                     (maxSpeed * (time - Time.fixedDeltaTime) - acceleration *
                                                         Mathf.Pow(time - Time.fixedDeltaTime, 2) / 2));
                        Debug.Log(nameof(maxSpeed) + maxSpeed);
                        Debug.Log(nameof(time) + time);
                        Debug.Log(maxDistanceDelta);
                        transform.position = Vector3.MoveTowards(transform.position, currentTarget,
                            maxDistanceDelta);
                    }
                }

                else
                    transform.position = Vector3.MoveTowards(transform.position, currentTarget, linearSpeed * Time.fixedDeltaTime);


                if (Vector3.Distance(transform.position, currentTarget) < 0.01f)
                {
                    stopTimer -= Time.fixedDeltaTime;

                    if (stopTimer <= 0f)
                    {
                        currentTarget = (currentTarget == leftPoint) ? rightPoint : leftPoint;
                        stopTimer = stopTime;

                        Debug.Log(currentTime);
                        currentTime = 0;
                    }
                }
            }
        }

        private void Stop() => canMove = false;
    }

    public enum MovingTypes
    {
        math,
        physic,
        linear
    }
}