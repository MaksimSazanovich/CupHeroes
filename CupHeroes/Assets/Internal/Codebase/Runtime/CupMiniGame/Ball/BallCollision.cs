using System;
using Internal.Codebase.Runtime.CupMiniGame.Multipliers;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Ball
{
    [DisallowMultipleComponent]
    public sealed class BallCollision : MonoBehaviour
    {
        public static Action<int, int, Vector3> OnCollidedMultiplierX;
        private int lockMultiplierId;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out MultiplierX multiplierX) && multiplierX.Id != lockMultiplierId)
            {
                OnCollidedMultiplierX?.Invoke(multiplierX.Value, multiplierX.Id, transform.position);
                lockMultiplierId = multiplierX.Id;
                
            }
        }
    }
}