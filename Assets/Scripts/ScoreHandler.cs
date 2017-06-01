using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    int score = 0;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "Score: " + score.ToString();
    }

    public void ScoreUpdater(int addScore)
    {
        score += addScore;
        text.text = "Score: " + score.ToString();

    }

    public void ResetScore()
    {
        score = 0;
        text.text = "Score: " + score.ToString();
    }
}
