using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float explosionForce = 10f;
    public float explosionRadius = 5f;
    private float countdownSeconds = 5f;
    private bool isExploded = false;

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
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            // Apply explosion force to surrounding objects
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider hitCollider in colliders)
            {
                Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }

        }

        Destroy(gameObject);
    }
}
