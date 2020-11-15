using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/*
 * Simple script to allow the Main Menu functionality on button presses
 */

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator settingsVolumeAnim;
    [SerializeField] AudioMixer audioMixer;

    //Starts the Game when called
    public void StartGame()
    {
        SceneManager.ChangeScene(Levels.Level1_Forest.ToString());
        GameSession.ResetGameSession();
    }
    
    //Returns to the Start Screen When Called
    public void ReturnToStartScreen()
    {
        SceneManager.ReturnToStartScreen();
        GameSession.ResetGameSession();
    }

    //Allows Quit Game Functionality
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat("SetVolume", Mathf.Log10(sliderValue) * 20);
    }
}
