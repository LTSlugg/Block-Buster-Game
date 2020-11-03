using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        GameSession.eScoreChange += ScoreTextUpdate;
    }


    private void ScoreTextUpdate()
    {
        scoreText.text = GameSession.scoreAmount.ToString();
    }


    private void OnDestroy()
    {
        GameSession.eScoreChange -= ScoreTextUpdate;
    }
}
