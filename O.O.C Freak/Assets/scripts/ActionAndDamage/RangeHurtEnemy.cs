using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeHurtEnemy : MonoBehaviour
{
    public bool playerHit;
    public HurtPlayer playerHurt;
    public PlayerHealthManager playerHealth;

    public Slider slider;

    private GameObject player;
    private Berserk invincibility;

    // Start is called before the first frame update
    void Start()
    {
        invincibility = GetComponent<Berserk>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Projectile>() != null )
        {
            if (other.CompareTag("bullet") && invincibility.invincible == false) // add coconut tag
            {
               // Debug.Log("hit player in playerScript");

                slider.value -= 10;
                Destroy(other.gameObject);
                // RangeDamagePlayer(10);
                //Destroy(other.gameObject);
            }

            else if (other.CompareTag("bullet") && invincibility.invincible == true)
            {
              //  Debug.Log("player is invincible lololol");
                Destroy(other.gameObject);
            }

            else if (other.CompareTag("Coconut") && invincibility.invincible == false)
            {
                //Debug.Log("hit me hit me hit me");
                slider.value -= 15;
                Destroy(other.gameObject);
            }

            else if (other.CompareTag("Coconut") && invincibility.invincible == true)
            {
                Destroy(other.gameObject);
            }
        }
        else
        {
            if (other.CompareTag("Coconut") && invincibility.invincible == false)
            {
               // Debug.Log("hit me hit me hit me");
                slider.value -= 15;
                Destroy(other.gameObject);
            }

            else if (other.CompareTag("Coconut") && invincibility.invincible == true)
            {
                Destroy(other.gameObject);
            }
        }
        
        //else if(other.CompareTag("Coconut")) // from the boss projectile
        //{
        //    Debug.Log("hit player with coconut");
        //    RangeDamagePlayer(20);
        //}


    }

    
}
