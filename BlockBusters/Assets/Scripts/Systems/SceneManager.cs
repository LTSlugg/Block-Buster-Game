using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Designed to allow level changes whenever called by whatever script, also has a default function to go to GameOver and StartOver the Game
 */

//Keep Track of the Levels for Easy scene change
public enum Levels
{
    Level1_Forest,
    Level2_Mountains,
    Level3_City,
    VictoryScreen
}

public static class SceneManager
{
    //Transition Data
    private static bool IsTransitioning = false;
    private static float fadeTime = 3f;

    //Goes to StartScreen Scene
    public static void ReturnToStartScreen()
    {
        Cursor.visible = true;
        TransitionManager.Instance.StartCoroutine(TransitionScene("StartScreen")); //Have the Transition Manager Call on the Coroutine TransitionScene in this Class
        GameSession.ResetGameSession();
    }

    //Changes scene to whatever string is parsed through
    public static void ChangeScene(string SceneName)
    {

        TransitionManager.Instance.StartCoroutine(TransitionScene(SceneName)); //Have the Transition Manager Call on the Coroutine TransitionScene in this Class
        if(SceneName == "VictoryScreen") { Cursor.visible = true; }
        else { Cursor.visible = false;  }    
    }

    //Goes to the GameOver Scene
    public static void GameOver()
    {
        Cursor.visible = true;
        TransitionManager.Instance.StartCoroutine(TransitionScene("GameOver")); //Have the Transition Manager Call on the Coroutine TransitionScene in this Class
    }

    //Handles the scene transition to make a fluid fade in and fade out sequence while loading the scene at the appropiate times
    static IEnumerator TransitionScene(string SceneName)
    {
        if (!IsTransitioning)
        {
            IsTransitioning = true; //A check to prevent Transitioning Overlap
            if (Ball.Instance != null) { Ball.Instance.ResetBall(); } //Resets the ball to prevent the ball dying while in transition
            TransitionManager.Instance.CallFadeIn(); //Calls this Method in the TransitionManager Singleton

            yield return new WaitForSeconds(fadeTime); //Fade wait time before allowing fade out

            UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName); //Change the Scene while screen is faded into black
            
            TransitionManager.Instance.CallFadeOut(); //Calls this Method in the TransitionManager Singleton

            switch (SceneName) //Conditional Switch Statement to play proper voiceover audio clip
            {
                default:
                    break;
                case "GameOver":
                    SoundManager.Instance.PlayGameOverAudioClip();
                    break;
                case "VictoryScreen":
                    SoundManager.Instance.PlayVictoryAudioClip();
                    break;
                case "Level1_Forest":
                    SoundManager.Instance.PlayStartAudioClip();
                    break;
            }

            IsTransitioning = false;
        }
    }
}
