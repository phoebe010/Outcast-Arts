using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trashPrefab;
    public float respawnTime = 1.2f;

    private GameObject trashObject;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if (trashObject == null)
        {
            trashObject = GameObject.Instantiate(trashPrefab, transform.position, Quaternion.identity);
        }
    }

}
