using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public int maxHealth;
    
    public void SetMaxHealth(float maxHealth)
    {
        slider.maxValue = (int)maxHealth;
    }

    public void SetHealth(float health)
    {
        slider.value = (int)health;
    }
}
