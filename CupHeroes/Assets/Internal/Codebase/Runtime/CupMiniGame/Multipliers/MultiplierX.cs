using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Multipliers
{
    [DisallowMultipleComponent]
    public sealed class MultiplierX : MonoBehaviour
    {
        [field: SerializeField] public int Value { get; private set; }
        [field: SerializeField] public int Id { get; private set; }
    }
}