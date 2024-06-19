using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers
{
    [DisallowMultipleComponent]
    public sealed class MultiplierX : BoosterLine
    {
        [field: SerializeField] public int Value { get; private set; }

    }
}