﻿using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;
    public Text scoreText;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
    }

    public void DecrementScore()
    {
        if (score == 0)
            FindObjectOfType<VRMovement>().Die();
        else
        {
            score--;
            scoreText.text = "SCORE: " + score;
        }
    }

    private void Awake()
    {
        inst = this;
    }
}
