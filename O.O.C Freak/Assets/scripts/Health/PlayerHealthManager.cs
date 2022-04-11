using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : Singleton<PlayerHealthManager>
{
    
    public int currentHealth;
    [SerializeField]
    private int maxHealth;
    public bool playerTookDamage;

    
    // Start is called before the first frame update


    void Start()
    {

        HealthBar.Instance.SetMaxHealth(maxHealth, currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("RestartScene");
        }

        HealthBar.Instance.SetHealth(currentHealth);
    }

    public void PlayerTookDamage(int damage) 
    {
        if (playerTookDamage)
        {
            currentHealth -= damage;
            HealthBar.Instance.SetHealth(currentHealth);
        
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            playerTookDamage = true;
            PlayerTookDamage(5);
            playerTookDamage = false;
        }

    }
}
