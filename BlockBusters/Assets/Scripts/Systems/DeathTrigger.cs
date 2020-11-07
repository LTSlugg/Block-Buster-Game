using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Simple Script that decreases the players health and calls for the Ball Singleton to reset when ball passes through this collider
 */


public class DeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            GameSession.DecreaseHealth(1); //Decrease the Overall health of the Player via GameSession

            StartCoroutine(RespawnBall()); //Respawns the Ball
        }
        if (collision.tag == "MinionBall")
        {
            Destroy(collision.gameObject);
        }
    }

    //A simple Coroutine that respawns the ball after waiting a few seconds
    private IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(GameSession.respawnTimer);
        Ball.Instance.ResetBall();
    }
}
