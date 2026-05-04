using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] private GameObject cloudPrefab;
    [SerializeField] private float spawnTime = 3f;
    private float timer = 0f;

    private void Update()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.IsGameOver()) return;

        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            SpawnCloud();
            timer = 0f;
        }
    }

    private void SpawnCloud()
    {
        float yPos = Random.Range(0f, 3f);
        Instantiate(cloudPrefab, new Vector3(15f, yPos, 0f), Quaternion.identity);
    }
}
