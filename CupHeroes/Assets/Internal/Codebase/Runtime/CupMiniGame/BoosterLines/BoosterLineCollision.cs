using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Runtime.UI.Animations;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines
{
    [RequireComponent(typeof(UIShakeAnimation))]
    [DisallowMultipleComponent]
    public sealed class BoosterLineCollision : MonoBehaviour
    {
        [SerializeField] private UIShakeAnimation uiShakeAnimation;
        [SerializeField] private BoosterLine boosterLine;
  
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.TryGetComponent(out BallCollision ballCollision) &&
               !ballCollision.LockBoosterLineIDs.Contains(boosterLine.ID) && other.transform.position.y > transform.position.y)
                uiShakeAnimation.Animate();
        }
    }
}