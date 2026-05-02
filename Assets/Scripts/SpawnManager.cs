using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private GameObject carrot;

    private float spawnTime = 2f;
    private float timer = 0f;
    private float carrotTimer = 0f;
    private float carrotSpawnTime = 8f;

    private void Update()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.IsGameOver()) return;

        timer += Time.deltaTime;
        carrotTimer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            SpawnObstacle();
            timer = 0f;
        }

        if (carrotTimer >= carrotSpawnTime)
        {
            SpawnCarrot();
            carrotTimer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Length);
        float yPos = -2.3f;

        if (obstacles[randomIndex].name == "WaterObstacle")
            yPos = -3.01f;

        if (obstacles[randomIndex].name == "BirdObstacle")
            yPos = (Random.value > 0.5f) ? 0f : -2.3f;
        
        Instantiate(obstacles[randomIndex], new Vector3(15f, yPos, 0f), Quaternion.identity);
    }

    private void SpawnCarrot()
    {
        if (carrot != null)
            Instantiate(carrot, new Vector3(15f, -1f, 0f), Quaternion.identity);
    }
}