using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    public float width = 10f;
    public float height = 5f;
    public float speed = 5;

    private bool movingRight = true;
    private float xMax;
    private float xMin;


    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void Start ()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xMax = rightEdge.x;
        xMin = leftEdge.x;

        foreach (Transform child in transform)
        {
            if (child.tag == "EnemySmall")
            {
                GameObject enemy = Instantiate(enemyPrefab1, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child;
            }
            else if (child.tag == "EnemyMedium")
            {
                GameObject enemy = Instantiate(enemyPrefab2, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child;
            }
            else if (child.tag == "EnemyLarge")
            {
                GameObject enemy = Instantiate(enemyPrefab3, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child;
            }
            else
            {
                GameObject enemy = Instantiate(enemyPrefab1, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child;
            }
        }
	}

    private void Update()
    {
        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);

        if (leftEdgeOfFormation < xMin)
        {
            movingRight = true;
        }
        else if (rightEdgeOfFormation > xMax)
        {
            movingRight = false;
        }
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (!movingRight)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
