using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Ball script, for now clamps the ball max velocity
 */

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rgbd2;
    private float clampRange = 10f;
    private bool isReleased = false;

    #region Singleton
    private static Ball _instance;
    public static Ball Instance { get { return _instance; } }


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
        ResetBall();
    }

    // FixedUpdate is a monobehaviour function
    void FixedUpdate()
    {
        ClampMoveVelocity();
        DefaultBallPosition();
    }

    //This algorithm keeps the Ball from bouncing its rigidbody velocity above the clampRange variable
    private void ClampMoveVelocity()
    {
        _rgbd2.velocity = Vector3.ClampMagnitude(_rgbd2.velocity, clampRange);
    }

    //Sets the Ball Position to SpawnPosition on the Paddle
    private void DefaultBallPosition()
    {
        if (!isReleased)
        { this.transform.position = PlayerControl.Instance.spawnPOS.position; } //Sets the position of the ball to the SpawnPosition if the ball is not released
    }

    //Releases the Ball when called
    public void ReleaseBall()
    {
        if (!isReleased) //On Space Press releases the ball
        {
            isReleased = true;
            //Sets starting speed once the ball is Released to the Clamp Range (Top Speed) on Y and player move direction vel
            _rgbd2.velocity = new Vector2(PlayerControl.Instance._rgbd2.velocity.x, clampRange); 
        }
    }
  
    //Resets the Balls Position and Speed to Default
    public void ResetBall()
    {
        _rgbd2.velocity = Vector3.zero;
        this.transform.position = PlayerControl.Instance.spawnPOS.position;
        if (!this.gameObject.activeSelf) { Ball.Instance.gameObject.SetActive(true); }
        isReleased = false;
    }

    //Resets the release state of the ball
    private void OnDestroy()
    {
        isReleased = false;
    }
}
