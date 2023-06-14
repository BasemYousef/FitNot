using UnityEngine;

public class PlaceBomb : MonoBehaviour
{
    [SerializeField]private GameObject objectPrefab;
    [SerializeField]private Transform groundCheckOrigin;
    [SerializeField]private LayerMask groundLayer;
    
    public void PlaceObject()
    {
        // Raycast to check for ground
        if (Physics.Raycast(groundCheckOrigin.position, Vector3.down, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            // Calculate the position in front of the player
            Vector3 spawnPosition = hit.point + Vector3.up * 0.5f + (transform.forward * 2f);
            
            // Instantiate and activate the object at the calculated position
            GameObject placedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            
            placedObject.SetActive(true);
        }
    }
}
