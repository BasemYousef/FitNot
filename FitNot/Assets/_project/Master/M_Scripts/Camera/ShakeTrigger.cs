// Example usage
using UnityEngine;

public class ShakeTrigger : MonoBehaviour
{
    public CameraShake cameraShake;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraShake.Shake();
        }
    }
}
