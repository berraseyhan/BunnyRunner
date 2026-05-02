using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite brokenHeart;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject gameOverPanel;

    public void UpdateHearts(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = brokenHeart;
        }
    }

    public void UpdateScore(int score, int highScore)
    {
        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
    }

    public void ShowGameOver(int finalScore, int highScore)
    {
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Your Score: " + finalScore;
        highScoreText.text = "High Score: " + highScore;
    }

    public void HideGameOver()
    {
        gameOverPanel.SetActive(false);
    }

    public IEnumerator PlayHeartBreakAnimation(int heartIndex)
    {
        hearts[heartIndex].sprite = brokenHeart;
        hearts[heartIndex].transform.localScale = new Vector3(1.5f, 1.5f, 1f);
        yield return new WaitForSeconds(0.1f);
        hearts[heartIndex].transform.localScale = Vector3.one;
    }
}