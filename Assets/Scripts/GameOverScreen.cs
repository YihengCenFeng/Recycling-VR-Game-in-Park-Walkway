using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public static GameOverScreen inst;
    public Canvas gameOverScreen;
  
    public void Setup()
    {
        gameOverScreen.enabled = true;
    }
}
