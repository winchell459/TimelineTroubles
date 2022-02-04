using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierTrigger : CollisionTrigger
{
    SoldierController sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SoldierController>();
    }

   

    protected override void handlePlayerTagCollisionEnter(Collision2D collision)
    {
        GetComponent<SoldierController>().Messaging = true;
        base.handlePlayerTagCollisionEnter(collision);
    }

    protected override void handlePlayerTagCollisionExit(Collision2D collision)
    {
        GetComponent<SoldierController>().Messaging = false;
        base.handlePlayerTagCollisionExit(collision);
    }
}
