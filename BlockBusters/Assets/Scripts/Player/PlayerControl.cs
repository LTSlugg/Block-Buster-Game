﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles all of the Logic behind moving the player and allowing them to change states as they pickup powerups
 */

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D _rgbd2;

    [SerializeField] public Transform spawnPOS;
    [SerializeField] float moveSpeed = 12f; //Default MoveSpeed
    private bool isSpedUp = false;



    #region Singleton
    private static PlayerControl _instance;
    public static PlayerControl Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
    


    // Start is called before the first frame update
    void Start()
    {
       _rgbd2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputChecker();
    }

    //Checks for player input by checking if the Horizontal Axis (Raw) has input, then sets the velocity to the speed variable times input direction on X axis
    //Will also slightly rotate the player depending on the direction they are moving
    private void InputChecker()
    {
        _rgbd2.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), 0);
        transform.eulerAngles = new Vector3(0, 0, Input.GetAxisRaw("Horizontal") * -10);

        if(Input.GetKey(KeyCode.Space))
        {
            Ball.Instance.ReleaseBall();
        }
    }


    //A simple coroutine call to increase the movement speed of the Paddle when it picks up a speed buff called by the powerups script
    public void DoSpeedBuff(float SpeedUpTime)
    {
        StartCoroutine(SpeedUpBuff(SpeedUpTime));
    }
    IEnumerator SpeedUpBuff(float SpeedUpTime)
    {
        if (!isSpedUp)
        {
            isSpedUp = true;
            float defaultMoveSpeed = moveSpeed;
            moveSpeed *= 2;

            yield return new WaitForSeconds(SpeedUpTime);

            moveSpeed = defaultMoveSpeed;
            isSpedUp = false;
        }
    }
}
