using System;
using System.Collections.Generic;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.PusherUp;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Ball
{
    [DisallowMultipleComponent]
    public sealed class BallCollision : MonoBehaviour
    {
        public static Action<int, int, Vector3> OnCollidedBoosterLine;
        private int lockBoosterLineId;
        private HashSet<int> lockBoosterLineID = new();

        public void Constructor(int lockMultiplierID)
        {
            lockBoosterLineID.Add(lockMultiplierID);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BoosterLine boosterLine) && !lockBoosterLineID.Contains(boosterLine.ID) &&
                transform.position.y > other.transform.position.y)
            {
                lockBoosterLineID.Add(boosterLine.ID);

                if (other.TryGetComponent(out MultiplierX multiplierX))
                {
                    OnCollidedBoosterLine?.Invoke(multiplierX.Value - 1, multiplierX.ID, transform.position);
                }

                if (other.TryGetComponent(out PusherUp pusherUp))
                {
                    lockBoosterLineID.Clear();
                }
            }
        }
    }
}