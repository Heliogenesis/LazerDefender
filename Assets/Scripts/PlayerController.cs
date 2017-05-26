using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float padding;
    public GameObject projectile;
    public float projectileSpeed;
    public float lazerFireRate = .2f;

    public RuntimeAnimatorController farLeft;
    public RuntimeAnimatorController left;
    public RuntimeAnimatorController forward;
    public RuntimeAnimatorController right;
    public RuntimeAnimatorController farRight;


    float xmin;
    float xmax;

    private void FireLazer()
    {
        GameObject playerLazer = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        playerLazer.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
    }

    private void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
        xmin = leftmost.x;
        xmax = rightmost.x;
    }


    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("FireLazer", 0.000000001f, lazerFireRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("FireLazer");
        }

		if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            GetComponent<Animator>().runtimeAnimatorController = farRight;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            GetComponent<Animator>().runtimeAnimatorController = farLeft;
        }
        else
        {
            GetComponent<Animator>().runtimeAnimatorController = forward;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin + padding, xmax - padding);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
}
