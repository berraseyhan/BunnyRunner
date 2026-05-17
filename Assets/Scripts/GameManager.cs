using System;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score = 0;
    private int highScore = 0;
    private bool isGameOver = false;
    private UIManager uiManager;

    [Header("Audio Settings")]
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip carrotSound;
    public AudioClip collisionSound;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        highScore = PlayerPrefs.GetInt("HighScore", 0);

    }

    private void Start()
    {
        isGameOver = false;
        uiManager = UnityEngine.Object.FindAnyObjectByType<UIManager>();
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(
        UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
