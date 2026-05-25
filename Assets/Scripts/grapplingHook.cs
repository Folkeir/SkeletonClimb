using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grapplingHook : MonoBehaviour
{
    [SerializeField] float collisionCooldown = 0.5f;
    public InputMan owningPlayerscript;
    [SerializeField] HookedRope hookedRope;
    [SerializeField] float projectileForce = 50.0f;

    private Animator _anim;
    private Rigidbody _rigidbody;
    private SphereCollider _collider;
    private float starttime;
    private float endtime;
    private bool timerActive = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();
        _anim = GetComponent<Animator>();
        starttime = Time.time;
        endtime = starttime + collisionCooldown;
        _collider.enabled = false;
    }

    private void Update()
    {
        if (Time.time >= endtime && timerActive)
        {
            _collider.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        _anim.SetTrigger("Close");
        //Debug.Log("grapplinghook collided!");
        _rigidbody.velocity = Vector3.zero;
        
        _collider.enabled = false;
        timerActive = false;
        owningPlayerscript.Hooked();
        transform.SetParent(collision.transform);
        if (collision.gameObject.GetComponent<Block>() != null)
        {
            collision.gameObject.GetComponent<Block>().TakeDamage();
            _rigidbody.isKinematic = false;
        }
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Dynamic" || collision.gameObject.tag == "Enemy")
        {
            _rigidbody.isKinematic = true;
        }
    }

    public void disableGrapple()
    {
        _rigidbody.isKinematic = false;
        transform.SetParent(null);
        hookedRope.gameObject.SetActive(false);
        _rigidbody.velocity = Vector3.zero;
        _collider.enabled = false;
        timerActive = false;
        //_anim.SetTrigger("Open");
        owningPlayerscript.Unhooked();
        gameObject.SetActive(false);
    }

    public void shootgrapple(Vector3 position, Vector3 dirVect)
    {
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = false;
        _anim.SetTrigger("Open");
        hookedRope.gameObject.SetActive(true);
        gameObject.SetActive(true);
        starttime = Time.time;
        endtime = starttime + collisionCooldown;
        _collider.enabled = false;
        timerActive = true;

        transform.position = position;
        transform.rotation = Quaternion.LookRotation(dirVect, Vector3.forward);
        GetComponent<Rigidbody>().velocity = dirVect * projectileForce;
        //GetComponent<Rigidbody>().AddForce(dirVect * projectileForce);
    }
}
