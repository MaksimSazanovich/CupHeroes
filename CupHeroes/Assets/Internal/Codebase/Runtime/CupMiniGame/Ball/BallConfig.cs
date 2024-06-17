using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Ball
{
    [CreateAssetMenu(menuName = "StaticData/Create BallConfig", fileName = "BallConfig", order = 1)]
    public class BallConfig : ScriptableObject
    {
        [field: SerializeField] public Ball Ball { get; private set; }
    }
}