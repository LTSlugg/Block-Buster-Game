using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    /*
     * Simple Script that decreases the players health and destroys the ball when the Main Ball goes through it
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            GameSession.DecreaseHealth(1);
            Destroy(collision.gameObject, 3f);
        }
    }
}
