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
  
        public void TriggerEnter2D(BallCollision ballCollision)
        {
            if(!ballCollision.LockBoosterLineIDs.Contains(boosterLine.ID))
                uiShakeAnimation.Animate();
        }
    }
}