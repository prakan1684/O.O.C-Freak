using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : PersistentSingleton<HealthBar>
{

    private void Update()
    {
        SetHealth(PlayerHealthManager.Instance.currentHealth);
    }
    public Slider slider;

    public void SetMaxHealth(int maxHealth, int currentHealth) 
    {
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }
    public void SetHealth(int currentHealth)
    {
        slider.value = currentHealth;
    }

}
