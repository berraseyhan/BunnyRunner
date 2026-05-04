using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    private Camera mainCamera;
    private int currentColor = 0;

    private void Start()
    {
        mainCamera = Camera.main;
        mainCamera.backgroundColor = colors[0];
    }
    private void Update()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.IsGameOver()) return;

        int score = GameManager.Instance.GetScore();
        int newColor = (score / 300) % colors.Length;
        if (newColor != currentColor)
            ChangeColor(newColor);
    }

    private void ChangeColor(int index)
    {
        currentColor = index;
        mainCamera.backgroundColor = colors[index];
    }
}