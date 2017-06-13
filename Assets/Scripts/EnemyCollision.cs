using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public AudioClip enemyDeathSound;
    public float health;
    public int scoreGiven;
    private ScoreHandler scoreHandler;

    void Start()
    {
        scoreHandler = GameObject.Find("Score").GetComponent<ScoreHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();
        if (projectile)
        {
            health -= projectile.GetDamage();
            projectile.Hit();
            if (health <= 0)
            {
                AudioSource.PlayClipAtPoint(enemyDeathSound, new Vector3(0, 0, 0));
                scoreHandler.ScoreUpdater(scoreGiven);
                Destroy(gameObject);
            }
        }
    }
}
