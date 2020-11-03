using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Handles the logic behind spawning the number of Hearts on the UI and making them despawn when the player consequently loses a point of HP
 * by tracking the HP through the GameSession and using Observer pattern event sys the HeartUpdate() Function listens in and updates accordingly.
 */

public class HealthManager : MonoBehaviour
{
    private int maxHealth = 7;
    [SerializeField] Image[] hearts;

    //Start Initialization and subscription to the observer in GameSession.cs
    private void Start()
    {
        HeartUpdate();

        GameSession.eHealthIncrease += HeartUpdate;
        GameSession.eHealthDecrease += HeartUpdate;
    }


    //A 'for loop' algorithm updates the heart UI elements when called
    private void HeartUpdate()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (GameSession.healthPoints > maxHealth)
            {
                GameSession.healthPoints = maxHealth; //Sets health to max health if greater than
            }

            if (i < GameSession.healthPoints) //Will spawn hearts images if I is less than the healthpoints
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    //Unsubscribe from the observer to prevent inconstensies
    private void OnDestroy()
    {
        GameSession.eHealthIncrease -= HeartUpdate;
        GameSession.eHealthDecrease -= HeartUpdate;
    }
}
