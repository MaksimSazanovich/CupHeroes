using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers
{
    [CreateAssetMenu(fileName = "Multipliers", menuName = "StaticData/Create MultipliersConfig", order = 2)]
    public class MultipliersConfig : ScriptableObject
    {
        [field: SerializeField] public MultiplierX MultiplierX { get; private set; }
        [field: SerializeField] public int MinValue { get; private set; } = 2;
        [field: SerializeField] public int MaxValue { get; private set; }
    }
}