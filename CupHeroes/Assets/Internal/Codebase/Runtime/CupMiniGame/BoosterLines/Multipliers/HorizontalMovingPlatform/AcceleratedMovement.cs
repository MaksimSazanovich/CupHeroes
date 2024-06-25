using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers.HorizontalMovingPlatform
{
    [DisallowMultipleComponent]
    public sealed class AcceleratedMovement : MonoBehaviour
    {
        public Vector3 target;          // Цель движения
        public float maxSpeed = 5f;        // Максимальная скорость
        public float acceleration = 2f;   // Ускорение
        public float deceleration = 2f;   // Замедление

        private float currentSpeed = 0f; // Текущая скорость
        private bool isAccelerating = true;// Флаг разгона

        void Update()
        {
            // Проверяем, достигли ли мы середины пути
            if (Vector3.Distance(transform.position, target) <
                Vector3.Distance(transform.position, target) / 2f && isAccelerating)
            {
                isAccelerating = false;
            }

            // Разгон
            if (isAccelerating)
            {
                currentSpeed += acceleration * Time.deltaTime;
                currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
            }
            // Торможение
            else
            {
                currentSpeed -= deceleration * Time.deltaTime;
                currentSpeed = Mathf.Max(currentSpeed, 0f);
            }

            // Движение объекта
            transform.position =
                Vector3.MoveTowards(transform.position, target, currentSpeed * Time.deltaTime);

            // Остановка объекта, если достиг цели
            if (transform.position == target)
            {
                currentSpeed = 0f;
            }
        }
    }
}