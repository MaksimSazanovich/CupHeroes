using System;
using System.Collections;
using Internal.Codebase.Runtime.Constants;
using Internal.Codebase.Runtime.CupMiniGame.Ball;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Internal.Codebase.Runtime.CupMiniGame.BoosterLines.PusherUp
{
    [DisallowMultipleComponent]
    public sealed class PusherUp : BoosterLine
    {
        private float force = 9;
        private Collider2D collisionGameObject;
        private readonly float invincibleTime = 3;
        private float pushOffsetX = 2f;

        public static Action<int> OnFelt;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BallCollision ballCollision) && transform.position.y <= other.transform.position.y)
            {
                PushUpCollision(other);
            }
        }

        private void PushUpCollision(Collider2D other)
        {
            collisionGameObject = other;
            StartCoroutine(ChangeCollisionObjectLayer());
            PushUp(other.transform.position.x);
        }

        private void PushUp(float otherPositionX)
        {
            Rigidbody2D otherRigidbody2D = collisionGameObject.GetComponent<Rigidbody2D>();
            otherRigidbody2D.velocity = Vector2.zero;
            otherRigidbody2D.AddForce(new Vector2(Random.Range(otherPositionX-pushOffsetX, -otherPositionX-pushOffsetX), force), ForceMode2D.Impulse);
        }

        private IEnumerator ChangeCollisionObjectLayer()
        {
            collisionGameObject.gameObject.layer = LayerMask.NameToLayer(Layers.Flyup);
            yield return new WaitForSeconds(invincibleTime);
            collisionGameObject.gameObject.layer = LayerMask.NameToLayer(Layers.Ball);
            OnFelt?.Invoke(ID);
        }
    }
}