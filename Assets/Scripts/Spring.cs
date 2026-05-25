using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float springForce = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void SpringLoose()
    {
        rb.AddForce(transform.forward * -1 * springForce,ForceMode.Impulse);
        Invoke("SpringRetract", 0.2f);
    }
    public void SpringRetract()
    {
        rb.AddForce(transform.forward * springForce, ForceMode.Impulse);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpringLoose();
        }
    }
}
