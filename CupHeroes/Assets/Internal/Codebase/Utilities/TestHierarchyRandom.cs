using NaughtyAttributes;
using UnityEngine;

namespace Internal.Codebase.Utilities
{
    [DisallowMultipleComponent]
    public sealed class TestHierarchyRandom : MonoBehaviour
    {
        [SerializeField] private int minValue;
        [SerializeField] private int maxValue;
        [Button]
        private void Test()
        {
            Debug.Log($"HierarchyRandom {HierarchyRandom.Range(minValue, maxValue)}"); 
        }
    }
}