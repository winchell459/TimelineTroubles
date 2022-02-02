using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MovementController
{
    

    override protected void handleInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 velocity = movementSpeed * new Vector2(horizontal, vertical).normalized;
        if (CollisionTrigger.Messaging)
        {
            velocity = Vector2.zero;
        }
        rb.velocity = velocity;
        
    }
}
