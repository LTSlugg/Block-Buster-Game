using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Block script handles the block logic to track several variables and states, followed by death upon collision functionality. Tired bad description 'iKnow'
 */


public class Block : MonoBehaviour
{
    Animator _animator;
    
    [Header("Block Stats")]
    [SerializeField] int lifePoints = 3;
    [SerializeField] int pointWorthAmount = 1000;
    
    [Header("Death GameObject")]
    [SerializeField] GameObject deathExplosion; //Lets create a dependancy, why not. We've been good with our coding so far. This is plugged in VIA Inspector.

    [Header("PowerUp Information")]
    [SerializeField] bool canSpawnPowerUps = false;
    [SerializeField] GameObject powerUpObject;


    private bool isShaking = false; //Logic Check Variable for preventing overflowing of the shake coroutine 

    private void Start()
    {
        if (!canSpawnPowerUps) { GameSession.AddBlockToList(); }
        
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LifepointCheck();
    }

    //Will call this when the ball exits the area of the Collider on this gameObject
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ball" || collision.tag == "MinionBall")
        {
            lifePoints--;
            SoundManager.Instance.PlayBlockDeathAudioClip(); //Calls on the soundmanager to player a clip when hit
            
            if (lifePoints > 0) //Quick check prevents error when block dies too fast and tries to recall coroutine
            {
                StartCoroutine("StartShakeEffect");
            }
        }
    }

    //Checks if the Lifepoints is below Zero then does a death effect and destroys this gameObject
    private void LifepointCheck()
    {
        if(lifePoints <= 0)
        {
            //Hides this object upon death before eliminating to run more logic behind the scenes
            this.gameObject.SetActive(false);

            //Adds the score of this block to the players High Score
            GameSession.AddToScore(pointWorthAmount);
            
            //Creates a instance of this effect to keep from destroying when this gameObject dies
            GameObject starDeathExplosion = Instantiate(deathExplosion, this.transform.position, Quaternion.identity) as GameObject;
                
            //Spawn Powerup if Powerup Block
            if (canSpawnPowerUps) { SpawnPowerUp(); }
            
            //Removes the block from the game session list to keep track of win condition, wont track powerup Blocks
            else if (!canSpawnPowerUps) { GameSession.RemoveBlockFromList(); }
            
            //Garbage collecter
            Destroy(this.gameObject, .03f);
        }
    }

    //Sets the Animator Boolean "WasHit" to true for some time then resets it to false using a boolean to check if it was hit (Simple Effect for Simple Game - K.I.S.S)
    IEnumerator StartShakeEffect()
    {
        if (!isShaking)
        {
            isShaking = true;
            _animator.SetBool("WasHit", true);

            yield return new WaitForSeconds(.5f);

            _animator.SetBool("WasHit", false);
            isShaking = false;
        }
    }

    private void SpawnPowerUp()
    {
        if(Random.Range(0, 1) >= 0)
        {
            GameObject powerUp = Instantiate(powerUpObject, this.transform.position, Quaternion.identity) as GameObject;
        }
    }
}
