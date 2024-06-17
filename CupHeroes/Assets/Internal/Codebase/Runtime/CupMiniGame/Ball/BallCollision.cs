using System;
using Internal.Codebase.Runtime.CupMiniGame.Multipliers;
using NTC.Pool;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Ball
{
    [DisallowMultipleComponent]
    public sealed class BallCollision : MonoBehaviour
    {
        public static Action<int, int, Vector3> OnCollidedMultiplierX;
        private int lockMultiplierId;

        public void Constructor(int lockMultiplierId)
        {
            this.lockMultiplierId = lockMultiplierId;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out MultiplierX multiplierX) && multiplierX.Id != lockMultiplierId)
            {
                lockMultiplierId = multiplierX.Id;
                OnCollidedMultiplierX?.Invoke(multiplierX.Value, multiplierX.Id, transform.position);
                Despawn();
            }
        }

        private void Despawn()
        {
            lockMultiplierId = 0;
            NightPool.Despawn(gameObject);
        }
    }
}