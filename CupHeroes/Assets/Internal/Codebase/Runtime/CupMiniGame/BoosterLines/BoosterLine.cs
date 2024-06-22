using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines
{
    [DisallowMultipleComponent]
    public abstract class BoosterLine : MonoBehaviour
    {
        [field: SerializeField] public int ID { get; private set; }

        [SerializeField] private BoxCollider2D boxCollider2D;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private RectTransform canvas;
        
        protected virtual void OnValidate()
        {
            SetSize(spriteRenderer.size);
        }

        public void SetSize(Vector2 size)
        {
            spriteRenderer.size = size;
            boxCollider2D.size = new Vector2(size.x, size.y);
            canvas.sizeDelta = new(size.x, size.y);
        }
    }
}