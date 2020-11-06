using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Use an Enum to create a simple list of powerups and use a few logic checks to run the proper code
 * TODO: Better Description here tired bleh
 */

public class PowerUps : MonoBehaviour
{
    private enum TypeOfPowerup
    {
        HealthUp,
        SpeedUp,
        MultiBall
    }

    [SerializeField]TypeOfPowerup typeOfPowerUp;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerPaddle")
        {
            switch (typeOfPowerUp)
            {
                case TypeOfPowerup.HealthUp:
                    GameSession.IncreaseHealth(1);
                    break;
                
                case TypeOfPowerup.SpeedUp:
                    Debug.Log("Speed Up Logic Here");
                    break;

                case TypeOfPowerup.MultiBall:
                    Debug.Log("Multiball Logic here");
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
