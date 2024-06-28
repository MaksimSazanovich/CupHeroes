using System;
using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using Internal.Codebase.Runtime.Constants;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using Internal.Codebase.Utilities;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;


namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers
{
    [DisallowMultipleComponent]
    public class MultiplierX : BoosterLine
    {
        private IResourceProvider resourceProvider;
        [field: SerializeField] public int Value { get; private set; }
        public static Action<MultiplierX> OnCollidedBall;

        protected override void OnValidate()
        {
            base.OnValidate();
            SetSettings(Value);
        }

        [Inject]
        private void Constructor(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }

        private void Start()
        {
            int randomValue = HierarchyRandom.Range(resourceProvider.LoadMultipliersConfig().MinValue,
                resourceProvider.LoadMultipliersConfig().MaxValue);
            Value = randomValue;
            SetSettings(Value);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BallCollision ballCollision) &&
                transform.position.y < other.transform.position.y && !ballCollision.LockBoosterLineIDs.Contains(ID))
            {
                //ballCollision.LockMultiplierX(this);
                ballCollision.Lock(this);
            }
        }

        public void SetSettings(int value)
        {
            Value = value;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Text valueText = GetComponentInChildren<Text>();

            string title = $"X{value}";
            valueText.text = title;
            gameObject.name = title;

            switch (value)
            {
                case 2:
                    spriteRenderer.color = Colors.x2;
                    break;
                case 3:
                    spriteRenderer.color = Colors.x2;
                    break;
                case 4:
                    spriteRenderer.color = Colors.x4;
                    break;
                case 5:
                    spriteRenderer.color = Colors.x5;
                    break;
                case 6:
                    spriteRenderer.color = Colors.x5;
                    break;
                case 7:
                    spriteRenderer.color = Colors.x5;
                    break;
            }
        }
    }
}