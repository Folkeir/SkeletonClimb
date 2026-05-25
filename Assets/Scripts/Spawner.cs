using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] EnvironmentSpawner envSpawner;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawner")
        {
            envSpawner.SpawnChunk();
            Destroy(other.gameObject);
        }
    }
}
