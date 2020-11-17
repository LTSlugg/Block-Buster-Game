using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Handles the TransitionManagerObject and gets called on when to fade in and when to fade out
 */

public class TransitionManager : MonoBehaviour
{
    [SerializeField] GameObject transitionCanvas;
    [SerializeField] TextMeshProUGUI tipText;

    #region Singleton
    private static TransitionManager _instance;
    public static TransitionManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(transitionCanvas);
    }
    #endregion

    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    //Sets the animator Trigger via code when called to create the transition effect
    public void CallFadeOut()
    {
        _animator.SetTrigger("FadeOut");
    }
    public void CallFadeIn()
    {
        RandomTipText();
        _animator.SetTrigger("FadeIn");
    }

    //TODO: Make a Scriptable Object to hold these tips
    private void RandomTipText() //Changes the tip text on loading screen to a random one when called
    {
        int randomNum = Random.Range(0, 5);

        switch (randomNum)
        {
            case 0:
                tipText.text = "Tip: Powerup blocks dont count towards winning, but they sure do help";
                break;
            case 1:
                tipText.text = "Tip: Use Arrow Keys to move around and Space to release the ball";
                break;
            case 2:
                tipText.text = "Tip: The striped red blocks will drop a health up for you";
                break;
            case 3:
                tipText.text = "Tip: Use minion balls to your advantage";
                break;
            case 4:
                tipText.text = "Tip: Move the paddle right when youre about to hit a ball to control it better";
                break;
            case 5:
                tipText.text = "Tip: Try using powerups together";
                break;
        }


    }

}
