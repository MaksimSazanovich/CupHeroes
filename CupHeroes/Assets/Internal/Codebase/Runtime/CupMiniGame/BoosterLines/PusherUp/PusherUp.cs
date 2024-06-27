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
        private readonly float invincibleTime = 1;
        private float pushOffsetX = 2f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out BallCollision ballCollision) &&
                transform.position.y < other.transform.position.y && !ballCollision.LockBoosterLineIDs.Contains(ID))
            {
                //ballCollision.LockPusherUpID(this);
                ballCollision.Lock(this);
                PushUpCollision(other);
            }
        }

        private void PushUpCollision(Collider2D other)
        {
            collisionGameObject = other;
            StartCoroutine(ChangeCollisionObjectLayer(other.GetComponent<BallCollision>()));
            PushUp(other.transform.position.x);
        }

        private void PushUp(float otherPositionX)
        {
            Rigidbody2D otherRigidbody2D = collisionGameObject.GetComponent<Rigidbody2D>();
            otherRigidbody2D.velocity = Vector2.zero;
            otherRigidbody2D.AddForce(
                new Vector2(Random.Range(otherPositionX - pushOffsetX, -otherPositionX - pushOffsetX), force),
                ForceMode2D.Impulse);
        }

        private IEnumerator ChangeCollisionObjectLayer(BallCollision ballCollision)
        {
            collisionGameObject.gameObject.layer = LayerMask.NameToLayer(Layers.Flyup);
            yield return new WaitForSeconds(invincibleTime);
            collisionGameObject.gameObject.layer = LayerMask.NameToLayer(Layers.Ball);
        }
    }
}