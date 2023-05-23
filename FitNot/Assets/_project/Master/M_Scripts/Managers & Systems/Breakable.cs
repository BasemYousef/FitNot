using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public void BreakObject()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        StartCoroutine(DelayDestroyRoutine(gameObject));
    }

    private IEnumerator DelayDestroyRoutine(GameObject other)
    {
        //switch (objectType)
        //{
        //    case ObjectType.pot:
        //        Instantiate(, transform.position, Quaternion.identity);
        //        break;
        //    case ObjectType.bush:
        //        break;
        //}

        yield return new WaitForSeconds(2f);
        Destroy(other);
    }
}


