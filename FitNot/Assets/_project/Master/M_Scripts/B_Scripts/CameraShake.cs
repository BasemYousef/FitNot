using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private Transform camera;
        [SerializeField] Vector3 Strength;

        public static event Action shake;
        public static void Invoke()
        {
            shake?.Invoke();
        }
        private void OnEnable()  => shake += cameraShake;
        private void OnDisable() => shake -= cameraShake;
        

        private void cameraShake()
        {
            camera.DOComplete();
            
            camera.DOShakeRotation(0.3f, Strength);
        }
    }

