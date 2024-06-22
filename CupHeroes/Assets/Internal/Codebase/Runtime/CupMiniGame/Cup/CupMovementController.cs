using System;
using System.Collections;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Cup
{
    [DisallowMultipleComponent]
    public sealed class CupMovementController : MonoBehaviour
    {
        private Camera camera;
        private Vector3 mousePosition;
        private Vector3 screenBounds;
        private bool canMove;
        [SerializeField] private float leftBoundary;
        [SerializeField] private float rightBoundary;
        
        public Action OnMouseDown;
        private bool canDrop = true;

        private void Start()
        {
            //canMove = true;
            camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0) /* && canMove*/)
            {
                mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(mousePosition.x, transform.position.y, 0);

                CheckBoundaries();

                OnMouseDown?.Invoke();
            }
        }

        private void CheckBoundaries()
        {
            float x = Mathf.Clamp(transform.position.x, leftBoundary, rightBoundary);
            transform.position = new Vector3(x, transform.position.y, 0);
        }
    }
}