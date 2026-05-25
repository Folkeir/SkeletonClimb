using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private enum State
    {
        Asleep,
        InAir,
        Active,
    }
    public int standardSpeed = 5;
    [SerializeField] float currentSpeed = 5;
    private float timer;
    public Rigidbody rb;
    private Animator animator;

    private State state = State.Asleep;

    [SerializeField] LayerMask RayCastLayermask;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (state == State.InAir)
            {
                state = State.Active;
            }
        }
    }


    void Update()
    {
        if(state != State.Active)
        {
            return;
        }
        timer = Time.time * 1f;
        if (TryJump()) { return; }
        Move();
        

    }
    private void Move()
    {
        if (Mathf.Abs(rb.velocity.x) < 5)
        {
            rb.AddForce((Vector3.up * 0.4f) + Vector3.right * currentSpeed * Mathf.Abs(Mathf.Sin(timer)));
        }


        RaycastHit Hit;
        Vector3 direction = new Vector3(1, -1, 0);
        Vector3 origin = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        if (!Physics.Raycast(origin, direction, out Hit, 10.0f, RayCastLayermask))
        {
            currentSpeed = -standardSpeed;
            Debug.DrawRay(origin, direction * 1000, Color.white);


        }
        direction = new Vector3(-1, -1, 0);
        if (!Physics.Raycast(origin, direction, out Hit, 10.0f, RayCastLayermask))
        {
            currentSpeed = standardSpeed;
            Debug.DrawRay(origin, direction * 1000, Color.white);
        }
    }
    public void WakeUp()
    {
        if(state != State.Asleep) { return; }   
        state = State.Active;
    }
    private bool TryJump()
    {
        Debug.Assert(state == State.Active);
        if (Mathf.Sin(timer) > 0.98)
        {
            rb.AddForce(Vector3.up * 400f, ForceMode.Impulse);
            state = State.InAir;
            return true;
        }
        return false;
    }

}
