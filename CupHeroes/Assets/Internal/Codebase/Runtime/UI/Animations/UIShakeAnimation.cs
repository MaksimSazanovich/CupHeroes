using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace Internal.Codebase.Runtime.UI.Animations
{
    [DisallowMultipleComponent]
    public sealed class UIShakeAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Vector3 startScale= new Vector3(0.003f,0.003f,0.003f);
        [SerializeField] private Vector3 endScale = new Vector3(0.004f,0.004f,0.004f);
        [SerializeField] private float duration;
        [SerializeField] private Ease ease;

        [Button]
        public void Animate()
        {
            rectTransform.DOScale(endScale, duration).SetEase(ease).OnComplete(() => rectTransform.DOScale(startScale, duration).SetEase(ease));
        }
    }
}