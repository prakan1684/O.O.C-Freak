using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour

{
    public Rigidbody2D enemyRigid;
    // initialize varaibles for knockback
    
    public float thrust;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // collider of test enemy
    {
        if(collision.gameObject.tag == "meleeEnemy")  // change tag name to include both ranged and melee enemies
        {
            Rigidbody2D test_enemy = collision.GetComponent<Rigidbody2D>();

            if(test_enemy != null)
            {
                StartCoroutine(KnockCoroutine(test_enemy));
                //test_enemy.isKinematic = false;
                //Vector2 difference = test_enemy.transform.position - transform.position;
                //difference = difference.normalized * thrust;
                //test_enemy.AddForce(difference, ForceMode2D.Impulse);
                //test_enemy.isKinematic = true;

                
            }
           //Destroy(collision.gameObject);
            Debug.Log("knockbacked enemy");

        }
    }
    private IEnumerator KnockCoroutine(Rigidbody2D test_enemy)
    {
        Vector2 forceDirection = test_enemy.transform.position - transform.position;
        Vector2 force = forceDirection.normalized * thrust;
        test_enemy.velocity = force;
       
        
        yield return new WaitForSeconds(.5f);

        test_enemy.velocity = new Vector2();
       // Debug.Log("enemy stopped");
    }
}
