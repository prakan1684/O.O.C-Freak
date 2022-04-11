using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    private bool playerHasBeenHit;

    public int damage = 5; // < -- this doesnt matter bc we change slider.value
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
           DestroyProjectile();
        }

    }

    // private void OnTriggerEnter2D(Collider2D other)
    // {
        
    //    if (other.CompareTag("Player"))
    //    {
    //         playerHasBeenHit = true;   
    //         DamagePlayer(damage);
    //         DestroyProjectile();

    //    }

    // }
    void DestroyProjectile()
    {
       Destroy(gameObject);
    }

    // void DamagePlayer(int damage)
    // {
    //     if(playerHasBeenHit)
    //     {
    //         int playerCurrentHealth = PlayerHealthManager.Instance.currentHealth;
    //         playerCurrentHealth -= damage;
    //     }
    // }


}
