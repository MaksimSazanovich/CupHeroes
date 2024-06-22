using System;
using System.Collections;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Cup
{
    [DisallowMultipleComponent]
    public sealed class CupDropController : MonoBehaviour
    {
        public Action OnDropped;
        
        private CupMovementController movementController;
        private bool canDrop = true;
        private float timeBeforeDrop = 0.3f;

        private void Awake()
        {
            movementController = GetComponent<CupMovementController>();
        }

        private void OnEnable()
        {
            movementController.OnMouseDown += Push;
        }

        private void OnDisable()
        {
            movementController.OnMouseDown -= Push;
        }

        private void Push()
        {
            if (canDrop)
                StartCoroutine(DropTimer());
        }
        
        private IEnumerator DropTimer()
        {
            canDrop = false;
            yield return new WaitForSeconds(timeBeforeDrop);
            OnDropped?.Invoke();
        }
    }
}