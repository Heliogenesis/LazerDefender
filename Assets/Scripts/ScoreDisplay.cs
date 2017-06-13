﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    void Start()
    {
        Text myText = GetComponent<Text>();
        myText.text = "Score: " + ScoreHandler.score.ToString();
        ScoreHandler.ResetScore();
    }
}