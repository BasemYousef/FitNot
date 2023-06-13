using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Youssef;
namespace AyaOmar
{
    public class DissolveController : MonoBehaviour
    {
        public SkinnedMeshRenderer skinnedMesh;
        public VisualEffect VFXGraph;
        public float dissolveRate = 0.325f;
        public float refreshRate = 0.25f;

        private Material skinnedMaterial;
        private HealthManager health;

        public bool isDissolve;
        void Start()
        {
            VFXGraph.enabled = false;
            if (skinnedMesh != null)
            {
                skinnedMaterial = skinnedMesh.material;
            }
            health = gameObject.GetComponent<HealthManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isDissolve)
            {
                StartCoroutine(DissolveCo());
            }
        
        }
        public void SetIsDissolve()
        {
            isDissolve = true;
            VFXGraph.enabled = true;
        }
        public void DestroyEnemy()
        {
            Destroy(gameObject,4);
        }


        public void EnableVFXGraph()
        {
            
        }
        IEnumerator DissolveCo()
        {
            if (VFXGraph != null)
            {
                VFXGraph.Play();
            }
            float counter = 0;
            while (skinnedMaterial.GetFloat("_DisolveAmount") < 1)
            {
                counter += dissolveRate;
                skinnedMaterial.SetFloat("_DisolveAmount", counter);
                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}
