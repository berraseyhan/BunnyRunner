using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    private int highScore = 0;
    private bool isGameOver = false;
    private UIManager uiManager;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()
    {
        uiManager = Object.FindAnyObjectByType<UIManager>();
        uiManager.UpdateScore(score, highScore);
    }

    private float scoreFloat = 0f;

    private void Update()
    {
        if (!isGameOver)
        {
            scoreFloat += Time.deltaTime * 10f;
            score = (int)scoreFloat;
            uiManager.UpdateScore(score, highScore);
        }
    }


    public int GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        uiManager.ShowGameOver(score, highScore);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
