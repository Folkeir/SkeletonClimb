using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]float springForce = 5;

    Vector3 startPosition;
    
    Rigidbody rb;
    void Start()
    {
        startPosition = transform.localPosition;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce((startPosition * springForce) * Vector3.Distance(startPosition,transform.position));
       
    }
}
