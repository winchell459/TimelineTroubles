using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1;
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        handleUserInput();
    }

    private void handleUserInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 velocity = movementSpeed * new Vector2(horizontal, vertical).normalized;
        if (CollisionTrigger.Messaging)
        {
            velocity = Vector2.zero;
        }
        rb.velocity = velocity;
        anim.SetFloat("velocity", velocity.magnitude);
    }
}
