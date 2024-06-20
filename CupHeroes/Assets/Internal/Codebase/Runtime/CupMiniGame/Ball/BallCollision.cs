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
        public static Action<int, HashSet<int>, Vector3> OnCollidedMultiplierX;
        public static Action<Collider2D> OnCollidedPusherUp;
        private CircleCollider2D collider2D;
        public HashSet<int> LockBoosterLineIDs { get; private set; } = new();

        private void Start()
        {
            collider2D = GetComponent<CircleCollider2D>();
        }

        public void Constructor(HashSet<int> lockBoosterLineIDs)
        {
            LockBoosterLineIDs = lockBoosterLineIDs;
            //DebugHashSet();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            /*if (other.TryGetComponent(out BoosterLine boosterLine) && !LockBoosterLineIDs.Contains(boosterLine.ID)
                                                                   && transform.position.y > other.transform.position.y)
            {*/
                
     
            /*}*/


            if (other.TryGetComponent(out BoosterLine boosterLine))
            {
                // Debug.Log(boosterLine.ID);
                 //Debug.Log(!LockBoosterLineIDs.Contains(boosterLine.ID));
                 DebugHashSet();
                if (!LockBoosterLineIDs.Contains(boosterLine.ID))
                {
                    if (transform.position.y > other.transform.position.y)
                    {
                        
                        if (other.TryGetComponent(out MultiplierX multiplierX))
                        {
                            LockBoosterLineIDs.Add(multiplierX.ID);
                            OnCollidedMultiplierX?.Invoke(multiplierX.Value - 1, new HashSet<int>(LockBoosterLineIDs), transform.position);
                        }

                        else if (other.TryGetComponent(out PusherUp pusherUp))
                        {
                            LockBoosterLineIDs.Clear();
                            LockBoosterLineIDs.Add(pusherUp.ID);
                            OnCollidedPusherUp?.Invoke(collider2D);
                        }
                    }
                }
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