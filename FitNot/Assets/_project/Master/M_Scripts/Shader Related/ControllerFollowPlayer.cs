using AyaOmar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Youssef
{
    public class ControllerFollowPlayer : MonoBehaviour
    {
        GameObject playerRef;
        [SerializeField] Vector3 offset;
        void Start()
        {
            playerRef = GameManager.Instance.GetPlayerRef();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 placement = playerRef.transform.position + offset;
          transform.position = placement;
        }
    }
}
