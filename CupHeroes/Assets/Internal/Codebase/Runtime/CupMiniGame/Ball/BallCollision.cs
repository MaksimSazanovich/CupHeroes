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

        private void Start()
        {
            collider2D = GetComponent<CircleCollider2D>();
        }

        private void OnEnable()
        {
            PusherUp.OnFelt += LockPusherUpID;
            MultiplierX.OnCollidedMultiplierX += LockMultiplierX;
        }

        private void LockMultiplierX(int ID, HashSet<int> arg2, Vector3 arg3)
        {
            LockBoosterLineIDs.Add(ID);
        }

        private void OnDisable()
        {
            PusherUp.OnFelt -= LockPusherUpID;
        }

        private void LockPusherUpID(int ID)
        {
            LockBoosterLineIDs.Clear();
            LockBoosterLineIDs.Add(ID);
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
                boosterLine.GetComponent<BoosterLineCollision>().TriggerEnter2D(this);
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