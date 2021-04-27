using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score:  " + score.ToString();
    }

    public void hide()
    {
        gameObject.SetActive(false);
    }
}
