using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    SpriteRenderer enemyrender;


    public static EnemyHealthManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        currentHealth = maxHealth;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        if(currentHealth <=0)
        {
            Debug.Log("enemy died");
            //enemyrender.color = new Color(0f, 0f, 1f);
            Destroy(gameObject); // TEMP FIX BUT PROBABLY PERMANENT
        }
    }
}
