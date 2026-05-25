using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerBoard : MonoBehaviour
{
    Rigidbody rb;
    
    float startHeight;
    float startRotation;
    [SerializeField] float propellerForce = 10;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startHeight = transform.position.y;
        startRotation = transform.rotation.z;
        //Debug.Log("Start Rotarion : " + startRotation);
        
    } 

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < startHeight)
        {
           rb.AddForce(transform.up * propellerForce);
        }
        if(transform.rotation.z < 0)
        {
          //  Debug.Log("Zrot" + transform.rotation.eulerAngles.z);
            rb.AddTorque(0, 0, 1f);
            
        }
        else
        {
            
            rb.AddTorque(0, 0, -1f);
            
        }
    }
}
