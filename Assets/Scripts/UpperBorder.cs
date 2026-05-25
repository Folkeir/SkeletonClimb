using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperBorder : MonoBehaviour
{
    [SerializeField] CameraScript cameraScript;
    [SerializeField] PlayerSpawn playerSpawn;
    private bool reachedEnd = false;

    void Start()
    {
        playerSpawn = transform.parent.GetComponent<PlayerSpawn>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"&& !reachedEnd)
        {
            cameraScript.SpeedBurst();
        }
        if(other.tag == "LastBlock")
        {
            cameraScript.EndBlock();
            reachedEnd = true;
        }
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyBehaviour>().WakeUp();
            Debug.Log("Enemy Trigger");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            //cameraScript.SpeedBurst();
            //cameraScript.SetState(1);
        }
        
    }
 
}
