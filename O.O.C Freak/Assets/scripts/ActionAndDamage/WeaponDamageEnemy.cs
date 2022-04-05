using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamageEnemy : MonoBehaviour
{

    public int damageToGive = 10;

    public int damageBar = 2;
   
    public bool hurtEnemy = false;

    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        hurtEnemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)  // changed sledgehammer to isTrigger so now it is OnTrigger
    {
        
        if (other.gameObject.tag == "meleeEnemy" || other.gameObject.tag == "testEnemy") // will add rangedEnemy as well
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();

            hurtEnemy = true;
           
           other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(damageToGive);
          // Debug.Log("enemy damage - 10");
            // Berserk berserkbarincrease =;

            if (enemy != null)
            {

              //  Debug.Log("knockback");
              
            }
            //Destroy(collision.gameObject);
           // Debug.Log("hurt enemy");

        }

        else if(other.gameObject.tag == "rangedEnemy")
        {
            hurtEnemy = true;
            
            other.gameObject.GetComponent<EnemyHealthManager>().TakeDamage(20);
            Debug.Log("enemy damage - 20");

        }
        
        
    }
    //private IEnumerator KnockCoroutine(Rigidbody2D test_enemy)
    //{
    //    Vector2 forceDirection = test_enemy.transform.position - transform.position;
    //    Vector2 force = forceDirection.normalized * thrust;
    //    test_enemy.velocity = force;


    //    yield return new WaitForSeconds(.5f);

    //    test_enemy.velocity = new Vector2();
    //    Debug.Log("enemy stopped");
    //}
    //public void DamageEnemy(int damageToGive, int enemyHealth)
    //{
    //    enemyHealth -= damageToGive;
    //    if(enemyHealth < 0)
    //    {
    //        gameObject.SetActive(false);
    //    }

    //    Debug.Log("enemy damage - 10");
    //}
}
