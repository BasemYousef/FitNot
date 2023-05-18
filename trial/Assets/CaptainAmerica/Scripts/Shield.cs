/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    private const float GRAB_DISTANCE = 5f;
    [SerializeField] private CaptainAmerica captainAmerica;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2d;
    private TrailRenderer trailRenderer;
    private State state;

    private enum State {
        WithPlayer,
        Thrown,
        Recalling,
    }

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
        state = State.Recalling;
    }

    private void FixedUpdate() {
        switch (state) {
        case State.Thrown:
            TryPlayerGrabShield();
            break;
        case State.Recalling:
            Vector3 dirToPlayer = (captainAmerica.GetPosition() - transform.position).normalized;
            float recallSpeed = 200f;
            rigidbody2d.velocity = dirToPlayer * recallSpeed;
            TryPlayerGrabShield();
            break;
        }
    }

    private void LateUpdate() {
        switch (state) {
        case State.WithPlayer:
            transform.position = captainAmerica.GetBodyPosition();
            if (captainAmerica.IsSpriteFacingDown()) {
                spriteRenderer.sortingOrder = captainAmerica.GetSortingOrder() - 10;
            } else {
                spriteRenderer.sortingOrder = captainAmerica.GetSortingOrder() + 10;
            }
            break;
        }
    }

    private void TryPlayerGrabShield() {
        if (Vector3.Distance(transform.position, captainAmerica.GetPosition()) < GRAB_DISTANCE) {
            state = State.WithPlayer;
            trailRenderer.enabled = false;
            rigidbody2d.velocity = Vector2.zero;
            rigidbody2d.isKinematic = true;
        }
    }

    public void ThrowShield(Vector3 throwDir) {
        transform.position = captainAmerica.GetPosition() + throwDir * (GRAB_DISTANCE + 1f);
        float throwForce = 600f;
        rigidbody2d.isKinematic = false;
        rigidbody2d.AddForce(throwDir * throwForce, ForceMode2D.Impulse);
        trailRenderer.enabled = true;
        state = State.Thrown;
    }

    public void Recall() {
        state = State.Recalling;
    }

    public bool IsWithPlayer() {
        return state == State.WithPlayer;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        EnemyHandler enemyHandler = collider.GetComponent<EnemyHandler>();
        
        if (enemyHandler != null) {
            // Hit enemy
            float throwSpeed = rigidbody2d.velocity.magnitude;
            float minDamageSpeed = 10f;
            if (throwSpeed > minDamageSpeed) {
                enemyHandler.Knockout(transform.position);

                EnemyHandler nextClosestEnemy = EnemyHandler.GetClosestEnemy(transform.position, 60f);
                if (nextClosestEnemy != null) {
                    Vector3 throwDir = (nextClosestEnemy.GetPosition() - transform.position).normalized;
                    rigidbody2d.velocity = throwDir * throwSpeed;
                }
            }
        }
    }

}
