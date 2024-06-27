using System;
using System.Collections.Generic;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.PusherUp;
using NaughtyAttributes;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Ball
{
    [RequireComponent(typeof(CircleCollider2D))]
    [DisallowMultipleComponent]
    public sealed class BallCollision : MonoBehaviour
    {
        private CircleCollider2D collider2D;
        public HashSet<int> LockBoosterLineIDs { get; private set; } = new();
        public static Action<int, HashSet<int>, Vector3> OnCollidedMultiplierX;

        private void Start()
        {
            collider2D = GetComponent<CircleCollider2D>();
        }

        public void Constructor(HashSet<int> lockBoosterLineIDs)
        {
            LockBoosterLineIDs = lockBoosterLineIDs;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BoosterLine boosterLine) && transform.position.y >= other.transform.position.y
                                                                   && !LockBoosterLineIDs.Contains(boosterLine.ID))
            {
            }
        }

        public void LockMultiplierX(MultiplierX multiplierX)
        {
            multiplierX.GetComponent<BoosterLineCollision>().TriggerEnter2D(this);
            LockBoosterLineIDs.Add(multiplierX.ID);
            OnCollidedMultiplierX?.Invoke(multiplierX.Value - 1, new HashSet<int>(LockBoosterLineIDs),
                transform.position);
        }

        public void LockPusherUpID(PusherUp pusherUp)
        {
            pusherUp.GetComponent<BoosterLineCollision>().TriggerEnter2D(this);
            LockBoosterLineIDs.Clear();
            LockBoosterLineIDs.Add(pusherUp.ID);
        }

        public void Lock(BoosterLine boosterLine)
        {
            boosterLine.GetComponent<BoosterLineCollision>().TriggerEnter2D(this);
            switch (boosterLine)
            {
                case MultiplierX:
                {
                    var multiplierX = boosterLine.GetComponent<MultiplierX>();
                    LockBoosterLineIDs.Add(multiplierX.ID);
                    OnCollidedMultiplierX?.Invoke(multiplierX.Value - 1, new HashSet<int>(LockBoosterLineIDs),
                        transform.position);
                }
                    break;
                case PusherUp:
                {
                    var pusherUp = boosterLine.GetComponent<PusherUp>();
                    LockBoosterLineIDs.Clear();
                    LockBoosterLineIDs.Add(pusherUp.ID);
                }
                    break;
            }
        }

        [Button]
        private void DebugHashSet()
        {
            Debug.Log("Start");
            foreach (var lockBoosterLineID in LockBoosterLineIDs)
            {
                Debug.Log(lockBoosterLineID);
            }

            Debug.Log("Finish");
        }
    }
}