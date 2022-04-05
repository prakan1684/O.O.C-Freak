using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiRaycast : MonoBehaviour
{

    /* PATROLLING AI SCRIPT, DIFFERENT FROM ENEMYAI SCRIPT */
    public float distance;
    public float rotationSpeed;
    public LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;


    //following movement script
    public Transform player;
    private Vector2 movement;
    private Rigidbody2D rigid;
    private float moveSpeed = 4f;
    public Transform homePos;
    public Vector3 homeLinePos;

    public float maxRange;
    public float minRange;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rigid = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        
        //draw ray
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance);



        //if the ray collides with 

        

        if (Vector3.Distance(player.position, transform.position) <= maxRange && Vector3.Distance(player.position, transform.position) >= minRange)
        {

            

            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("found the bitch");

                Vector3 direction = player.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rigid.rotation = angle;
                direction.Normalize();
                



                Debug.DrawLine(transform.position, hitInfo.point, Color.red);
                lineOfSight.SetPosition(1, hitInfo.point);
                lineOfSight.colorGradient = redColor;

                moveCharacter(direction);
            }
        }
        else if (Vector3.Distance(player.position, transform.position) >= maxRange)
        {
           /* direction = homePos.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rigid.rotation = angle;
            direction.Normalize();
            movement = direction;
*/

            GoHome();
            rigid.rotation = 0;
            lineOfSight.colorGradient = greenColor;
            lineOfSight.SetPosition(1, homeLinePos);

            
        }
       
        else if(hitInfo.collider.CompareTag("tilemap"))
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            lineOfSight.colorGradient = greenColor;

        }else
        {
         
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            lineOfSight.colorGradient = greenColor;
        }
        lineOfSight.SetPosition(0, transform.position);


    }
    void moveCharacter(Vector2 direction)
    {
        rigid.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }
    void GoHome()
    {
        transform.position = Vector2.MoveTowards(transform.position, homePos.position, moveSpeed * Time.deltaTime);
    }

}
