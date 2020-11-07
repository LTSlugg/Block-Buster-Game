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
    Level3_City
}

public static class SceneManager
{
    //Goes to StartScreen Scene
    public static void ReturnToStartScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScreen");
    }

    //Changes scene to whatever string is parsed through
    public static void ChangeScene(string SceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);
    }

    //Goes to the GameOver Scene
    public static void GameOver()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        GameSession.ResetGameSession();
    }
}
