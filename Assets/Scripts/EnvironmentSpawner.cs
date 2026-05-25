using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] EnvironmentChunks;
    [SerializeField]Transform currentSpawnPos;
    public bool GenerateLevel = false;
    void Start()
    {
        
        currentSpawnPos.position = currentSpawnPos.position + new Vector3(0,11.5f, 0);
        SpawnChunk();
        
    }

    void Update()
    {
        
    }

    public void SpawnChunk()
    {
        if (!GenerateLevel) { return; }
        int randomIndex = Random.Range(0, EnvironmentChunks.Length);
        Instantiate(EnvironmentChunks[randomIndex], currentSpawnPos.position, currentSpawnPos.rotation);
        currentSpawnPos.position = currentSpawnPos.position + new Vector3(0, 11.5f, 0);
    }
}
