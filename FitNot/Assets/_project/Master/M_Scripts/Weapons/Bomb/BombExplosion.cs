using System.Collections.Generic;
using UnityEngine;
using Youssef;

public class BombExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    private float countdownSeconds = 5f;
    private bool isExploded = false;
    public Transform explosion;

    private List<GameObject> otherObjs = new List<GameObject>();
    private void Start()
    {
        StartCountdown();
    }

    private void StartCountdown()
    {
        Debug.Log("Bomb has been activated.");

        Invoke("Explode", countdownSeconds);
    }

    private void Explode()
    {
        if (!isExploded)
        {
            isExploded = true;
            Debug.Log("Have A Nice Explosion.");

            // Instantiate explosion particle effect
            Instantiate(explosionPrefab, explosion.position, transform.rotation);

            // Apply explosion force to surrounding objects
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider hitCollider in colliders)
            {
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                    //hitCollider.GetComponent<HealthManager>().startingHealth = 0;
                }
            }
            foreach (GameObject obj in otherObjs)
            {
                Debug.Log("explosion.............."+obj.name);
                obj.GetComponent<HealthManager>().TakeDamage(100);
            }

        }

        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpitterMummy") || other.CompareTag("MeleeMummy") || other.CompareTag("Player"))
        {
            otherObjs.Add(other.gameObject);
            Debug.Log("other are added.............." + other.name);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpitterMummy") || other.CompareTag("MeleeMummy") || other.CompareTag("Player"))
        {
             otherObjs.Remove(other.gameObject);
             Debug.Log("other are removed.............." + other.name);

        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    //other.GetComponent<HealthManager>().startingHealth = 0;
    //     if (other.CompareTag("SpitterMummy") || other.CompareTag("MeleeMummy") || other.CompareTag("Player"))
    //     {
    //        otherObjs.Add(other.gameObject);
    //        Debug.Log("other are added.............." + other.name);

    //    }
    //}
}
