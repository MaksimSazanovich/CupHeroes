using Internal.Codebase.Runtime.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers
{
    [DisallowMultipleComponent]
    public class MultiplierX : BoosterLine
    {
        [field: SerializeField] public int Value { get; private set; }

        protected override void OnValidate()
        {
            base.OnValidate();
            SetSettings(Value);
        }

        public void SetSettings(int value)
        {
            Value = value;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Text valueText = GetComponentInChildren<Text>();

            string title = $"X{value}";
            valueText.text = title;
            gameObject.name = title;

            switch (value)
            {
                case 2:
                    spriteRenderer.color = Colors.x2;
                    break;
                case 3:
                    spriteRenderer.color = Colors.x2;
                    break;
                case 4:
                    spriteRenderer.color = Colors.x4;
                    break;
                case 5:
                    spriteRenderer.color = Colors.x5;
                    break;
                case 6:
                    spriteRenderer.color = Colors.x5;
                    break;
                case 7:
                    spriteRenderer.color = Colors.x5;
                    break;
            }
        }
    }
}