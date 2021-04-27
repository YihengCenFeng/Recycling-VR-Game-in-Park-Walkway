using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score=0;
    public static GameManager inst;
    public Text scoreText;

    public Image[] lives;
    public int livesRemaining;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public void DecrementScore()
    {
        if (score == 0)
            FindObjectOfType<VRMovement>().Die();
        else
        {
            score--;
            scoreText.text = "Score: " + score;
        }
    }

    public void LoseLife()
    {
        livesRemaining--;
        //lives[livesRemaining].enabled = false;
        lives[livesRemaining].color = new Color32(55, 40, 40, 125);

        if (livesRemaining == 0)
            FindObjectOfType<VRMovement>().Die();
    }

    private void Awake()
    {
        inst = this;
    }
}
