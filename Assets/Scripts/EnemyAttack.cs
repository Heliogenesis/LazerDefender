using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public AudioClip enemyLaserFire;
    public GameObject enemyProjectile;
    public float shootingSpeed = .5f;
    public float projectileSpeed;
  
    void Update ()
    {
        float probability = Time.deltaTime * shootingSpeed;
        if (Random.value < probability)
        {
            Fire();
        }
    }

    private void Fire()
    {
        AudioSource.PlayClipAtPoint(enemyLaserFire, new Vector3(0, 0, 0));
        GameObject enemyLaser = Instantiate(enemyProjectile, transform.position + new Vector3(0, -1), Quaternion.identity) as GameObject;
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed);
    }
}
