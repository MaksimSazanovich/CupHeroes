using System.ComponentModel;
using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Factories.MultipliersFactory
{
    public class MultipliersFactory : IMultipliersFactory
    {
        private IResourceProvider resourceProvider;
        private DiContainer container;

        [Inject]
        private void Constructor(IResourceProvider resourceProvider, DiContainer container)
        {
            this.container = container;
            this.resourceProvider = resourceProvider;
        }

        public MultiplierX CreateMultiplierX(int value, Vector2 size, Vector3 position)
        {
            var config = resourceProvider.LoadMultipliersConfig();
            //var multiplierX = Object.Instantiate(config.MultiplierX, position, Quaternion.identity);

            var multiplierX = container.InstantiatePrefab(config.MultiplierX, position, Quaternion.identity, null);
            multiplierX.GetComponent<MultiplierX>().SetSettings(value);
            multiplierX.GetComponent<MultiplierX>().SetSize(size);
            return multiplierX.GetComponent<MultiplierX>();
        }
    }
}