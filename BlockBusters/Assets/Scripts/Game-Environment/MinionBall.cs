using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A MinionBall script, since the Ball is a Singleton this will handle the clamp and start velocity of the MinionBall to prevent any bugs.
 */

public class MinionBall : MonoBehaviour
{
    private Rigidbody2D _rgbd2;
    private float clampRange = 15f;

    // Start is called before the first frame update
    void Start()
    {
        _rgbd2 = GetComponent<Rigidbody2D>();
        _rgbd2.velocity = new Vector2(Random.Range(-clampRange/2, clampRange/2), Random.Range(1, clampRange));
    }

    // Update is called once per frame
    void Update()
    {
        ClampMoveVelocity();   
    }

    private void ClampMoveVelocity()
    {
        _rgbd2.velocity = Vector3.ClampMagnitude(_rgbd2.velocity, clampRange);
    }
}
