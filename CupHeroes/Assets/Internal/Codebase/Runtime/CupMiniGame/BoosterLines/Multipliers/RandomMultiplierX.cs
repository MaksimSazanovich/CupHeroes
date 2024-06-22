using Internal.Codebase.Infrastructure.Factories.MultipliersFactory;
using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers
{
    [DisallowMultipleComponent]
    public sealed class RandomMultiplierX : BoosterLine
    {
        private IMultipliersFactory multipliersFactory;
        private IResourceProvider resourceProvider;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        [Inject]
        private void Constructor(IMultipliersFactory multipliersFactory, IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
            this.multipliersFactory = multipliersFactory;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BallCollision ballCollision))
            {
                int randomValue = Random.Range(resourceProvider.LoadMultipliersConfig().MinValue,
                    resourceProvider.LoadMultipliersConfig().MaxValue);
                Debug.Log(randomValue);
                
                multipliersFactory.CreateMultiplierX(randomValue, spriteRenderer.size, transform.position);
                gameObject.SetActive(false);
            }
        }
    }
}