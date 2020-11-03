using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles all of the Logic behind moving the player and allowing them to change states as they pickup powerups
 */

//TODO: Create a clamp algorithm that will keep the playerpaddle from leaving the bounds of the screen

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D _rgbd2;
    [SerializeField]float moveSpeed = 12f; //Default MoveSpeed
    

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
    }
}
