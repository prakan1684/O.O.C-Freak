using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{

    private void Update()
    {
        if (slider.value <= 0)
        {
            SceneManager.LoadScene("RestartScene");
        }
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
