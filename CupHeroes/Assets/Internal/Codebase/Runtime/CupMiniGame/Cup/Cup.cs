using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Cup
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CupMovementController))]
    public sealed class Cup : MonoBehaviour
    {
        [field: SerializeField] public Transform Neck { get; private set; }
    }
}