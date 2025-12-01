using UnityEngine;

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
        
    }

    public void HealthTest()
    {
        if (CurrentHealth != 0)
        {
            CurrentHealth = CurrentHealth - 20;
        } else
        {
            CurrentHealth = MaxHealth;
        }
        HealthBar.SetHealth(CurrentHealth);
    }
}
