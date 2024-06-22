using System.Diagnostics;
using Internal.Codebase.Runtime.Constants;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.Multipliers
{
    [DisallowMultipleComponent]
    public class MultiplierX : BoosterLine
    {
        [field: SerializeField] public int Value { get; private set; }

        private void OnValidate()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Text valueText = GetComponentInChildren<Text>();

            string title = $"X{Value}";
            valueText.text = title;
            gameObject.name = title;
            
            switch (Value)
            {
                case 2: spriteRenderer.color = Colors.x2; break;
                case 3: spriteRenderer.color = Colors.x2; break;
                case 4: spriteRenderer.color = Colors.x4; break;
                case 5: spriteRenderer.color = Colors.x5; break;
                case 6: spriteRenderer.color = Colors.x5; break;
            }
            
        }

    }
}