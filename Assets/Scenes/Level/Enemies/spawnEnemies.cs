using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour {

    // Prefab to spawn
    public GameObject spawnee;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(2f);
        }
    }

    void Spawn()
    {
        float rightScreenBound = 999;                    // set value for this
        float randomY = Random.Range(0, 1000);

        Instantiate(spawnee, new Vector3(rightScreenBound, randomY, 0), Quaternion.identity);
    }
}
