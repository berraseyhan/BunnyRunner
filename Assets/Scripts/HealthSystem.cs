using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int maxHealth = 3;
    private int currentHealth;
    private UIManager uiManager;
    private void Start()
    {
        currentHealth = maxHealth;
        uiManager = Object.FindAnyObjectByType<UIManager>();
        uiManager.UpdateHearts(currentHealth);
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            Debug.Log("Can azaldi! Kalan can: " + currentHealth);
            uiManager.UpdateHearts(currentHealth);

            if (currentHealth <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    public void HealHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            Debug.Log("Can artti! Kalan can: " + currentHealth);
            uiManager.UpdateHearts(currentHealth);
        }
        else
        {
            Debug.Log("Can zaten maksimumda!");
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
