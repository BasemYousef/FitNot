using System;
using UnityEngine;
using V_AnimationSystem;
using CodeMonkey.Utils;

/*
 * Player Base Class
 * */
public class Player_Base : MonoBehaviour {
    
    #region BaseSetup
    private V_UnitSkeleton unitSkeleton;
    private V_UnitAnimation unitAnimation;
    private AnimatedWalker animatedWalker;

    private void Start() {
        Transform bodyTransform = transform.Find("Body");
        unitSkeleton = new V_UnitSkeleton(1f, bodyTransform.TransformPoint, (Mesh mesh) => bodyTransform.GetComponent<MeshFilter>().mesh = mesh);
        unitAnimation = new V_UnitAnimation(unitSkeleton);
        
        UnitAnimType idleUnitAnim = UnitAnimType.GetUnitAnimType("dBareHands_Idle");
        UnitAnimType walkUnitAnim = UnitAnimType.GetUnitAnimType("dBareHands_Walk");
        UnitAnimType hitUnitAnim = UnitAnimType.GetUnitAnimType("dBareHands_Hit");
        UnitAnimType attackUnitAnim = UnitAnimType.GetUnitAnimType("dBareHands_PunchQuickAttack");

        animatedWalker = new AnimatedWalker(unitAnimation, idleUnitAnim, walkUnitAnim, 1f, 1f);
    }

    private void Update() {
        unitSkeleton.Update(Time.deltaTime);
    }

    public V_UnitAnimation GetUnitAnimation() {
        return unitAnimation;
    }
    #endregion


    public void PlayMoveAnim(Vector3 moveDir) {
        animatedWalker.SetMoveVector(moveDir);
    }

    public void PlayIdleAnim() {
        animatedWalker.SetMoveVector(Vector3.zero);
    }
    
    public bool IsPlayingPunchAnimation() {
        return unitAnimation.GetActiveAnimType().GetName() == "dBareHands_PunchQuick";
    }

    public bool IsPlayingKickAnimation() {
        return unitAnimation.GetActiveAnimType().GetName() == "dBareHands_KickQuick";
    }
    
    public void PlayPunchAnimation(Vector3 dir, Action<Vector3> onHit, Action onAnimComplete) {
        unitAnimation.PlayAnimForced(UnitAnimType.GetUnitAnimType("dBareHands_PunchQuick"), dir, 1f, (UnitAnim unitAnim2) => {
            if (onAnimComplete != null) onAnimComplete();
        }, (string trigger) => {
            // HIT = HandR
            // HIT2 = HandL
            string hitBodyPartName = trigger == "HIT" ? "HandR" : "HandL";
            Vector3 impactPosition = unitSkeleton.GetBodyPartPosition(hitBodyPartName);
            if (onHit != null) {
                onHit(impactPosition);
            }
        }, null);
    }
    
    public void PlayKickAnimation(Vector3 dir, Action<Vector3> onHit, Action onAnimComplete) {
        unitAnimation.PlayAnimForced(UnitAnimType.GetUnitAnimType("dBareHands_KickQuick"), dir, 1f, (UnitAnim unitAnim2) => {
            if (onAnimComplete != null) onAnimComplete();
        }, (string trigger) => {
            // HIT = FootL
            // HIT2 = FootR
            string hitBodyPartName = trigger == "HIT" ? "FootL" : "FootR";
            Vector3 impactPosition = unitSkeleton.GetBodyPartPosition(hitBodyPartName);
            if (onHit != null) {
                onHit(impactPosition);
            }
        }, null);
    }
    
    public void PlayRollAnim(Vector3 dir) {
        unitAnimation.PlayAnimForced(UnitAnimType.GetUnitAnimType("dSwordShield_Roll"), dir, 1.5f, null, null, null);
    }

    public void PlayWebZipShootAnimation(Vector3 dir) {
        unitAnimation.PlayAnimForced(UnitAnimType.GetUnitAnimType("Spiderman_ShootWebZip"), dir, 1f, null, null, null);
    }

    public void PlayWebZipFlyingAnimation(Vector3 dir) {
        unitAnimation.PlayAnimForced(UnitAnimType.GetUnitAnimType("Spiderman_WebZipFlying"), dir, 1f, null, null, null);
    }

    public void PlaySlidingAnimation(Vector3 dir) {
        unitAnimation.PlayAnimForced(UnitAnimType.GetUnitAnimType("Spiderman_Sliding"), dir, 1f, null, null, null);
    }

    public Vector3 GetHandLPosition() {
        return unitSkeleton.GetBodyPartPosition("HandL");
    }
    
    public Vector3 GetHandRPosition() {
        return unitSkeleton.GetBodyPartPosition("HandR");
    }  
    
    public Vector3 GetBodyPosition() {
        return unitSkeleton.GetBodyPartPosition("Body");
    }

    public bool IsSpriteFacingDown() {
        switch (unitAnimation.GetActiveAnim().GetName()) {
        case "dBareHands_IdleDown":
        case "dBareHands_IdleDownLeft":
        case "dBareHands_IdleDownRight":
        case "dBareHands_IdleRight":
        case "dBareHands_PunchQuickDown":
        case "dBareHands_PunchQuickDownLeft":
        case "dBareHands_PunchQuickDownRight":
        case "dBareHands_PunchQuickRight":
        case "dBareHands_KickQuickDown":
        case "dBareHands_KickQuickDownLeft":
        case "dBareHands_KickQuickDownRight":
        case "dBareHands_KickQuickRight":
        case "dBareHands_WalkDown":
        case "dBareHands_WalkDownLeft":
        case "dBareHands_WalkDownRight":
        case "dBareHands_WalkRight":
        case "dSwordShield_RollDown":
        case "dSwordShield_RollRight":
            return true;
        default:
            return false;
        }
    }

    public int GetSortingOrder() {
        return transform.Find("Body").GetComponent<MeshRenderer>().sortingOrder;
    }

}
