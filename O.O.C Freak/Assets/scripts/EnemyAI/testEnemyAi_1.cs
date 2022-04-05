using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemyAi_1 : MonoBehaviour
{

    // *************Code overall handles player detection and movement of the melee guard *************************
    GameObject player;
    
    Vector3 targetLocation;
    Rigidbody2D enemyRb;
    public float movementSpeed = 5f;

    // for the circle cast
    public float radiusRayCircle;
    public float max_distance = 10f;


    // for rotating enemy to player and moving
    private float angle;
    private bool foundPlayer;
    private Vector2 movement;
    public Animator meleeMove;

    public Transform target;
    public float stopAtPlayerRadius;
    public float gracePeriod = 1f;
    private Vector3 velocity0 = Vector3.zero;
    


   // NOTE: Ai_1 is for patrolling yakuza, Ai_2 will be guarding yakuza


   // Start is called before the first frame update
   void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
       
        enemyRb = this.GetComponent<Rigidbody2D>();

        foundPlayer = false;

        Physics2D.queriesStartInColliders = false;
       
    }

    // Update is called once per frame
    void Update()
    {

        if(foundPlayer == true)
        {
            Vector3 direction = player.transform.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            enemyRb.rotation = angle;
            direction.Normalize();
            movement = direction;
            
        }
        
    }

    private void FixedUpdate()
    {
        if(foundPlayer == false)
        {
            transform.Rotate(Vector3.forward * 20f * Time.deltaTime); // can change
        }
        // ------------FOR A LINE-------------------------
        //RaycastHit2D hit = Physics2D.Raycast(this.transform.position, transform.right, max_distance, layermask_player);

        //if (hit.collider != null)
        //{

        //    Debug.Log("hit player layermask");
        //    Debug.DrawLine(transform.position, hit.point, Color.red);
        //}

        //else
        //{
        //    Debug.DrawLine(transform.position, transform.position + transform.right * max_distance, Color.green);
        //} 

        // -----------WITH A CIRCLE------------------------------

        RaycastHit2D circleHitinfo = Physics2D.CircleCast(this.transform.position, radiusRayCircle, transform.right, max_distance); // collides with everything
        
        if(circleHitinfo.collider != null)
        {

            // found the player
            if (circleHitinfo.collider.CompareTag("Player"))
            {
               // Debug.Log("enemy raycast hit player");
                foundPlayer = true;
            
            }

            else
            {
             
                Debug.DrawLine(transform.position, circleHitinfo.point, Color.red);
            }       
        
        }

        else
        {
           // Debug.Log("havent seen player");
            Debug.DrawLine(transform.position, transform.position + (transform.right * max_distance), Color.green);
        }

        if(foundPlayer == true)
        {
            moveEnemy(movement);
            meleeMove.SetFloat("Speed", movement.magnitude); // makes them walk with feet
        }
        

    }

    void moveEnemy(Vector2 direction)
    {
        if(Vector3.Distance(target.position, transform.position) > stopAtPlayerRadius + gracePeriod) // rn it is at 3
        {
            enemyRb.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.deltaTime));
        }


        // added gracePeriod but 
        else if(Vector3.Distance(target.position, transform.position) >= stopAtPlayerRadius) // SmoothDamp, inside the donut
        {
            //Vector3.SmoothDamp()
            //Debug.Log("inside donut");
            transform.position = Vector3.SmoothDamp(transform.position, target.position , ref velocity0, 1f);
            enemyRb.velocity = Vector2.zero;
        }

        
        
    }



}
