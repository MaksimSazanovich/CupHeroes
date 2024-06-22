using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Factories.MultipliersFactory
{
    public class MultipliersFactory : IMultipliersFactory
    {
        private IResourceProvider resourceProvider;

        [Inject]
        private void Constructor(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }

        public MultiplierX CreateMultiplierX(int value, Vector2 size, Vector3 position)
        {
            var config = resourceProvider.LoadMultipliersConfig();
            var multiplierX = Object.Instantiate(config.MultiplierX, position, Quaternion.identity);
            multiplierX.SetSettings(value);
            multiplierX.SetSize(size);
            return multiplierX;
        }
    }
}