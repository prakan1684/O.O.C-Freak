using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MafiaMeleeHurtPlayer : MonoBehaviour
{
    public Slider slider;

    //private GameObject player;
    private Berserk invincibility2;

    // Start is called before the first frame update
    void Start()
    {
        invincibility2 = GetComponent<Berserk>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("enemyKatana") && invincibility2.invincible == false)
        {
            Debug.Log("Katana hit player");
            MeleeDamagePlayer();
        }
        else if(other.CompareTag("enemyKatana") && invincibility2.invincible == true)
        {
            Debug.Log("player is invincible to swords lol");
        }
    }

    private void MeleeDamagePlayer()
    {
        slider.value -= 20;
    }
}
