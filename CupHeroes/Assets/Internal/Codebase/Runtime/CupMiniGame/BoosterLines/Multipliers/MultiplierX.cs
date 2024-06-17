using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.Multipliers
{
    [DisallowMultipleComponent]
    public sealed class MultiplierX : MonoBehaviour
    {
        [field: SerializeField] public int Value { get; private set; }
        [field: SerializeField] public int Id { get; private set; }

        [SerializeField] private BoxCollider2D boxCollider2D;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private void OnValidate()
        {
            boxCollider2D.size = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
        }  
    }
}