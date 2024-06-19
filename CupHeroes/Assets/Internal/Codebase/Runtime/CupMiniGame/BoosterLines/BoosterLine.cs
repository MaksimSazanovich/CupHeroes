using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines
{
    [DisallowMultipleComponent]
    public abstract class BoosterLine : MonoBehaviour
    {
        [field: SerializeField] public int ID { get; private set; }

        [SerializeField] private BoxCollider2D boxCollider2D;
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private void OnValidate()
        {
            boxCollider2D.size = new Vector2(spriteRenderer.size.x, spriteRenderer.size.y);
        }  
    }
}