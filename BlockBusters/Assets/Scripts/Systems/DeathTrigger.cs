using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Simple Script that decreases the players health and destroys the ball when the Main Ball goes through it then Respawns a new one
 */

public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            GameSession.DecreaseHealth(1);

            Destroy(collision.gameObject, 3f);


            //TODO: Work on this Newball Instantiate Algorithm to make it wait some time then spawn the ball
            GameObject newBall = Instantiate(collision.gameObject, Vector3.zero, Quaternion.identity); //Creates a new ball when this one is destroyed
            collision.gameObject.SetActive(true);
        }
    }
}
