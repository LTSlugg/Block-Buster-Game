using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Simple Script that decreases the players health and destroys the ball when the Main Ball goes through it then Respawns a new one
 */


public class DeathTrigger : MonoBehaviour
{

    [SerializeField] float respawnTimer = 7f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            GameSession.DecreaseHealth(1); //Decrease the Overall health of the Player via GameSession

            StartCoroutine(RespawnBall(collision.gameObject)); //Respawns the Ball
            Destroy(collision.gameObject, respawnTimer); //Destroys the Ball that passes through this point
        }
    }

    //A simple Coroutine that respawns the ball after waiting a few seconds
    private IEnumerator RespawnBall(GameObject ballGameObject)
    {
        yield return new WaitForSeconds(respawnTimer/2);
        GameObject newBall = Instantiate(ballGameObject, Vector3.zero, Quaternion.identity); //Creates a new ball when this one is destroyed
        ballGameObject.SetActive(true);
    }
}
