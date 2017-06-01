using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float health = 250f;

    public float speed;
    public float padding;
    public GameObject projectile;
    public float projectileSpeed;
    public float laserFireRate = .2f;

    public RuntimeAnimatorController farLeft;
    public RuntimeAnimatorController left;
    public RuntimeAnimatorController forward;
    public RuntimeAnimatorController idle;
    public RuntimeAnimatorController right;
    public RuntimeAnimatorController farRight;


    float xmin;
    float xmax;

    private void FireLaser()
    {
        GameObject playerLaser = Instantiate(projectile, transform.position + new Vector3(0, 0, 1), Quaternion.identity) as GameObject;
        playerLaser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
    }

    private void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftmost.x;
        xmax = rightmost.x;
    }


    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("FireLaser", 0.000000001f, laserFireRate);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("FireLaser");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Animator>().runtimeAnimatorController = farLeft;
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Animator>().runtimeAnimatorController = farRight;
            transform.position += Vector3.right * speed * Time.deltaTime;

        }
        else if (GetComponent<Animator>().runtimeAnimatorController != idle || GetComponent<Animator>().runtimeAnimatorController != forward)
        {
            GetComponent<Animator>().runtimeAnimatorController = idle;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin + padding, xmax - padding);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
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
                Destroy(gameObject);
            }
        }
    }
}
