using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public float timeToSpawn = 10, timeBetweenSpawns = 10f, spawnX = 19.2f, spawnY = -0.9f;
    public GameObject[] groundPool;
    private int currentPipeEnabled = 0;

    private void Start()
    {
        groundPool[currentPipeEnabled].SetActive(true);
        groundPool[currentPipeEnabled].transform.position = new Vector3(0, spawnY, 0);
        currentPipeEnabled++;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Time.time >= timeToSpawn)
        {
            SpawnGround();
            timeToSpawn = Time.time + timeBetweenSpawns;
        }
    }

    void SpawnGround()
    {
        groundPool[currentPipeEnabled].SetActive(true);
        groundPool[currentPipeEnabled].transform.position = new Vector3(spawnX, spawnY, 0);
        currentPipeEnabled++;
        if (currentPipeEnabled == groundPool.Length)
        {
            currentPipeEnabled = 0;
        }
    }
}
