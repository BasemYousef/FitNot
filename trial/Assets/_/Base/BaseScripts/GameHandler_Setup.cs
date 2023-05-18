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
using CodeMonkey;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;
using GridPathfindingSystem;

public class GameHandler_Setup : MonoBehaviour {

    public static GridPathfinding gridPathfinding;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private CaptainAmerica captainAmerica;

    private void Start() {
        cameraFollow.Setup(GetCameraPosition, () => 60f, true, true);

        
        gridPathfinding = new GridPathfinding(new Vector3(-400, -400), new Vector3(400, 400), 5f);
        gridPathfinding.RaycastWalkable();
        
        FunctionPeriodic.Create(SpawnEnemy, .9f);
        EnemyHandler.Create(new Vector3(80, 0));
    }

    private Vector3 GetCameraPosition() {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 playerToMouseDirection = mousePosition - captainAmerica.GetPosition();
        return captainAmerica.GetPosition() + playerToMouseDirection * .3f;
    }

    private void SpawnEnemy() {
        Vector3 spawnPosition = captainAmerica.GetPosition() + UtilsClass.GetRandomDir() * 100f;
        EnemyHandler.Create(spawnPosition);
    }
}
