using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGiver : MonoBehaviour
{
   

   
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hello");
        collision.gameObject.GetComponent<Block>().TakeDamage();
    }
    

}
