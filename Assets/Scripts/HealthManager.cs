using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int CHealth, int MaxHealth)
    {
        slider.maxValue = MaxHealth;
        slider.value = CHealth;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int CHealth)
    {
        slider.value = CHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
