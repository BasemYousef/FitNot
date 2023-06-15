using AyaOmar;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class CameraFader : MonoBehaviour
   {
    public CinemachineVirtualCamera virtualCamera;
    public List<Renderer> objectRenderers;
    public Material ditherMaterial;
    private List<Material> originalMaterials;
    GameObject player = GameManager.Instance.GetPlayerRef();
    void Start()
    {

        originalMaterials = new List<Material>();

        foreach (var renderer in objectRenderers)
        {
            originalMaterials.Add(renderer.material);
        }
    }
    void Update()
    {
        CheckPlayerVisibility();
    }

    void CheckPlayerVisibility()
    {
        Vector3 raycastOrigin = virtualCamera.transform.position;
        Vector3 raycastDirection = player.transform.position - raycastOrigin;

        bool playerBehindAnyObject = false;

        foreach (var renderer in objectRenderers)
        {
            RaycastHit hit;
            if (Physics.Raycast(raycastOrigin, raycastDirection, out hit))
            {
                if (hit.collider.gameObject == player)
                {
                    // Player is behind the object
                    renderer.material = ditherMaterial;
                    playerBehindAnyObject = true;
                }
                else
                {
                    // Player is not behind the object
                    renderer.material = originalMaterials[objectRenderers.IndexOf(renderer)];
                }
            }
            else
            {
                // Player is not behind the object
                renderer.material = originalMaterials[objectRenderers.IndexOf(renderer)];
            }
        }

        if (!playerBehindAnyObject)
        {
            // Player is not behind any of the objects
            foreach (var renderer in objectRenderers)
            {
                renderer.material = originalMaterials[objectRenderers.IndexOf(renderer)];
            }
        }
    }

}

