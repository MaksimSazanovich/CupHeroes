using System;
using Internal.Codebase.Runtime.UI.Animations;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines
{
    [RequireComponent(typeof(UIShakeAnimation))]
    [DisallowMultipleComponent]
    public sealed class BoosterLineCollision : MonoBehaviour
    {
        [SerializeField] private UIShakeAnimation uiShakeAnimation;
        private void OnCollisionEnter2D(Collision2D other)
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.transform.position.y > transform.position.y)
                uiShakeAnimation.Animate();
        }
    }
}