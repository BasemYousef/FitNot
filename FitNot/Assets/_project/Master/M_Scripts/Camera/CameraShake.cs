using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeDuration = 0.5f; // Duration of the shake effect
    public float shakeMagnitude = 0.1f; // Magnitude of the shake effect

    private Vector3 originalPosition; // Store the original position of the camera

    private void Start()
    {
        originalPosition = transform.localPosition; // Store the original position of the camera
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            // Generate a random position offset
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;

            // Apply the random offset to the camera's position
            transform.localPosition = originalPosition + randomOffset;

            // Increase the elapsed time
            elapsed += Time.deltaTime;

            yield return null;
        }

        // Reset the camera's position to the original position
        transform.localPosition = originalPosition;
    }
}
