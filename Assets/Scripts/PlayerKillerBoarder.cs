using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerKillerBoarder : MonoBehaviour
{
    [SerializeField] CameraScript cameraScript;
    [SerializeField] VisualEffect dieParticle;
    [SerializeField] PlayerSpawn playerSpawn;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PlayerDEAD");
            cameraScript.PlayerDie();
            dieParticle.transform.position = new Vector3(other.transform.position.x, transform.position.y + 6f, 0);
            dieParticle.Play();
            other.gameObject.transform.parent.transform.parent.gameObject.SetActive(false);
            playerSpawn.PlayerDeath(other.gameObject);
        }
    }
}