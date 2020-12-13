using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public bool gameOver = false;
    public float minSpawnTime, maxSpawnTime;
    public static ObstacleSpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine("Spawn");
    }
    IEnumerator Spawn()
    {
        float waitTime = 1f;
        yield return new WaitForSeconds(waitTime);
        while (!gameOver)
        {
            
            SpawnObstacle();
            waitTime = Random.Range(minSpawnTime,maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
        
    }
    void SpawnObstacle()
    {
        int rand = Random.Range(0, 5);
        var obj = Instantiate(obstacles[rand], transform.position, Quaternion.identity);
        obj.gameObject.transform.parent = gameObject.transform;
    }
}
