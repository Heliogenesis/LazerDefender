using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile)
        {
            health -= projectile.GetDamage();
            projectile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
