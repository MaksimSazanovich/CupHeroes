// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub:   https://github.com/RimuruDev
//
// **************************************************************** //

using UnityEngine;

namespace AbyssMoth
{
#if UNITY_EDITOR
    [ExecuteAlways]
    [ExecuteInEditMode]
#endif
    [SelectionBase]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(SpriteRenderer))]
    [AddComponentMenu("0xRimuruDev/" + nameof(SpriteShadow))]
    [HelpURL("https://github.com/RimuruDev/Unity-SpriteShadowShader")]
    public sealed class SpriteShadow : MonoBehaviour
    {
        private static readonly int ShadowColor = Shader.PropertyToID("_ShadowColor");
        private static readonly int ShadowOffset = Shader.PropertyToID("_ShadowOffset");

        [SerializeField] private Color shadowColor = new(0, 0, 0, 0.5f);
        [SerializeField] private Vector2 shadowOffset = new(0,0);
        [SerializeField] private ShaderLayers shaderLayers;
        [SerializeField] private int shadowOrderInLayer = -1;

        [SerializeField, HideInInspector] private SpriteRenderer spriteRenderer;
        [SerializeField, HideInInspector] private GameObject shadowObject;
        [SerializeField, HideInInspector] private SpriteRenderer shadowSpriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            CreateShadowObject();
        }

        private void Update() =>
            UpdateShadow();

        [System.Diagnostics.Conditional("UNITY_EDITOR")]
        private void OnValidate() =>
            UpdateShadow();

        private void CreateShadowObject()
        {
            if (shadowObject != null)
                return;

            shadowObject = new GameObject("Shadow")
            {
                transform =
                {
                    parent = transform,
                    localPosition = Vector3.zero,
                    localRotation = Quaternion.identity,
                    localScale = Vector3.one
                }
            };

            shadowSpriteRenderer = shadowObject.AddComponent<SpriteRenderer>();
            shadowSpriteRenderer.sprite = spriteRenderer.sprite;
            shadowSpriteRenderer.material = spriteRenderer.sharedMaterial;
            shadowSpriteRenderer.sortingLayerName = shaderLayers.ToString();
            shadowSpriteRenderer.sortingOrder = shadowOrderInLayer;
        }

        private void UpdateShadow()
        {
            if (spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer component is missing.");
                return;
            }

            if (spriteRenderer.sharedMaterial == null)
            {
                Debug.LogError("SharedMaterial is missing on SpriteRenderer.");
                return;
            }

            if (shadowSpriteRenderer == null)
            {
                CreateShadowObject();
            }

            if (propertyBlock == null)
            {
                propertyBlock = new MaterialPropertyBlock();
            }

            shadowSpriteRenderer.GetPropertyBlock(propertyBlock);
            if (propertyBlock == null)
            {
                Debug.LogError("Failed to get PropertyBlock.");
                return;
            }

            propertyBlock.SetColor(ShadowColor, shadowColor);
            propertyBlock.SetVector(ShadowOffset, shadowOffset);
            shadowSpriteRenderer.SetPropertyBlock(propertyBlock);

            shadowSpriteRenderer.sprite = spriteRenderer.sprite;
            shadowSpriteRenderer.sortingLayerName = shaderLayers.ToString();
            shadowSpriteRenderer.sortingOrder = shadowOrderInLayer;
        }

        private MaterialPropertyBlock propertyBlock;
    }
}
