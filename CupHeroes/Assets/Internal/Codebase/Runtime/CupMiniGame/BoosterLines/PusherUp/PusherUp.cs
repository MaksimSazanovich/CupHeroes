using System.Collections;
using Internal.Codebase.Runtime.Constants;
using Internal.Codebase.Utilities.PositionOffsetCalculator;
using UnityEngine;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.PusherUp
{
    [DisallowMultipleComponent]
    public sealed class PusherUp : BoosterLine
    {
        private float force = 9;
        private Collider2D collisionGameObject;
        private readonly float invincibleTime = 3;
        private float pushOffsetX = 0.5f;

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
            Debug.Log(PositionOffsetCalculator.CalculateHorizontally(transform.position, 0.2f));
            otherRigidbody2D.AddForce(new Vector2(Random.Range(-pushOffsetX, pushOffsetX), force), ForceMode2D.Impulse);
        }

        private IEnumerator ChangeCollisionObjectLayer()
        {
            collisionGameObject.gameObject.layer = LayerMask.NameToLayer(Layers.FlyUp);
            yield return new WaitForSeconds(invincibleTime);
            collisionGameObject.gameObject.layer = LayerMask.NameToLayer(Layers.Ball);
        }
    }
}