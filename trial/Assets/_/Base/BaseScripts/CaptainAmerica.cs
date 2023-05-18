/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using UnityEngine;
using V_AnimationSystem;
using CodeMonkey.Utils;

/*
 * Player movement with Arrow keys
 * Attack with Mouse
 * */
public class CaptainAmerica : MonoBehaviour, EnemyHandler.IEnemyTargetable {

    public static CaptainAmerica instance;

    private const float SPEED = 50f;

    [SerializeField] private Shield shield;
    [SerializeField] private LayerMask wallLayerMask;
    private Player_Base playerBase;
    private State state;
    private Material material;
    private Color materialTintColor;
    private Vector3 rollingDirSpeed;
    private Vector3 lastMoveDir;

    private enum State {
        Normal,
        Attacking,
        Rolling,
    }

    private void Awake() {
        instance = this;
        playerBase = gameObject.GetComponent<Player_Base>();
        material = transform.Find("Body").GetComponent<MeshRenderer>().material;
        materialTintColor = new Color(1, 0, 0, 0);
        SetStateNormal();
    }

    private void Update() {
        switch (state) {
        case State.Normal:
            HandleMovement();
            HandleAttack();
            HandleStartRolling();
            break;
        case State.Attacking:
            HandleAttack();
            HandleStartRolling();
            break;
        case State.Rolling:
            HandleRolling();
            break;
        }

        if (materialTintColor.a > 0) {
            float tintFadeSpeed = 6f;
            materialTintColor.a -= tintFadeSpeed * Time.deltaTime;
            material.SetColor("_Tint", materialTintColor);
        }

        if (Input.GetMouseButtonDown(1)) {
            if (shield.IsWithPlayer()) {
                Vector3 throwDir = (UtilsClass.GetMouseWorldPosition() - GetPosition()).normalized;
                shield.ThrowShield(throwDir);
            } else {
                shield.Recall();
            }
        }
    }

    private void SetStateNormal() {
        state = State.Normal;
    }

    private void SetStateAttacking() {
        state = State.Attacking;
    }

    private void HandleStartRolling() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            
            float moveX = 0f;
            float moveY = 0f;
        
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
                moveY = +1f;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
                moveY = -1f;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
                moveX = -1f;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                moveX = +1f;
            }

            Vector3 moveDir = new Vector3(moveX, moveY).normalized;

            bool isIdle = moveX == 0 && moveY == 0;
            if (!isIdle) {
                state = State.Rolling;
                rollingDirSpeed = moveDir;// (UtilsClass.GetMouseWorldPosition() - GetPosition()).normalized;
                rollingDirSpeed *= 180f;
                playerBase.PlayRollAnim(moveDir);
            }
        }
    }

    private void HandleRolling() {
        rollingDirSpeed -= rollingDirSpeed * 3f * Time.deltaTime;
        TryMoveTo(rollingDirSpeed.normalized, rollingDirSpeed.magnitude * Time.deltaTime);

        if (rollingDirSpeed.magnitude <= 50f) {
            state = State.Normal;
        }
    }

    private void HandleMovement() {
        float moveX = 0f;
        float moveY = 0f;
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            moveX = +1f;
        }

        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        bool isIdle = moveX == 0 && moveY == 0;
        if (isIdle) {
            playerBase.PlayIdleAnim();
        } else {
            if (CanMoveTo(moveDir, SPEED * Time.deltaTime)) {
                lastMoveDir = moveDir;
                playerBase.PlayMoveAnim(moveDir);
                transform.position += moveDir * SPEED * Time.deltaTime;
            } else {
                playerBase.PlayMoveAnim(moveDir);
            }
        }

    }

    private bool IsOnTopOfWall() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(GetPosition(), new Vector2(5, 9), 0f, Vector2.zero, 0f, wallLayerMask);
        return raycastHit.collider != null;
    }

    private bool CanMoveTo(Vector3 dir, float distance) {
        if (IsOnTopOfWall()) return true;
        RaycastHit2D raycastHit = Physics2D.BoxCast(GetPosition(), new Vector2(5, 9), 0f, dir, distance, wallLayerMask);
        return raycastHit.collider == null;
    }

    private void TryMoveTo(Vector3 dir, float distance) {
        RaycastHit2D raycastHit = Physics2D.BoxCast(GetPosition(), new Vector2(5, 9), 0f, dir, distance, wallLayerMask);
        if (raycastHit.collider == null) {
            transform.position += dir * distance;
        } else {
            transform.position += dir * (raycastHit.distance - .1f);
        }
    }

    private void HandleAttack() {
        if (Input.GetMouseButtonDown(0)) {
            // Attack
            SetStateAttacking();
            
            Vector3 attackDir = (UtilsClass.GetMouseWorldPosition() - GetPosition()).normalized;

            EnemyHandler enemyHandler = EnemyHandler.GetClosestEnemy(GetPosition() + attackDir * 4f, 20f);
            bool hitEnemy;
            if (enemyHandler != null) {
                enemyHandler.Damage(this);
                hitEnemy = true;
                attackDir = (enemyHandler.GetPosition() - GetPosition()).normalized;
                transform.position = enemyHandler.GetPosition() + attackDir * -12f;
            } else {
                hitEnemy = false;
                //transform.position = transform.position + attackDir * 4f;
                TryMoveTo(attackDir, 4f);
            }

            float attackAngle = UtilsClass.GetAngleFromVectorFloat(attackDir);

            // Play attack animation
            if (playerBase.IsPlayingPunchAnimation()) {
                // Play Kick animation since punch animation is currently active
                playerBase.PlayKickAnimation(attackDir, (Vector3 impactPosition) => {
                    if (hitEnemy) {
                        impactPosition += UtilsClass.GetVectorFromAngle((int)attackAngle) * 6f;
                        Transform impactEffect = Instantiate(GameAssets.i.pfImpactEffect, impactPosition, Quaternion.identity);
                        impactEffect.eulerAngles = new Vector3(0, 0, attackAngle - 90);
                    }
                }, SetStateNormal);
            } else {
                // Play Punch animation
                playerBase.PlayPunchAnimation(attackDir, (Vector3 impactPosition) => {
                    if (hitEnemy) {
                        impactPosition += UtilsClass.GetVectorFromAngle((int)attackAngle) * 6f;
                        Transform impactEffect = Instantiate(GameAssets.i.pfImpactEffect, impactPosition, Quaternion.identity);
                        impactEffect.eulerAngles = new Vector3(0, 0, attackAngle - 90);
                    }
                }, SetStateNormal);
            }
        }
    }

    public void Damage(EnemyHandler enemyHandler) {
        Vector3 dirFromEnemyToCharacter = (GetPosition() - enemyHandler.GetPosition()).normalized;
        DamageKnockback(dirFromEnemyToCharacter, 3f);
    }

    private void DamageFlash() {
        materialTintColor = new Color(1, 0, 0, 1f);
        material.SetColor("_Tint", materialTintColor);
    }

    public void DamageKnockback(Vector3 knockbackDir, float knockbackDistance) {
        //transform.position += knockbackDir * knockbackDistance;
        TryMoveTo(knockbackDir, knockbackDistance);
        DamageFlash();
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public Vector3 GetBodyPosition() {
        return playerBase.GetBodyPosition();
    }

    public bool IsSpriteFacingDown() {
        return playerBase.IsSpriteFacingDown();
    }

    public int GetSortingOrder() {
        return playerBase.GetSortingOrder();
    }

}
