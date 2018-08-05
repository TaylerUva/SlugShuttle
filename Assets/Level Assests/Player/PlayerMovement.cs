using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public bool yAxisEnabled = true;
    private float spriteWidth;
    private int maxSpeed = 10;
    private float moveX;
    private float moveY;

    private void Start() {
        spriteWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update() {
        PlayerMove();
    }

    void PlayerMove() {
        Vector3 pos = transform.position;
        //CONTROLS
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        if (yAxisEnabled) pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
        if ((pos.x + spriteWidth/2) > Camera.main.orthographicSize) pos.x = -Camera.main.orthographicSize + spriteWidth/2;
        if ((pos.x - spriteWidth/2) < -Camera.main.orthographicSize) pos.x = Camera.main.orthographicSize - spriteWidth/2;

        transform.position = pos;
    }
}
