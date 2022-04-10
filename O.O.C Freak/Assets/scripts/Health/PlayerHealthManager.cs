using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    
    public int currentHealth;
    [SerializeField]
    private int maxHealth;
    public static PlayerHealthManager instance;
    public HealthBar healthBar;
    
    // Start is called before the first frame update


    void Start()
    {

        instance = this;
        healthBar.SetMaxHealth(maxHealth, currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("RestartScene");
        }
    }

    /*public void PlayerTookDamage(int damage) 
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0)
        {
            Debug.Log("Player died");
        }
    }*/
}
