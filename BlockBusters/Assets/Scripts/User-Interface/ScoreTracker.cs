using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Simple script gets the TMPRO component and updates the Text property to the scoreboard by pulling information and listening to the GameSession.cs
 */

public class ScoreTracker : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        GameSession.eScoreChange += ScoreTextUpdate;
        scoreText.text = GameSession.scoreAmount.ToString();
    }

    //Listener: Updates the score on score change
    private void ScoreTextUpdate()
    {
        scoreText.text = GameSession.scoreAmount.ToString();
    }

    //Unsubscribe from the eScoreChange event on destroy of this object
    private void OnDestroy()
    {
        GameSession.eScoreChange -= ScoreTextUpdate;
    }
}
