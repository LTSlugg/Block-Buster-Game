using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    /*
     * Block script handles the block logic to allow a lifepoint system, followed by death upon collision.
     */
    [SerializeField]int lifePoints = 1;



    // Update is called once per frame
    void Update()
    {
        LifepointCheck();
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            lifePoints--;
        }
    }

    
    private void LifepointCheck()
    {
        if(lifePoints <= 0)
        {
            this.gameObject.SetActive(false);
            //TODO: Create a death explosion effect
            Destroy(this.gameObject, 0.03f);
        }
    }
}
