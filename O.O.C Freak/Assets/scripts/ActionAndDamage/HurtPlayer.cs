using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    private bool isTouching;
    public float waitToHurt;
    [SerializeField]
    public int damageToGive = 1;
    public static HurtPlayer instance;
    public PlayerHealthManager playerHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                DamagePlayer(damageToGive, playerHealth.currentHealth);
                waitToHurt = 1.5f;
            }
        }

    }

    public void DamagePlayer(int damageToGive, int playerHealth)
    {

        playerHealth -= damageToGive;
        healthBar.SetHealth(playerHealth);
        if (playerHealth > 0)
        {
            gameObject.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {

            DamagePlayer(damageToGive, playerHealth.currentHealth);


            //other.gameObject.SetActive(false);
            //reloading = true;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
    /*public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            DamagePlayer(damageToGive, playerHealth.currentHealth);


            //other.gameObject.SetActive(false);
            //reloading = true;
        }
    }*/
}
