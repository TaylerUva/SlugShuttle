﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

    public float baseSpawnRate = 3;
    public GameObject enemyObject;
    private int enemyCount = 0;
    private int difficulty;

    Camera cam;
    float height;
    float width;
    private float randPos;
    private int randSprite;
    private string[] enemySprites = { "redGub", "blueGub", "greenGub" };
    private float spawnTimer;

    // Use this for initialization
    void Start() {
        cam = Camera.main;
        height = 1.1f * cam.orthographicSize;
        width = height * cam.aspect;
        ResetSpawnTimer();
        Spawn();
        Debug.Log(spawnTimer);
    }

    // Update is called once per frame
    void Update() {
        height = 1.1f * cam.orthographicSize;
        width = height * cam.aspect;
        if (spawnTimer <= 0) Spawn();
        spawnTimer -= Time.deltaTime;
    }

    private void ResetSpawnTimer(){
        spawnTimer = baseSpawnRate/PlayerPrefs.GetInt("difficulty");
    }

    private void Spawn() {
        enemyCount += 1;
        randSprite = Random.Range(0, enemySprites.Length - 1);
        enemyObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(enemySprites[randSprite]);
        randPos = Random.Range(-(width / 2), (width / 2));
        Vector2 position = new Vector2(randPos, height);
        ResetSpawnTimer();
        enemyObject.name = ("Enemy" + enemyCount);
        Instantiate(enemyObject, position, transform.rotation);
    }
}
