using AyaOmar;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Youssef
{
    [ExecuteInEditMode]
    public class AlphaController : MonoBehaviour
    {
       [SerializeField] Material material1;
       [SerializeField] Material material2;
        [Range(0f, 1f)]
        public float ditherInput;
        // Start is called before the first frame update
        void Start()
        {
            material1 = GetComponent<Renderer>().material;
            material2 = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            material1.SetVector("_PlayerPos", transform.position);
            material1.SetVector("_PlayerScale", transform.localScale);
            material1.SetFloat("_Opacity", ditherInput);
            material2.SetVector("_PlayerPos", transform.position);
            material2.SetVector("_PlayerScale", transform.localScale);
            material2.SetFloat("_Opacity", ditherInput);
        }

    }
}
