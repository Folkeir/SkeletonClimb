using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameManager.Victory();
        }
    }
}
