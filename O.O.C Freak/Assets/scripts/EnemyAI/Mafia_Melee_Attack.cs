using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mafia_Melee_Attack : MonoBehaviour
{

    public Animator enemyManimator;
    public Transform target;
   // public float stopAtPlayerRadius;
    public float canAttackRadius;



    private float attackCooldown = 2f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        attackCooldown -= Time.deltaTime;
        
        // FOR TESTING
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    enemyAttack();
        //}    
        // this triggers every frame for now
    }

    void enemyAttack()
    {
        enemyManimator.SetTrigger("MeleeAttack");
        attackCooldown = 2f;
        
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) < canAttackRadius && attackCooldown <= 0) // canAttackRadius is 4 rn
        {
          //  Debug.Log("enemy will swing");
            enemyAttack();
        }

        //else if(Vector3.Distance(target.position, transform.position) < canAttackRadius && attackCooldown > 0)
        //{
        //    attackCooldown -= Time.deltaTime;
        //}
    }
}
