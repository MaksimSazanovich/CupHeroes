using System.Collections;
using Internal.Codebase.Runtime.Constants;
using Internal.Codebase.Utilities.OffsetCalculator;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.PusherUp
{
    [DisallowMultipleComponent]
    public sealed class PusherUp : MonoBehaviour
    {
        private const float Force = 15;
        private Collider2D collisionGameObject;
        private float invincibleTime = 10;

        private void OnTriggerEnter2D(Collider2D other)
        {
            collisionGameObject = other;
            StartCoroutine(ChangeCollisionObjectLayer());
            PushUp();
        }

        private void PushUp()
        {
            Rigidbody2D otherRigidbody2D = collisionGameObject.GetComponent<Rigidbody2D>();
            otherRigidbody2D.velocity = Vector2.zero;
            otherRigidbody2D.AddForce(new Vector2(OffsetCalculator.CalculateHorizontally(transform.position, 0.1f).x, Force),
                ForceMode2D.Impulse);
        }

        private IEnumerator ChangeCollisionObjectLayer()
        {
            collisionGameObject.gameObject.layer = LayerMask.NameToLayer(Layers.FlyUp);
            Debug.Log(collisionGameObject.gameObject.layer);
            yield return new WaitForSeconds(invincibleTime);
            collisionGameObject.gameObject.layer = LayerMask.NameToLayer(Layers.Default);
        }
    }
}