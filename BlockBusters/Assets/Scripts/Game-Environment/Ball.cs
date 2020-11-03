﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Ball script, for now clamps the ball max velocity
 */

public class Ball : MonoBehaviour
{
    Rigidbody2D _rgbd2;
    [SerializeField] float clampRange = 8f;

    // Start is called before the first frame update
    void Start()
    {
        _rgbd2 = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is a monobehaviour function
    void FixedUpdate()
    {
        ClampMoveVelocity();
    }

    //This algorithm keeps the Ball from bouncing its rigidbody velocity above the clampRange variable
    private void ClampMoveVelocity()
    {
        _rgbd2.velocity = Vector3.ClampMagnitude(_rgbd2.velocity, clampRange);
    }
}
