using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class SpawnSpecialItem : MonoBehaviour
    {
        [SerializeField] private List<GameObject> koushariCar = new List<GameObject>();
        [SerializeField] private List<GameObject> beansCar = new List<GameObject>();
        [SerializeField] private List<GameObject> waterCooler = new List<GameObject>();

        [SerializeField] private GameObject koushariPrefab;
        [SerializeField] private GameObject beansPrefab;
        [SerializeField] private GameObject waterPrefab;
        void Start()
        {
            SpawnKouItem();
            SpawnBeansItem();
            SpawnWaterItem();
        }

        private void SpawnKouItem()
        {
            foreach(var kCar in koushariCar)
            {
                Instantiate(koushariPrefab, kCar.transform.position, kCar.transform.rotation);
            }
        }
        private void SpawnBeansItem()
        {
            foreach (var BCar in beansCar)
            {
                Instantiate(beansPrefab, BCar.transform.position + new Vector3(0, 0.5f, 1), BCar.transform.rotation);
            }
        }
        private void SpawnWaterItem()
        {
            foreach (var WCar in waterCooler)
            {
                Instantiate(waterPrefab, WCar.transform.position + new Vector3(0, 0.5f, 1), WCar.transform.rotation);
            }
        }
    }
}
