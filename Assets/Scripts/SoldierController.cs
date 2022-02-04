using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierController : MovementController
{
    [SerializeField] int amo = 5;
    [SerializeField] SoldierAmo amoPrefab;
    [SerializeField] Transform target;
    [SerializeField] float attackRate = 1;
    private float lastAttack;
    public bool Messaging;
    protected override void handleInput()
    {
        if (Messaging)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            handleAttack();
            rb.velocity = Vector2.zero;
        }
        base.handleInput();
    }

    void handleAttack()
    {
        if (target)
        {
            if(lastAttack + attackRate < Time.time && amo > 0)
            {
                Vector2 direction = ((Vector2)(target.transform.position - transform.position)).normalized;
                Instantiate(amoPrefab, transform.position, Quaternion.identity).Fire(direction);
                lastAttack = Time.time;
            }
        }
        else
        {
            foreach (EnemyController target in FindObjectsOfType<EnemyController>())
            {
                if (!this.target) this.target = target.transform;
                if (this.target && Vector2.Distance(transform.position, target.transform.position) < Vector2.Distance(transform.position, this.target.position))
                    this.target = target.transform;
            }
            lastAttack = Time.time;
        }
    }
}
