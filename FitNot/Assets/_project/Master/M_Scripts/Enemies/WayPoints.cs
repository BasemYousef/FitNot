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
        [SerializeField] private int wayPointsRange = 10; 
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
                GameObject ClonePoint = Instantiate(point, gameObject.transform.position, Quaternion.identity);
                ClonePoint.transform.parent = wayPointsParent;
                ClonePoint.transform.position = new Vector3(gameObject.transform.position.x + Random.Range(-wayPointsRange, wayPointsRange), transform.position.y,
                    gameObject.transform.position.z + Random.Range(-wayPointsRange, wayPointsRange));

                wayPoints.Add(ClonePoint.transform);
            }
        }
        public List<Transform> GetWayPoints()
        {
            return wayPoints;
        }
    }
}
