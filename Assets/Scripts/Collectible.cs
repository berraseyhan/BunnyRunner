using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    

    protected virtual void Update()
    {
        transform.Translate(Vector3.left * SpawnManager.gameSpeed * Time.deltaTime);

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.PlaySound(GameManager.Instance.carrotSound);
            }

            OnCollect();

            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.healthSystem.HealHealth();
            }

            Destroy(gameObject);
        }
    }
    public abstract void OnCollect();
}