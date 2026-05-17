using UnityEngine;

public abstract class Obstacle : MonoBehaviour
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
            PlayerController player = collision.GetComponent<PlayerController>();

            if (player != null && !player.isInvincible)
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.PlaySound(GameManager.Instance.collisionSound);
                }

                OnHitPlayer();
                player.healthSystem.TakeDamage();
                player.StartCoroutine(player.InvincibilityTimer());
            }
        }
    }

    public abstract void OnHitPlayer();
}
