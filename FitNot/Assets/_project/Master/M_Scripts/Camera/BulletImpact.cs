
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class BulletImpact : MonoBehaviour
    {
    public static BulletImpact Instance {  get; private set; }
    private Unity.Cinemachine.CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private float shakeTimerTotal;
    private float startingIntensity;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<Unity.Cinemachine.CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        Unity.Cinemachine.CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<Unity.Cinemachine.CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.AmplitudeGain = intensity;

        startingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            Unity.Cinemachine.CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                cinemachineVirtualCamera.GetCinemachineComponent<Unity.Cinemachine.CinemachineBasicMultiChannelPerlin>();

            cinemachineBasicMultiChannelPerlin.AmplitudeGain =
                Mathf.Lerp(startingIntensity, 0f, 1 - shakeTimer / shakeTimerTotal);
        }
    }

}
