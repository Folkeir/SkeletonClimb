using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAddition : MonoBehaviour
{

    private Rigidbody rb;
    private Collider thisCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
       // thisCollider  = GetComponent<Collider>();
    }

    public void DropAdditions()
    {
        rb.isKinematic = false;
        rb.AddTorque(Vector3.forward * 10,ForceMode.Impulse);
       // thisCollider.isTrigger = true;   

    }
}
