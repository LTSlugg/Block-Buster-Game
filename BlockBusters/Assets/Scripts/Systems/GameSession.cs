using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This static class uses the observer pattern event system to discuss with various components including UI, Audio and such 
 * to track health points and score amount and react when these elements are changed.
 */

public static class GameSession
{
    public static event Action eScoreChange;
    public static event Action eHealthIncrease;
    public static event Action eHealthDecrease;
    
    public static int scoreAmount;
    public static int healthPoints;


    public static void AddToScore(int pointAmount)
    {
        scoreAmount += pointAmount;
        eScoreChange();
    }


    public static void IncreaseHealth(int addAmount)
    {
        healthPoints += addAmount;
        eHealthIncrease();
    }

    public static void DecreaseHealth(int removeAmount)
    {
        healthPoints -= removeAmount;
        eHealthDecrease();
    }
}
