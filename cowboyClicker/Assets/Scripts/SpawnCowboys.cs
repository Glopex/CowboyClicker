using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCowboys : MonoBehaviour
{
    public GameObject cowboyPrefab;
    public float timeBetweenSpawn;
    private float spawnTime;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        Instantiate(cowboyPrefab, transform.position, transform.rotation);
    }
}
