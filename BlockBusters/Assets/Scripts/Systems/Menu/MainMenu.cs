using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.ChangeScene(Levels.Level1_Forest.ToString());
        GameSession.ResetGameSession();
    }
    
    public void ReturnToStartScreen()
    {
        SceneManager.ReturnToStartScreen();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
