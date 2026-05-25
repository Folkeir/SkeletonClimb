using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class LowerBorder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CameraScript cameraScript;
    [SerializeField] EnvironmentSpawner envSpawner;
    
    PlayerSpawn playerSpawn;

    private void Start()
    {
        playerSpawn = transform.parent.GetComponent<PlayerSpawn>();
    }
    private void OnTriggerEnter(Collider other)
    {
     
        {
            Destroy(other.gameObject);
        }
    }
}
