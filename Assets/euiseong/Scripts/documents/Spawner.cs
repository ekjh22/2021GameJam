using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timeAfterReduce;
    float timeAfterSpawn;

    float xScreenHalfSize;
    float yScreenHalfSize;

    float blockSpawnTime;
    float nextObstacleSpawnTime;

    int randomSpawn;
    GameObject[] obstacles;

    Vector2 spawnPoint;

    void Start()
    {
        yScreenHalfSize = Camera.main.orthographicSize;
        xScreenHalfSize = yScreenHalfSize * Camera.main.aspect;

        nextObstacleSpawnTime = 1;
    }

    void Update()
    {
        if (timeAfterSpawn >= nextObstacleSpawnTime)
        {
            RandomPosition();
            ObstacleSpawn();
        }
    }

    void ObstacleSpawn()
    {
        float randomScale = Random.Range(0.5f, 1.2f);

        int randomSpawn = Random.Range(0, obstacles.Length);
        obstacles[randomSpawn].transform.localScale = Vector3.one * randomScale;
        Instantiate(obstacles[randomSpawn], spawnPoint, Quaternion.identity);
    }

    void RandomPosition()
    {
        spawnPoint.x = Random.Range(-xScreenHalfSize, xScreenHalfSize);
        spawnPoint.y = yScreenHalfSize;
    }
}
