using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    //public GameObject pipePrefab;
    public float timeToSpawn = 2f, timeBetweenSpawns = 3f, spawnX = 3.75f, pipeSpeed = 3f;
    public GameObject[] pipePool;
    private int currentPipeEnabled = 0;
    public Vector2 maxMinSpawnPoint; // (x -> max y, y -> min y)

    private float timeToSpawnOG = 2;

    private bool started = false;

    // Update is called once per frame
    void Update ()
    {
        if (!started)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    timeToSpawn = Time.time + timeToSpawnOG;
                    started = true;
                }
            }
        }
		if(Time.time >= timeToSpawn && started)
        {
            SpawnPipe();
            timeToSpawn = Time.time + (timeBetweenSpawns / pipeSpeed) * 3;
        }
	}

    void SpawnPipe()
    {
        pipePool[currentPipeEnabled].SetActive(true);
        pipePool[currentPipeEnabled].transform.position = new Vector3(spawnX, Random.Range(maxMinSpawnPoint.y, maxMinSpawnPoint.x), 0);
        currentPipeEnabled++;
        if(currentPipeEnabled == pipePool.Length)
        {
            currentPipeEnabled = 0;
        }
    }

    public void Stop()
    {
        Destroy(gameObject);
    }
}
