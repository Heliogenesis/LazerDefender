using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    public float width = 10f;
    public float widthOffset;
    public float height = 5f;
    public float heightOffset;
    public float speed = 5;
    public int scoreGiven = 100;

    public float spawnDelay = .5f;

    private bool movingRight = true;
    private float xMax;
    private float xMin;


    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + new Vector3(widthOffset, heightOffset), new Vector3(width, height));
    }

    void Start()
    {
        GameObject.Find("Score").GetComponent<ScoreHandler>();
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
        xMax = rightEdge.x;
        xMin = leftEdge.x;
        SpawnEnemies();
    }

    private void Update()
    {
        float rightEdgeOfFormation = transform.position.x + (0.5f * width) + widthOffset;
        float leftEdgeOfFormation = transform.position.x - (0.5f * width) - widthOffset;

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
        if (AllMembersDead())
        {
            Debug.Log("Empty Formation");
            SpawnUntilFull();
        }
    }

    private void SpawnEnemies()
    {

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
            else //spawns a small enemy if the tag does not exist for the desired enemy
            {
                GameObject enemy = Instantiate(enemyPrefab1, child.transform.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = child;
            }
        }
    }

    void SpawnUntilFull()
    {
        Transform nextFreePosition = NextFreePosition();
        if (nextFreePosition)
        {
            if (tag == "EnemySmall")
            {
                GameObject enemy = Instantiate(enemyPrefab1, nextFreePosition.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = nextFreePosition;
            }
            else if (tag == "EnemyMedium")
            {
                GameObject enemy = Instantiate(enemyPrefab2, nextFreePosition.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = nextFreePosition;
            }
            else if (tag == "EnemyLarge")
            {
                GameObject enemy = Instantiate(enemyPrefab3, nextFreePosition.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = nextFreePosition;
            }
            else //spawns a small enemy if the tag does not exist for the desired enemy
            {
                GameObject enemy = Instantiate(enemyPrefab1, nextFreePosition.position, Quaternion.identity) as GameObject;
                enemy.transform.parent = nextFreePosition;
            }
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", spawnDelay);
            Debug.Log("invoked");
        }
        else
        {
            CancelInvoke("SpawnUntilFull");
        }

    }

    private bool AllMembersDead()
    {
        foreach(Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    private Transform NextFreePosition()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount == 0)
            {
                return childPositionGameObject;
            }
        }
        return null;
    }


}
