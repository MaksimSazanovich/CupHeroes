using Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories.MultipliersFactory
{
    public interface IMultipliersFactory
    {
        public MultiplierX CreateMultiplierX(int value, Vector2 size, Vector3 position);
    }
}