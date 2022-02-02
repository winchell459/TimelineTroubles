using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MovementController
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform[] targets;

    protected override void handleInput()
    {
        foreach(Transform target in targets)
        {
            if (Vector2.Distance(transform.position, target.position) < Vector2.Distance(transform.position, this.target.position)) this.target = target;
        }
        if(target)
        {
            Vector2 velocity = (target.position - transform.position).normalized * movementSpeed;
            rb.velocity = velocity;
        }
    }
}
