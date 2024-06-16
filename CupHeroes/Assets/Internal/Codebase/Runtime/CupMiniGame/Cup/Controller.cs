using System;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Cup
{
    [DisallowMultipleComponent]
    public sealed class Controller : MonoBehaviour
    {
        private Camera camera;
        private Vector3 mousePosition;
        private Vector3 screenBounds;
        [SerializeField] private float offset;

        private void Start()
        {
            camera = Camera.main;
            screenBounds = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)) - Vector3.one * offset;
        }

        private void Update()
        {
            CheckBoundaries();
            if (Input.GetMouseButton(0))
            {
                mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(mousePosition.x, transform.position.y, 0);
            }
        }

        private void CheckBoundaries()
        {
            float x = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x);
            transform.position = new Vector3(x, transform.position.y, 0);
        }
    }
}