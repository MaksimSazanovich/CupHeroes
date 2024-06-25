using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers.HorizontalMovingPlatform
{
    [DisallowMultipleComponent]
    public sealed class DoTweenHorizontalMovementPlatform : MonoBehaviour
    {
        [SerializeField] private float leftPointX;
        [SerializeField] private float rightPointX;

        [SerializeField] private float stopTime = 1;
        [SerializeField] private float movingTime;
        [SerializeField] private Points startPoint;
        [SerializeField] private Ease firstEase;
        [SerializeField] private Ease secondEase;


        private bool canMove = true;

        private float currentTarget;

        private void Awake()
        {
            if (startPoint == Points.leftPoint)
            {
                currentTarget = rightPointX;
                transform.position = new(leftPointX, transform.position.y);
            }
            else
            {
                currentTarget = leftPointX;
                transform.position = new(rightPointX, transform.position.y);
            }
        }

        private void Start()
        {
            Move();
        }

        private void Move()
        {
            transform.DOMoveX((rightPointX-leftPointX)/2, movingTime/2).SetEase(firstEase).OnComplete(() =>
                    transform.DOMoveX(currentTarget, movingTime/2).SetEase(secondEase)).OnComplete(() =>
                    currentTarget = (currentTarget == leftPointX) ? rightPointX : leftPointX).SetDelay(stopTime)
                .OnComplete(() => Move());
        }
    }
}