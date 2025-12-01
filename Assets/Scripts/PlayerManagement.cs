using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour
{
    public int MaxHealth = 100;
    private int CurrentHealth;

    public HealthManager HealthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentHealth = 100;
        HealthBar.SetMaxHealth(CurrentHealth, MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth = CurrentHealth-damage;
        if (CurrentHealth < 0)
            CurrentHealth = 0;
        HealthBar.SetHealth(CurrentHealth);
    }
}
