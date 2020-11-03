using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Ball script, handles the balls interactions with the paddles and blocks as well as any additional logic to prevent bugs and issues.
 */

public class Ball : MonoBehaviour
{
    Rigidbody2D _rgbd2;
    [SerializeField] float clampRange = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _rgbd2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ClampMoveVelocity();
    }


    private void ClampMoveVelocity()
    {
        _rgbd2.velocity = Vector3.ClampMagnitude(_rgbd2.velocity, clampRange);
    }
}
