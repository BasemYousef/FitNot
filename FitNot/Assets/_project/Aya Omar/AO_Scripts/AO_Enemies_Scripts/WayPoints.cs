using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AyaOmar
{
    public class WayPoints : Singleton<WayPoints>
    {
        private List<Transform> wayPoints = new List<Transform>();
        [SerializeField] private GameObject point;
        private Transform wayPointsParent;
        int numOfPoints = 10;
        private void Awake()
        {
            base.RegisterSingleton();
            wayPointsParent = GameObject.FindGameObjectWithTag("WayPoints").transform;
        }
        private void Start()
        {
            for(int i=0;i< numOfPoints; i++)
            {
                GameObject p = Instantiate(point, gameObject.transform.position, Quaternion.identity);
                p.transform.parent = wayPointsParent;
                p.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(-10, 10), transform.position.y,
                    gameObject.transform.position.z + Random.Range(-10, 10));

                wayPoints.Add(p.transform);
            }
        }
        public List<Transform> GetWayPoints()
        {
            return wayPoints;
        }
    }
}
