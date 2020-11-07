using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Use an Enum to create a simple list of powerups and use a few logic checks to run the proper code
 */

public class PowerUps : MonoBehaviour
{
    private enum TypeOfPowerup //Tracker of the type of powerup this is
    {
        HealthUp,
        SpeedUp,
        MultiBall
    }

    [SerializeField]TypeOfPowerup typeOfPowerUp; //Used to allow inspector selection of the type of PowerUp

    [Header("PowerUp Specific Attributes")]
    [SerializeField][Range (1, 3)] int healthUpAmount = 1;
    [SerializeField][Range(8, 20)]  float speedUpTimer = 8;
    [SerializeField] GameObject minionBallObject;


    //Logic Algorithm for PowerUps on Collision Trigger with PlayerPaddle
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerPaddle")
        {
            switch (typeOfPowerUp)
            {
                case TypeOfPowerup.HealthUp:
                    GameSession.IncreaseHealth(healthUpAmount);
                    break;
                
                case TypeOfPowerup.SpeedUp:
                    PlayerControl.Instance.DoSpeedBuff(speedUpTimer);
                    break;

                case TypeOfPowerup.MultiBall:
                    SpawnMinionBalls(3);
                    Ball.Instance.ResetBall();
                    break;
            }

            Destroy(this.gameObject);
        }
    }

    private void SpawnMinionBalls(int AmountToSpawn)
    {
        for (int i = 0; i < AmountToSpawn; i++)
        {
            GameObject MinionBall = Instantiate(minionBallObject, Ball.Instance.transform.position, Quaternion.identity) as GameObject;
        }
    }
}
