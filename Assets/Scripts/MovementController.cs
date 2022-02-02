using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float movementSpeed = 1;
    protected Rigidbody2D rb;
    protected Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        handleInput();
        handleAnimator();
    }

    virtual protected void handleInput()
    {
        
        
    }

    protected void handleAnimator()
    {
        anim.SetFloat("velocity", rb.velocity.magnitude);
    }
}
