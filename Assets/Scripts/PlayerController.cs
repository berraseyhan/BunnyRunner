using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 20f;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    public HealthSystem healthSystem;
    public bool isInvincible = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Update()
    {

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded && !GameManager.Instance.IsGameOver())
        {
            GameManager.Instance.PlaySound(GameManager.Instance.jumpSound);
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public IEnumerator InvincibilityTimer()
    {
        if (GameManager.Instance.IsGameOver()) yield break;
        isInvincible = true;
        Time.timeScale = 0f;

        yield return new WaitUntil(() => Keyboard.current.spaceKey.wasPressedThisFrame);
        if (GameManager.Instance.IsGameOver())
        {
            yield break;
        }
        Time.timeScale = 1f;
        isInvincible = false;
    }

}