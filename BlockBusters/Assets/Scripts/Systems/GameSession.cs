using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This static class uses the observer pattern event system to discuss with various components including UI, Audio and such 
 * to track health points and score amount and react when these elements are changed. 
 * 
 * Also tracks the win and lose conditions of the game to call on the SceneManager.cs static class for changes in scenes
 */


public static class GameSession
{
    public static event Action eScoreChange;
    public static event Action eHealthIncrease;
    public static event Action eHealthDecrease;
    
    public static int scoreAmount = 0; //Tracker of the players score points
    public static int healthPoints = 3; //Tracker of the players health points
    private static int blocksInGame = 0; //Tracker of the amount of Blocks in the Game
    public static int respawnTimer = 3;


    //Simple way to keep track of the current Level to help Load the correct Scene
    private enum CurrentLevel
    {
        Level1,
        Level2,
        Level3
    }
    private static CurrentLevel currentLvl;

    //Function that adds a point amount to the Score tracked by this class
    public static void AddToScore(int PointAmount)
    {
        scoreAmount += PointAmount;
        eScoreChange();
    }

    //Function that increases the health by addAmount that is Parsed through on call, then calls the eHealthIncrease event for listeners to react
    public static void IncreaseHealth(int AddAmount)
    {
        healthPoints += AddAmount;
        eHealthIncrease();
    }
    //Function that increases the health by removeAmount that is Parsed through on call, then calls the eHealthDecrease event for listeners to react
    public static void DecreaseHealth(int RemoveAmount)
    {
        healthPoints -= RemoveAmount;
        eHealthDecrease();
        SoundManager.Instance.PlayDeathAudioClip();
        if(healthPoints <= 0)
        {
            LevelChange(true);
        }
    }
    
    //Will add a block to the list when the block is created to keep track of how many blocks are left
    public static void AddBlockToList()
    {
        blocksInGame++;
    }

    //Will remove a block then check if there are any blocks left in the list and call next game scene when there are none left
    public static void RemoveBlockFromList()
    {
        blocksInGame--;

        if(blocksInGame <= 0)
        {
            blocksInGame = 0; //Resets the blocksInGame being tracked by this class
            LevelChange(false); 
        }
    }

    //Algorithm to determine what level the player is in and change the scene accordingly by calling on the scenemanager class, will also change the current level.
    private static void LevelChange(bool DidPlayerLose)
    {
        if(DidPlayerLose) //Will reset the game
        { 
            SceneManager.GameOver();
            return;
        }

        switch (currentLvl)
        {
            case CurrentLevel.Level1:
                SceneManager.ChangeScene(Levels.Level2_Mountains.ToString());
                Cursor.visible = false;
                currentLvl = CurrentLevel.Level2;
                break;
            case CurrentLevel.Level2:
                SceneManager.ChangeScene(Levels.Level3_City.ToString());
                currentLvl = CurrentLevel.Level3;
                break;
            case CurrentLevel.Level3:
                SceneManager.ChangeScene(Levels.VictoryScreen.ToString()); //On game End Changes to the Victory Screen
                break;
        }
    }

    public static void ResetGameSession()
    {
        healthPoints = 3;
        scoreAmount = 0;
        blocksInGame = 0;
        currentLvl = CurrentLevel.Level1;
    }
}
