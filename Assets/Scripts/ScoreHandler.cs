using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static int score = 0;
    private static Text text;

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

    public static void ResetScore()
    {
        score = 0;
    }
}
