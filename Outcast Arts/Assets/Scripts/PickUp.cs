using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private UpdateTrash refScript;

    private void OnTriggerEnter2D(Collider2D theCollider)
    {
        if (theCollider.gameObject.CompareTag("Player"))
        {
            refScript = theCollider.gameObject.GetComponent<UpdateTrash>();
            Destroy(gameObject);
            refScript.IncreaseTheBar();
        }

    }
}
