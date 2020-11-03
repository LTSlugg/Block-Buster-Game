using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    /*
     * Block script handles the block logic to allow a lifepoint system, followed by death upon collision.
     */

    Animator _animator;
    
    [SerializeField] int lifePoints = 1;
    [SerializeField] int pointWorthAmount = 10;
    [SerializeField] GameObject deathExplosion; //Lets create a dependancy, why not. We've been good with our coding so far. This is plugged in VIA Inspector.

    private bool isShaking = false;

    private void Start()
    {
        if (GetComponent<Animator>() == null) { return; }
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
        
            if (lifePoints > 0) //Prevents bug when block dies too fast and tries to recall coroutine
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
            this.gameObject.SetActive(false);
            GameSession.AddToScore(pointWorthAmount);
            
            //Creates a instance of this effect to keep from destroying when this gameObject dies
            GameObject starDeathExplosion = Instantiate(deathExplosion, this.transform.position, Quaternion.identity) as GameObject; 
            
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
}
