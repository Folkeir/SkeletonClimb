using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HookKiller : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Hook"){
            grapplingHook hook = collision.gameObject.GetComponent<grapplingHook>();
            hook.disableGrapple();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hook")
        {
            grapplingHook hook = other.GetComponent<grapplingHook>();
            hook.disableGrapple();
        }
    }
}
