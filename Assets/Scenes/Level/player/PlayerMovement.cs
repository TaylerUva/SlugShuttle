using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private int maxSpeed = 10;
    private float moveX;
    private float moveY;

    // Update is called once per frame
    void Update() {
        PlayerMove();
    }

    void PlayerMove() {
        Vector3 pos = transform.position;
        //CONTROLS
        pos.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;

        transform.position = pos;
    }
}
