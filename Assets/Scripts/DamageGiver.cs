using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageGiver : MonoBehaviour
{
   

   
    private void OnCollisionEnter(Collision collision)
    {
       
        collision.gameObject.GetComponent<Block>().TakeDamage(1f);
    }
    

}
