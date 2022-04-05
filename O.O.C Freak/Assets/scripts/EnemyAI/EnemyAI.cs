using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{   

    /* NORMAL STATIONARY GUARD AI SCRIPT, DIFFERENT FROM ENEMYAI RAYCAST SCRIPT */



    // Start is called before the first frame update
    public Transform player;
    private Vector2 movement;
    private Rigidbody2D rigid;
    private float moveSpeed = 8f;
    public float distance;
    public float rotationSpeed;
    void Start()
    {
        rigid = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rigid.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        //setting up raycast
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);

        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            if (hitInfo.collider.CompareTag("Player"))
            {
                Destroy(hitInfo.collider.gameObject);
            }

        } else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
        }




        
    }
    void moveCharacter(Vector2 direction)
    {
        rigid.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

    }
}
//https://www.youtube.com/watch?v=GPrGg8UDB_E