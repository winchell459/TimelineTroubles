using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAmo : MonoBehaviour
{
    [SerializeField] float speed = 2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().EnemyHit();
            Destroy(gameObject);
        }
    }

    public void Fire(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }
}
